using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class IpV4Address
    {
        [JsonProperty("gw")]
        public string Gateway { get; set; }

        [JsonProperty("ip")]
        public string Address { get; set; }

        [JsonProperty("netmask")]
        public string NetMask { get; set; }

        [JsonProperty("rdns")]
        public string ReverseDNS { get; set; }

        [JsonProperty("subnetid")]
        public int SubnetId { get; set; }
    }
}