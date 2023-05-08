using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class Display
    {
        [JsonProperty("backup")]
        public bool IsBackup { get; set; }

        [JsonProperty("cron")]
        public bool IsCron { get; set; }

        [JsonProperty("hardware")]
        public bool IsHardware { get; set; }

        [JsonProperty("ip")]
        public bool IsIP { get; set; }

        [JsonProperty("livedata")]
        public bool IsLiveData { get; set; }

        [JsonProperty("novnc")]
        public bool IsNoVNC { get; set; }

        [JsonProperty("traffic")]
        public bool IsTraffic { get; set; }
    }
}