using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        public static void CreateServer()
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 62146);
            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.ExclusiveAddressUse = true;

            socket.Bind(endpoint);
            socket.Listen();
            Console.WriteLine($"listening at: {socket.LocalEndPoint}");
        }

        static async Task Main(string[] args)
        {
            try
            {
                CreateServer();
                var endpoint = new DnsEndPoint("localhost", 62146);
                var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

                Console.WriteLine($"Connecting to: {endpoint}");
                await socket.ConnectAsync(endpoint, CancellationToken.None);
                Console.WriteLine($"socket.AddressFamily: {socket.AddressFamily}");
                // Accessing LocalEndPoint here throws the crash
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
