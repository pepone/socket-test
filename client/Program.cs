using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                EndPoint endpoint;
                Socket socket;

                endpoint = new DnsEndPoint("localhost", 62146);
                socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.DualMode = true;

                Console.WriteLine($"Connecting to: {endpoint}");

                await socket.ConnectAsync(endpoint, CancellationToken.None);
                Console.WriteLine($"socket.AddressFamily: {socket.AddressFamily}");
                Console.WriteLine($"connected to: {socket.LocalEndPoint}");
                Console.ReadLine();
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
