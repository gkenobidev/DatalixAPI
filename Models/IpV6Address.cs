using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class IpV6Address
    {
        [JsonProperty("firstip")]
        public string FirstIp { get; set; }

        [JsonProperty("gw")]
        public string Gateway { get; set; }

        [JsonProperty("netmask")]
        public string NetMask { get; set; }

        [JsonProperty("subnet")]
        public string SubNet { get; set; }

        [JsonProperty("subnetid")]
        public int SubnetId { get; set; }
    }
}