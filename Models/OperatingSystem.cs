using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class OperatingSystem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("proxmoxid")]
        public int ProxMoxId { get; set; }
    }
}
