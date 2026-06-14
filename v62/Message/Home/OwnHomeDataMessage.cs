using System.Collections.Generic;

public class OwnHomeDataMessage : PiranhaMessage
{
  public OwnHomeDataMessage(byte[] messageData) : base(messageData)
  {
    MessageVersion = 0;
  }

  public override void Encode()
  {

    var stream = this;
    stream.WriteVInt(1757882887);
    stream.WriteVInt(-1230828389);




    stream.WriteVInt(2025257);
    stream.WriteVInt(40312);
    stream.WriteVInt(3737);
    stream.WriteVInt(3737);
    stream.WriteVInt(3737);
    stream.WriteVInt(1);
    stream.WriteVInt(-1);
    stream.WriteDataReference(28, 5);
    stream.WriteDataReference(43, 0);


    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);




    stream.WriteVInt(0);
    stream.WriteVInt(3737);
    stream.WriteVInt(1337);
    stream.WriteVInt(2);
    stream.WriteBoolean(true);
    stream.WriteVInt(999);
    stream.WriteVInt(144);
    stream.WriteVInt(1509112);
    stream.WriteVInt(144);
    stream.WriteVInt(1509112);

    stream.WriteVInt(200);
    stream.WriteVInt(200);
    stream.WriteVInt(5);
    {
      stream.WriteVInt(93);
      stream.WriteVInt(206);
      stream.WriteVInt(456);
      stream.WriteVInt(1001);
      stream.WriteVInt(2264);
    }

