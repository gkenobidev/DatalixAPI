using Newtonsoft.Json;

using System;

namespace DatalixAPI.Models
{
    public class Cron
    {
        [JsonProperty("action")]
        public string Action { get; set; }
        
        [JsonProperty("displayname")]
        public string Name { get; set; }

        [JsonProperty("expression")]
        public string Expression { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("kvmid")]
        public string KVMId { get; set; }

        [JsonProperty("created_on")]
        public string CreatedAtTimestamp { get; set; }

        [JsonProperty("nextexecute")]
        public string NextExecutionTimestamp { get; set; }

        [JsonProperty("status")]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsActive { get => StatusCode is 1; }

        [JsonIgnore]
        public DateTime CreatedAt { get => DateTime.Parse(CreatedAtTimestamp); }

        [JsonIgnore]
        public DateTime NextExecutionAt { get => DateTime.Parse(NextExecutionTimestamp); }
    }
}
