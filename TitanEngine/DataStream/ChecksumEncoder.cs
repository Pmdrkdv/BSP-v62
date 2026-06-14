using System;

public class ChecksumEncoder
{
    public int Checksum { get; set; } = 0;
    public int Checksum2 { get; set; } = 0;
    public bool ChecksumEnabled { get; set; } = true;

    public virtual void WriteBoolean(bool value)
    {
        int integer = value ? 13 : 7;
        Checksum = integer + (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31)));
    }

    public virtual void WriteByte(int value)
    {
        Checksum = (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + value + 11;
    }

    public virtual void WriteInt(int value)
    {
        Checksum = (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + value + 9;
    }

    public virtual void WriteString(string value)
    {
        int checksum = (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31)));
        Checksum = checksum + 27;
    }

    public virtual void WriteStringReference(string value)
    {
        Checksum = value.Length + (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + 38;
    }

    public virtual void WriteVInt(int value)
    {
        Checksum = value + (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + 33;
    }

    public virtual void WriteVLong(int high, int low)
    {
        Checksum = low + (int)(((uint)(high + (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + 65) >> 31) | ((uint)(high + (int)(((uint)Checksum >> 31) | ((uint)Checksum << (32 - 31))) + 65) << (32 - 31))) + 88;
    }
}