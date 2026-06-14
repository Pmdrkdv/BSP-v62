using System.Collections.Generic;


    public static class ByteStreamHelper
    {
        public static List<int>? ReadDataReference(ByteStream byteStream)
        {
            var result = new List<int>();
            int v1 = byteStream.ReadVInt();
            result.Add(v1);
            if (v1 == 0)
            {
                return null;
            }
            int v2 = byteStream.ReadVInt();
            result.Add(v2);
            return result;
        }

        public static void EncodeIntList(ByteStream byteStream, List<int> intList)
        {
            int length = intList.Count;
            byteStream.WriteVInt(length);
            foreach (int i in intList)
            {
                byteStream.WriteVInt(i);
            }
        }
    }
