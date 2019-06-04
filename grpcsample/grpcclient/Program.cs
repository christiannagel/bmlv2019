using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace grpcclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("client - wait for server");
            Console.ReadLine();
            var channel = new Channel("localhost:50051", SslCredentials.Insecure);
            var client = new Greet.Greeter.GreeterClient(channel);
            var reply = client.SayHello(new Greet.HelloRequest() { Name = "Katharina" });
            Console.WriteLine(reply.Message);
            await channel.ShutdownAsync();
        }
    }
}
