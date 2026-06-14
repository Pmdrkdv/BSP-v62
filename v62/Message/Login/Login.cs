using System.Collections.Generic;


    public class LoginMessage : PiranhaMessage
    {
        public LoginMessage(byte[] messageData) : base(messageData)
        {
            MessageVersion = 0;
        }
        public int AccountID;
        public string PassToken;
        public int ClientMajor;

        public int ClientMinor;
        public override void Decode()
        {
            var fields = new Dictionary<string, object>();
            fields["AccountID"] = this.ReadLong();
            fields["PassToken"] = this.ReadString();
            fields["ClientMajor"] = this.ReadInt();
            fields["ClientMinor"] = this.ReadInt();
            fields["ClientBuild"] = this.ReadInt();



            if (fields.ContainsKey("DeviceVerifierResponse"))
            {
                this.ReadString();
            }

    
        }

        public override void Execute()
        {
            var mutableFields = new Dictionary<string, object>();
            mutableFields["Connection"] = connection;
            Messaging.SendMessage(20104, mutableFields,connection);
            Messaging.SendMessage(24101, mutableFields,connection);
        }

        public override int GetMessageType()
        {
            return 10101;
        }
    }
