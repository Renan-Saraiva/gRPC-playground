using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace Client
{
    public class APIBenchmark
    {
        private readonly HttpClient _httpClient;

        public APIBenchmark()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:5001");
        }        

        public async Task Execute(int loopCount)
        {
            for(int count = 0; count <= loopCount; count++)
            {
                var response = await _httpClient.PostAsJsonAsync("/greeter/say-hello", new HelloRequestDto {
                    Name = "Client"
                });

                Console.WriteLine((await response.Content.ReadFromJsonAsync<HelloResponseDto>()).Message);
            }
        }

        ~APIBenchmark()
        {
            _httpClient.Dispose();
        }
    }

    public class HelloRequestDto
    {
        public string Name { get; set; }
    }

    public class HelloResponseDto
    {
        public string Message { get; set; }
    }
}
