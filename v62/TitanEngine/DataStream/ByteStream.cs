using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;


 
    public class ByteStream : ChecksumEncoder
    {
        public List<byte> MessagePayload { get; set; }
        public int BitOffset { get; set; } = 0;
        public int Offset { get; set; } = 0;
        public int Length => MessagePayload.Count;

        public ByteStream(byte[] messageBuffer)
        {
            MessagePayload = new List<byte>(messageBuffer);
        }

        public bool ReadBoolean()
        {
            int bitoffset = this.BitOffset;
            int offset = this.Offset + ((8 - bitoffset) >> 3);
            this.Offset = offset;
            this.BitOffset = (bitoffset + 1) & 7;
            
            if (offset - 1 >= 0 && offset - 1 < MessagePayload.Count)
            {
                return ((1 << (bitoffset & 31)) & MessagePayload[offset - 1]) != 0;
            }
            return false;
        }

        public int ReadByte()
        {
            this.BitOffset = 0;
            if (this.Offset >= MessagePayload.Count) return 0;
            int result = MessagePayload[this.Offset] & 0xFF;
            this.Offset += 1;
            return result;
        }

        public List<int>? ReadDataReference()
        {
            return ByteStreamHelper.ReadDataReference(this);
        }

        public byte[] ReadBytes(int length, int max = 1000)
        {
            this.BitOffset = 0;
            if ((length & 0x80000000) != 0)
            {
                if (length != -1)
                {
                    // Handle logic if needed
                }
            }
            else if (length <= max)
            {
                if (this.Offset + length <= MessagePayload.Count)
                {
                    var result = MessagePayload.GetRange(this.Offset, length).ToArray();
                    this.Offset += length;
                    return result;
                }
            }
            return Array.Empty<byte>();
        }

        public string ReadString(int max = 900000)
        {
            this.BitOffset = 0;
            if (this.Offset + 4 > MessagePayload.Count) return " ";

            int length = (MessagePayload[this.Offset] & 0xFF) << 24;
            length += (MessagePayload[this.Offset + 1] & 0xFF) << 16;
            length += (MessagePayload[this.Offset + 2] & 0xFF) << 8;
            length += (MessagePayload[this.Offset + 3] & 0xFF);
            this.Offset += 4;

            if (length <= -1)
            {
                if (length != -1)
                {
                    // Handle logic
                }
                return " ";
            }
            else if (length > max)
            {
                return " ";
            }

            if (this.Offset + length > MessagePayload.Count) return " ";

            var resultBytes = MessagePayload.GetRange(this.Offset, length).ToArray();
            string result = Encoding.UTF8.GetString(resultBytes);
            this.Offset += length;
            return result;
        }

        public int ReadInt()
        {
            this.BitOffset = 0;
            if (this.Offset + 4 > MessagePayload.Count) return 0;

            int result = (MessagePayload[this.Offset] & 0xFF) << 24;
            result += (MessagePayload[this.Offset + 1] & 0xFF) << 16;
            result += (MessagePayload[this.Offset + 2] & 0xFF) << 8;
            result += (MessagePayload[this.Offset + 3] & 0xFF);
            this.Offset += 4;
            return result;
        }

        public List<int> ReadLong(LogicLong logicLong = null)
        {
            var Long = logicLong ?? new LogicLong(0, 0);
            Long.Decode(this);
            return new List<int> { Long.High, Long.Low };
        }
        public void WriteDataReference(int v1,int v2)
        {
            WriteVInt(v1);
            WriteVInt(v2);
        }
        public int ReadVInt()
        {
            int offset = this.Offset;
            this.BitOffset = 0;
            int v4 = offset + 1;
            this.Offset = offset + 1;
            
            if (offset >= MessagePayload.Count) return 0;

            int result = MessagePayload[offset] & 0x3F;
            if ((MessagePayload[offset] & 0x40) != 0)
            {
                if ((MessagePayload[offset] & 0x80) != 0)
                {
                    this.Offset = offset + 2;
                    if (v4 < MessagePayload.Count)
                    {
                        int v7 = MessagePayload[v4];
                        result = (result & -57601) | ((v7 & 0x7F) << 6);
                    }
                }
            }
            return result;
        }

        public override void WriteBoolean(bool value)
        {
            base.WriteBoolean(value);
            if (this.BitOffset == 0)
            {
                MessagePayload.Add(0);
                this.Offset += 1;
            }
            if (value)
            {
                int index = this.Offset - 1;
                if (index >= 0 && index < MessagePayload.Count)
                {
                    MessagePayload[index] = (byte)(MessagePayload[index] | (1 << (this.BitOffset & 31)));
                }
            }
            this.BitOffset = (this.BitOffset + 1) & 7;
        }

        public override void WriteByte(int value)
        {
            base.WriteByte(value);
            this.BitOffset = 0;
            MessagePayload.Add((byte)(value & 0xFF));
            this.Offset += 1;
        }

        public override void WriteInt(int value)
        {
            base.WriteInt(value);
            WriteIntToByteArray(value);
        }

        public void WriteIntLittleEndian(int value)
        {
            this.BitOffset = 0;
            MessagePayload.Add((byte)(value & 0xFF));
            MessagePayload.Add((byte)((value >> 8) & 0xFF));
            MessagePayload.Add((byte)((value >> 16) & 0xFF));
            MessagePayload.Add((byte)((value >> 24) & 0xFF));
            this.Offset += 4;
        }

        public void WriteIntToByteArray(int value)
        {
            this.BitOffset = 0;
            MessagePayload.Add((byte)((value >> 24) & 0xFF));
            MessagePayload.Add((byte)((value >> 16) & 0xFF));
            MessagePayload.Add((byte)((value >> 8) & 0xFF));
            MessagePayload.Add((byte)(value & 0xFF));
            this.Offset += 4;
        }

        public void WriteLong(int high, int low)
        {
            WriteIntToByteArray(high);
            WriteIntToByteArray(low);
        }

        public override void WriteString(string value)
        {
            base.WriteString(value);
            this.BitOffset = 0;
            if (value != null)
            {
                byte[] strBytes = LogicStringUtil.GetBytes(value);
                int strLength = LogicStringUtil.GetByteLength(strBytes);
                if (strLength < 900001)
                {
                    WriteIntToByteArray(strLength);
                    MessagePayload.AddRange(strBytes);
                    this.Offset += strLength;
                }
                else
                {
                    WriteIntToByteArray(-1);
                }
            }
            else
            {
                WriteIntToByteArray(-1);
            }
        }

        public override void WriteStringReference(string value)
        {
            base.WriteStringReference(value);
            this.BitOffset = 0;
            byte[] strBytes = LogicStringUtil.GetBytes(value);
            int strLength = LogicStringUtil.GetByteLength(strBytes);
            if (strLength < 900001)
            {
                WriteIntToByteArray(strLength);
                MessagePayload.AddRange(strBytes);
                this.Offset += strLength;
            }
            else
            {
                WriteIntToByteArray(-1);
            }
        }

        public override void WriteVInt(int value)
        {
            this.BitOffset = 0;
            List<byte> finalBytes = new List<byte>();
            if ((value & 0x80000000) != 0)
            {
                if (value >= -63)
                {
                    finalBytes.Add((byte)((value & 0x3F) | 0x40));
                    this.Offset += 1;
                }
                else
                {
                    finalBytes.Add((byte)((value & 0x3F) | 0xC0));
                    finalBytes.Add((byte)(((value >> 6) & 0x7F) | 0x80));
                    finalBytes.Add((byte)(((value >> 13) & 0x7F) | 0x80));
                    finalBytes.Add((byte)(((value >> 20) & 0x7F) | 0x80));
                    finalBytes.Add((byte)((value >> 27) & 0xF));
                    this.Offset += 5;
                }
            }
            else
            {
                if (value <= 63)
                {
                    finalBytes.Add((byte)(value & 0x3F));
                    this.Offset += 1;
                }
                else
                {
                    finalBytes.Add((byte)((value & 0x3F) | 0x80));
                    finalBytes.Add((byte)(((value >> 6) & 0x7F) | 0x80));
                    finalBytes.Add((byte)(((value >> 13) & 0x7F) | 0x80));
                    finalBytes.Add((byte)(((value >> 20) & 0x7F) | 0x80));
                    finalBytes.Add((byte)((value >> 27) & 0xF));
                    this.Offset += 5;
                }
            }
            MessagePayload.AddRange(finalBytes);
        }

        public override void WriteVLong(int high, int low)
        {
            base.WriteVLong(high, low);
            this.BitOffset = 0;
            WriteVInt(high);
            WriteVInt(low);
        }

        public void EncodeIntList(List<int> intList)
        {
           ByteStreamHelper.EncodeIntList(this, intList);
        }

        public void WriteCompressedString(string data)
        {
            this.BitOffset = 0;
            byte[] inputBytes = Encoding.UTF8.GetBytes(data);
            byte[] compressedText;
            using (var outputStream = new MemoryStream())
            {
                using (var deflateStream = new DeflateStream(outputStream, CompressionMode.Compress, true))
                {
                    deflateStream.Write(inputBytes, 0, inputBytes.Length);
                }
                compressedText = outputStream.ToArray();
            }

            WriteInt(compressedText.Length + 4);
            WriteIntLittleEndian(data.Length);
            MessagePayload.AddRange(compressedText);
        }
    }
