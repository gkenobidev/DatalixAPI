using Newtonsoft.Json;

namespace DatalixAPI.Models
{
    public class Service
    {
        [JsonProperty("display")]
        public Display Display { get; set; }

        [JsonProperty("product")]
        public Product Product { get; set; }

        [JsonProperty("service")]
        public ServiceInfo Info { get; set; }
    }
}