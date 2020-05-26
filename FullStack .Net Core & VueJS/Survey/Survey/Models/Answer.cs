using System;
using Newtonsoft.Json;

namespace Survey
{
    public class Answer
    {
        [JsonProperty("id")] public long Id { get; set; } = new Random().Next();

        [JsonProperty("answer")]
        public string answer { get; set; }
    }
}