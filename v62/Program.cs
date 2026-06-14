using System.Net;
using System.Net.Sockets;

public class Program
{
    private static void Main(string[] args)
    {
        Logger.Logo();
        init("192.168.0.105", 9339);

    }

    public static void init(string serverAddress, int serverPort)
    {
        var listener = new TcpListener(IPAddress.Parse(serverAddress), serverPort);
        listener.Start();

        Logger.Print($"[ServerConnection::connectTo] Server started on {serverAddress}:{serverPort}");

        while (true)
        {
            var socket = listener.AcceptSocket();
            Logger.Print($"[ServerConnection::connect] New connection: {socket.RemoteEndPoint?.ToString()}");
            _ = new Connection(socket, socket.RemoteEndPoint?.ToString());
        }
    }
}