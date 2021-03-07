using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Benchmark
{
    public class APIBenchmark
    {
        private readonly HttpClient _httpClient;

        public APIBenchmark()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:4999/");
        }

        public async Task<HelloResponseDto> Execute()
        {
            var response = await _httpClient.PostAsJsonAsync("greeter/say-hello", new HelloRequestDto {
                Name = $"Client"
            });

            return await response.Content.ReadFromJsonAsync<HelloResponseDto>();
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
