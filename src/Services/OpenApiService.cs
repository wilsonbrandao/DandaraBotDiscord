using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using FluentResults;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using botDiscord.src.Data.DTOs;

namespace botDiscord.src.Services
{
    public class OpenApiService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _HttpClient;
        private readonly RequestOpenAiDTO _requestContent;

        public OpenApiService(IConfiguration configuration, HttpClient client, RequestOpenAiDTO requestContent)
        {
            _configuration = configuration;
            _HttpClient = client;
            _requestContent = requestContent;
        }

        public async Task<Result> Request(string prompText)
        {
            var content = _requestContent.PostRequest(prompText);
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

                var deserializeResponse = JsonConvert.DeserializeObject<Temperatures>(body);

                return Result.Ok().WithSuccess(deserializeResponse.Choices[0].Text);
            }
        }
    }
}