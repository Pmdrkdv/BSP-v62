using System.Text;

    public static class LogicStringUtil
    {
        public static byte[] GetBytes(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static int GetByteLength(byte[] bytes)
        {
            return bytes.Length;
        }
    }
