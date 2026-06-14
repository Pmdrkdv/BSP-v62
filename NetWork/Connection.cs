using System;
using System.Net.Sockets;
using System.Threading;


public class Connection
{
    public Socket Socket { get; private set; }
    private readonly string _address;
    private long _timeout;
    private Thread? _thread;
    private readonly CancellationTokenSource _cts = new CancellationTokenSource();

    public Connection(Socket socket, string address)
    {
        Socket = socket;
        _address = address;
        _timeout = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        _thread = new Thread(Run);
        _thread.IsBackground = true;
        _thread.Start();
    }

    private byte[] Recv(int n)
    {
        if (Socket == null) return Array.Empty<byte>();

        using var networkStream = new NetworkStream(Socket, false);
        var data = new byte[n];
        int received = 0;

        while (received < n && !_cts.Token.IsCancellationRequested)
        {
            int packet = networkStream.Read(data, received, n - received);
            if (packet <= 0) return Array.Empty<byte>();
            received += packet;
        }
        return data;
    }

    private void Run()
    {
        try
        {
            while (true)
            {
                Thread.Sleep(1);
                var messageHeader = Recv(7);
                if (messageHeader.Length >= 7)
                {
                    var headerData = Messaging.ReadHeader(messageHeader);
                    _timeout = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    int payloadLen = headerData[1];
                    var packetPayload = Recv(payloadLen);
                    int packetID = headerData[0];

                    MessageManager.ReceiveMessage(this, packetID, packetPayload);
                }
            }
        }
        catch (ObjectDisposedException)
        {
            Logger.Print($"[ServerConnection::disconnect] client disconected");
        }
        catch (Exception e)
        {
            Logger.Print($"[C] Connection error: {_address}");
            Logger.Print(e.ToString());
        }
        finally
        {
            Close();
        }
    }

    public void Close()
    {
        _cts.Cancel();
        try { Socket?.Shutdown(SocketShutdown.Both); } catch { }
        Socket?.Close();
        Socket?.Dispose();
    }
}
