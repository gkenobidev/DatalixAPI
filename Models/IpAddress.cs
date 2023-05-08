using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class IpAddress
    {
        [JsonProperty("ipv4")]
        public IpV4Address IpV4Address { get; set; }

        [JsonProperty("ipv6")]
        public IpV6Address IpV6Address { get; set; }
    }
}