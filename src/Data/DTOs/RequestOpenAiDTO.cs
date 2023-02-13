using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace botDiscord.src.Data.DTOs
{
    public class RequestOpenAiDTO
    {
        public string model { get; } = "text-davinci-003";
        public string prompt { get; private set; }
        public int max_tokens { get; } = 2048;
        public double temperature { get; } = 0;

        public string PostRequest(string promptText)
        {
            prompt = promptText;
            return JsonConvert.SerializeObject(this);
        }

    }
}