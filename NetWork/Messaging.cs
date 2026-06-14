using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;

using IOStream = System.IO.Stream;

    public static class Messaging
    {
      
        public static void WriteHeader(PiranhaMessage message, int payloadLen)
        {
            message.MessageBuffer = ConcatArrays(message.MessageBuffer, message.GetMessageType().ToBigEndianByteArray(2));
            message.MessageBuffer = ConcatArrays(message.MessageBuffer, payloadLen.ToBigEndianByteArray(3));
            message.MessageBuffer = ConcatArrays(message.MessageBuffer, message.MessageVersion.ToBigEndianByteArray(2));
        }

        public static List<int> ReadHeader(byte[] headerBytes)
        {
            if (headerBytes.Length < 7)
                return new List<int> { 0, 0 };

            int messageType = headerBytes.Skip(0).Take(2).ToArray().ToBigEndianInt();
            int payloadLen = headerBytes.Skip(2).Take(3).ToArray().ToBigEndianInt();
            return new List<int> { messageType, payloadLen };
        }

     
        public static void SendMessage(int messageType, Dictionary<string, object?> fields,Connection connection)
        {
            var message = LogicLaserMessageFactory.CreateMessageByType(messageType, Array.Empty<byte>(),connection);
            if (message == null)
            {
                Logger.Print($"[MessageManager::sendMessage] Message type {messageType} not found");
                return;
            }

            message.Encode();
            
           
            WriteHeader(message, message.MessagePayload.Count);
            message.MessageBuffer = ConcatArrays(message.MessageBuffer, message.MessagePayload.ToArray());

            try
            {
      
                if (fields.TryGetValue("Socket", out var socketObj) && socketObj is Socket socket)
                {
                    using var networkStream = new NetworkStream(socket, ownsSocket: false);
                    networkStream.Write(message.MessageBuffer, 0, message.MessageBuffer.Length);
                    networkStream.Flush();
                }
                else if (fields.TryGetValue("Stream", out var streamObj) && streamObj is IOStream stream)
                {
                    stream.Write(message.MessageBuffer, 0, message.MessageBuffer.Length);
                    stream.Flush();
                }
                else if (fields.TryGetValue("Connection", out var connObj) && connObj is Connection connection1)
                {
                    if (connection1.Socket != null)
                    {
                        using var networkStream = new NetworkStream(connection.Socket, ownsSocket: false);
                        networkStream.Write(message.MessageBuffer, 0, message.MessageBuffer.Length);
                        networkStream.Flush();
                    }
                }
                else
                {
                    Logger.Print($"[!] No valid socket/stream found for message {messageType}");
                }
            }
            catch (ObjectDisposedException)
            {
                Logger.Print($"[!] Socket/Stream disposed while sending message {messageType}");
            }
            catch (IOException ex)
            {
                Logger.Print($"[!] IO Error sending message {messageType}: {ex.Message}");
            }
            catch (Exception ex)
            {
                Logger.Print($"[!] Error sending message {messageType}: {ex}");
            }
        }


        private static byte[] ConcatArrays(byte[] first, byte[] second)
        {
            if (first == null || first.Length == 0) return second ?? Array.Empty<byte>();
            if (second == null || second.Length == 0) return first;

            var result = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, result, 0, first.Length);
            Buffer.BlockCopy(second, 0, result, first.Length, second.Length);
            return result;
        }

      
        private static byte[] ToBigEndianByteArray(this int value, int size)
        {
            var result = new byte[size];
            for (int i = 0; i < size; i++)
            {
                result[size - 1 - i] = (byte)((value >> (8 * i)) & 0xFF);
            }
            return result;
        }

        private static int ToBigEndianInt(this byte[] array)
        {
            if (array == null || array.Length == 0) return 0;
            
            int result = 0;

            for (int i = 0; i < array.Length; i++)
            {
                result = (result << 8) | (array[i] & 0xFF);
            }
            return result;
        }
    }
    public static class MessageManager
    {
        public static void ReceiveMessage(Connection connection, int messageType, byte[] messagePayload)
        {
            var message = LogicLaserMessageFactory.CreateMessageByType(messageType, messagePayload,connection);
            if (message == null)
            {
                Logger.Print($"[MessageManager::sendMessage] Unknown message type: {messageType}");
                return;
            }

            try
            {
                if (message.IsServerToClient())
                {
                    message.Encode();
                }
            else
            {
                message.Execute();
            }
        }
        catch (Exception ex)
        {
            Logger.Print($"[!] Error processing message {messageType}: {ex}");
        }
    }
}
