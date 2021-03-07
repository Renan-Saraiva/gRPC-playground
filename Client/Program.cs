using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Grpc.Net.Client;
using Proto.Library;

namespace Client
{
    class Program
    {
        public static int LoogCount = 100;

        static async Task Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            //Esperando a API subir
            await Task.Delay(TimeSpan.FromSeconds(5));

            var apiBenchmark = new APIBenchmark();
            await apiBenchmark.Execute(LoogCount);

            //var gRPCBenchmark = new gRPCBenchmark();
            //await gRPCBenchmark.Execute(LoogCount);
        }
    }
}
