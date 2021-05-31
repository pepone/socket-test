using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var endpoint = new DnsEndPoint("localhost", 10000);
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);

            await socket.ConnectAsync(endpoint);
            Console.WriteLine($"connected to: {socket.LocalEndPoint}");
            Console.ReadLine();
        }
    }
}