    stream.WriteBoolean(true);
    stream.WriteVInt(2);
    stream.WriteVInt(2);
    stream.WriteVInt(2);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);


    stream.WriteVInt(1);//   LogicOfferBundle::encode\

    stream.WriteVInt(1);

    stream.WriteVInt(3);
    stream.WriteVInt(1);
    stream.WriteVInt(16);
    stream.WriteVInt(96);
    stream.WriteVInt(52);



    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(1488);
    stream.WriteVInt(2);
    stream.WriteVInt(2300000);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteVInt(2);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);  //не юзаеться с в47
    stream.WriteVInt(0);

    stream.WriteString("бревно не дорого");
    stream.WriteVInt(0);
    stream.WriteBoolean(false);


    stream.WriteString("offer_bgr_trunk");
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteString("");
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);

    stream.WriteVInt(0);



    stream.WriteVInt(0);
    stream.WriteDataReference(96, 1);//ШТО ЕТО 


    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteVInt(0); //тут реф ну похуй мне
    stream.WriteVInt(0);



    stream.WriteVInt(400);
    stream.WriteVInt(500);
    stream.WriteVInt(-1);



    stream.WriteVInt(1);
    stream.WriteVInt(30);
    stream.WriteByte(1);
    stream.WriteDataReference(16, 1);


    stream.WriteString("RU");
    stream.WriteString("BSPv-62");

    stream.WriteVInt(15);
    stream.WriteDataReference(2, 1);
    stream.WriteDataReference(6, 0);
    stream.WriteDataReference(7, 0);
    stream.WriteDataReference(1, 9);
    stream.WriteDataReference(10, 0);
    stream.WriteDataReference(1, 12);
    stream.WriteDataReference(15, 0);
    stream.WriteDataReference(16, 60);
    stream.WriteDataReference(17, 0);
    stream.WriteDataReference(1, 18);
    stream.WriteDataReference(19, 0);
    stream.WriteDataReference(21, 1);
    stream.WriteDataReference(22, 1);
    stream.WriteDataReference(23, 0);
    stream.WriteDataReference(24, 1);
   // stream.WriteDataReference(52, 1);

    stream.WriteVInt(0);// CooldownEntry::encode


    stream.WriteVInt(1);
    {
      stream.WriteVInt(40);
      stream.WriteVInt(15);
      stream.WriteBoolean(true);
      stream.WriteVInt(0);
      stream.WriteBoolean(false);
      stream.WriteBoolean(true);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteBoolean(true);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteBoolean(true);
      stream.WriteBoolean(true);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
      stream.WriteInt(0);
    }


    stream.WriteBoolean(true);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(3);
    stream.WriteVInt(0);


    stream.WriteBoolean(true);
    stream.WriteVInt(0);

    stream.WriteBoolean(false);
    // {
    //   LogicPlayerRankedSeasonData_default.Encode(stream);
    // }
    stream.WriteInt(0);
    stream.WriteVInt(1337);
    stream.WriteDataReference(16, 1);
    stream.WriteBoolean(false);
    stream.WriteVInt(-1);
    stream.WriteVInt(1337);
    stream.WriteVInt(832099);
    stream.WriteVInt(1616899);
    stream.WriteVInt(10659101);
    stream.WriteVInt(0);
    stream.WriteVInt(0);

    stream.WriteVInt(6);
    {
      stream.WriteDataReference(2, 446);
      stream.WriteDataReference(2, 448);
      stream.WriteDataReference(2, 450);
      stream.WriteDataReference(2, 452);
      stream.WriteDataReference(2, 454);
      stream.WriteDataReference(2, 456);
    }
    stream.WriteDataReference(2, 462);
    stream.WriteDataReference(2, 460);
    stream.WriteDataReference(2, 464);
    stream.WriteDataReference(2, 466);
    stream.WriteBoolean(false);


    stream.WriteDataReference(2, 473);
    stream.WriteVInt(1337);


    stream.WriteVInt(2025074);



    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);

    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);




    stream.WriteVInt(0);

    stream.WriteVInt(9);
    stream.WriteDataReference(41000000 + 136, 1);
    stream.WriteDataReference(89, 6);
    stream.WriteDataReference(22, 0);
    stream.WriteDataReference(36, 1);
    stream.WriteDataReference(73, 1);
    stream.WriteDataReference(16, 5);
    stream.WriteDataReference(1, 10056);
    stream.WriteDataReference(1, 10057);
    stream.WriteDataReference(13, 10063);

    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);



    stream.WriteVInt(0);


    stream.WriteVInt(0);



    stream.WriteLong(0, 1);
    stream.WriteVInt(0);



    stream.WriteVInt(1337);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);



    stream.WriteVInt(0);

    stream.WriteVInt(0);

    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);

    stream.WriteBoolean(true);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);

    stream.WriteVInt(0);


    stream.WriteDataReference(100, 1);
    stream.WriteDataReference(28, -1);
    stream.WriteDataReference(28, -1);
    stream.WriteDataReference(52, -1);
    stream.WriteDataReference(76, -1);
    stream.WriteDataReference(0, 0);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);



    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteInt(-1435281534);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(86400 * 24);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);



    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteBoolean(false);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);
    stream.WriteBoolean(true);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(1);
    {
      stream.WriteVInt(13);
    }
    stream.WriteVInt(0);



    stream.WriteVLong(0, 254842734);
    stream.WriteVLong(0, 254842734);
    stream.WriteVLong(0, 0);
    stream.WriteString("pmdrkdv");
    stream.WriteBoolean(true);
    stream.WriteInt(-1);
    stream.WriteVInt(28);

    stream.WriteVInt(1 + 7);

    stream.WriteDataReference(23, 0);
    stream.WriteVInt(-1);
    stream.WriteVInt(1);

    stream.WriteDataReference(5, 8);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 9);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 21);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 22);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 23);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 24);
    stream.WriteVInt(-1);
    stream.WriteVInt(35);
    stream.WriteDataReference(5, 25);
    stream.WriteVInt(-1);
    stream.WriteVInt(37);

    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);

    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);


    stream.WriteVInt(69);
    stream.WriteVInt(69);
    stream.WriteVInt(10);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(2);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteString("");
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteVInt(0);
    stream.WriteBoolean(false);

  }

  public override int GetMessageType()
  {
    return 24101;
  }
}
