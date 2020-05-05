using Newtonsoft.Json;

namespace Survey
{
    public class Answer
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("answer")]
        public string AnswerAnswer { get; set; }
    }
}