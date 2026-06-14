using System;

public static class LogicLaserMessageFactory
{
    public static PiranhaMessage CreateMessageByType(int messageType, byte[] messagePayload, object connection)
    {
        PiranhaMessage message = null;
        
        switch (messageType)
        {
            case 10101:
                message = new LoginMessage(messagePayload);
                message.Execute();
                break;
            case 20104:
                message = new LoginOkMessage(messagePayload);
                break;
            case 24101:
                message = new OwnHomeDataMessage(messagePayload);
                break;
            default:
                return null;
        }
        
        Logger.Print($"[S] {messageType} Sent");
        message.connection = connection as Connection;
        return message;
    }
}