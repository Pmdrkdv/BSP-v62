using System.Collections.Generic;



    public class LoginOkMessage : PiranhaMessage
    {
        public LoginOkMessage(byte[] messageData) : base(messageData)
        {
            MessageVersion = 1;
        }

        public override void Encode()
        {
            this.WriteLong(0, 1);
            this.WriteLong(0, 1);
            this.WriteString(" ");
            this.WriteString(null);
            this.WriteString(null);
            this.WriteInt(55);
            this.WriteInt(211);
            this.WriteInt(1);
            this.WriteString("dev ");
            this.WriteInt(0);
            this.WriteInt(0);
            this.WriteInt(0);
            this.WriteString(null);
            this.WriteString(null);
            this.WriteString(null);
            this.WriteInt(0);
            this.WriteString(null);
            this.WriteString("RU ");
            this.WriteString(null);
            this.WriteInt(0);
            this.WriteString(null);
            this.WriteInt(2);
            this.WriteString("https://game-assets.brawlstarsgame.com ");
            this.WriteString("http://a678dbc1c015a893c9fd-4e8cc3b1ad3a3c940c504815caefa967.r87.cf2.rackcdn.com ");
            this.WriteInt(2);
            this.WriteString("https://event-assets.brawlstars.com ");
            this.WriteString("https://24b999e6da07674e22b0-8209975788a0f2469e68e84405ae4fcf.ssl.cf2.rackcdn.com/event-assets ");
            this.WriteVInt(0);
            this.WriteCompressedString(" ");
            this.WriteBoolean(true);
            this.WriteBoolean(false);
            this.WriteString(null);
            this.WriteString(null);
            this.WriteString(null);
            this.WriteString("https://play.google.com/store/apps/details?id=com.supercell.brawlstars ");
            this.WriteString(null);
            this.WriteBoolean(false);
            this.WriteBoolean(false);
            this.WriteString(null);
            this.WriteBoolean(false);
            this.WriteString(null);
            this.WriteBoolean(false);
            this.WriteString(null);
            this.WriteBoolean(false);
            this.WriteString(null);
        }



 

        public override int GetMessageType()
        {
            return 20104;
        }
    }
