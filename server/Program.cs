using System;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 62146);
            var socket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.ExclusiveAddressUse = true;

            socket.Bind(endpoint);
            socket.Listen();
            Console.WriteLine($"listening at: {socket.LocalEndPoint}");
            Console.ReadLine();
        }
    }
}
