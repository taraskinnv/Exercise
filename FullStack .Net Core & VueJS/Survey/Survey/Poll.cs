using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Survey
{
    public class Poll
    {
        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("answers")]
        public List<Answer> Answers { get; set; }
    }
}
