



public class LogicLong
    {
        public int High { get; set; }
        public int Low { get; set; }

        public LogicLong(int high = 0, int low = 0)
        {
            High = high;
            Low = low;
        }

        public void Decode(ByteStream bytestream)
        {
            High = bytestream.ReadInt();
            Low = bytestream.ReadInt();
        }
    }
