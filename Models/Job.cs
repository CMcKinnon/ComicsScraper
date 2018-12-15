using ComicsScraper.Constants;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace ComicsScraper.Models
{
    [Serializable, JsonObject]
    public class Job
    {
        [JsonProperty("job_id")]
        public string JobId { get; set; }
        [JsonProperty("status"), JsonConverter(typeof(StringEnumConverter))]
        public JobStatus Status { get; set; }
        [JsonProperty("created")]
        public DateTime Created { get; set; }
        [JsonProperty("percent__complete")]
        public int PercentComplete { get; set; }
    }
}
