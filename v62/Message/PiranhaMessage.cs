using System.Collections.Generic;


    public class PiranhaMessage : ByteStream
    {
        public byte[] MessageBuffer { get; set; }
        public Dictionary<string, object> Fields { get; set; }
        public int MessageVersion { get; set; } = 1;

        public Connection connection;
        public PiranhaMessage(byte[] messageData) : base(messageData)
        {
            MessageBuffer = messageData;
            Fields = new Dictionary<string, object>();
        }

        public virtual void Decode() 
        {
           
        }

        public virtual void Encode()
        {
       
        }

        public virtual void Execute()
        {
        
        }

        public virtual int GetMessageType()
        {
            return 0;
        }

        public bool IsServerToClient()
        {
            int messageType = GetMessageType();
            return (messageType >= 20000 && messageType <= 29999) || messageType == 40000;
        }
    }
