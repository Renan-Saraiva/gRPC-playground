using Proto.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Client.Benchmark
{
    public class RestBenchmark
    {
        private readonly HttpClient _httpClient;

        public RestBenchmark()
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

        public async Task<HelloResponseDto> ExecuteLarge()
        {
            var response = await _httpClient.PostAsJsonAsync("greeter/large-say-hello", new HelloRequestDto
            {
                Name = $"Client"
            });

            return await response.Content.ReadFromJsonAsync<HelloResponseDto>();
        }

        public async Task<MultipleFields> ExecuteMultipleFields()
        {
            var response = await _httpClient.PostAsJsonAsync("greeter/multiple-fields", CreateMultipleFields());
            return await response.Content.ReadFromJsonAsync<MultipleFields>();
        }

        public async Task<IList<MultipleFields>> ExecuteMultipleFieldsList()
        {
            var response = await _httpClient.PostAsJsonAsync("greeter/multiple-fields-list", CreateMultipleFieldsList());

            return await response.Content.ReadFromJsonAsync<List<MultipleFields>>();
        }

        private IEnumerable<MultipleFields> CreateMultipleFieldsList()
            => Enumerable.Repeat<MultipleFields>(CreateMultipleFields(), Constraints.ListCount);

        private MultipleFields CreateMultipleFields()
            => new MultipleFields
            {
                Prop1 = "teste---",
                Prop2 = 780784,
                Prop3 = "teste---",
                Prop4 = "teste---",
                Prop5 = "teste---",
                Prop6 = "teste---",
                Prop7 = "teste---",
                Prop8 = 878048040,
                Prop9 = "teste---",
                Prop10 = "teste---"
            };

        ~RestBenchmark()
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

    public class MultipleFields
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
        public string Prop3 { get; set; }
        public string Prop4 { get; set; }
        public string Prop5 { get; set; }
        public string Prop6 { get; set; }
        public string Prop7 { get; set; }
        public int Prop8 { get; set; }
        public string Prop9 { get; set; }
        public string Prop10 { get; set; }
    }
}
