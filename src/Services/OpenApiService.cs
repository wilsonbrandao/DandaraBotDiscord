using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FluentResults;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace botDiscord.src.Services
{
    public class OpenApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _HttpClient;

        public OpenApiService(IConfiguration configuration, HttpClient client)
        {
            _HttpClient = client;
            _configuration = configuration;
        }

        public async Task<Result> Request(string prompText)
        {
            var content = JsonConvert.SerializeObject(new
            {
                model = "text-davinci-003",
                prompt = prompText,
                max_tokens = 2048,
                temperature = 0
            });

            string token = _configuration.GetSection("OpenAi")["TokenOpenAI"];

            using (var httpRequestMessage = new HttpRequestMessage())
            {
                httpRequestMessage.Method = HttpMethod.Post;
                httpRequestMessage.RequestUri = new Uri("https://api.openai.com/v1/completions");
                httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                httpRequestMessage.Content = new StringContent(content);
                httpRequestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await _HttpClient.SendAsync(httpRequestMessage);
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return Result.Ok().WithSuccess(body);
            }
        }
    }
}