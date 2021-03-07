using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Proto.Library;

namespace Client
{
    public class gRPCBenchmark
    {
        private readonly GrpcChannel _channel;
        private readonly Greeter.GreeterClient _client;

        public gRPCBenchmark()
        {
            _channel = GrpcChannel.ForAddress("https://localhost:5001");
            _client = new Greeter.GreeterClient(_channel);
        }

        public async Task Execute(int loopCount)
        {
            for (int count = 0; count <= loopCount; count++)
            {
                var response = await  _client.SayHelloAsync(new HelloRequest { Name = "Client" });
                Console.WriteLine(response.Message);
            }
        }

        ~gRPCBenchmark()
        {
            _channel.Dispose();
        }        
    }
}
