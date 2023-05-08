using DatalixAPI.Enums;

using Newtonsoft.Json;

using System;

namespace DatalixAPI.Models
{
    public class Product
    {
        [JsonProperty("additionaltraffic")]
        public double AdditionalTraffic { get; set; }

        [JsonProperty("proxmoxid")]
        public int ProxMoxId { get; set; }

        [JsonProperty("cores")]
        public int Cores { get; set; }

        [JsonProperty("disk")]
        public int DiskSize { get; set; }

        [JsonProperty("memory")]
        public int MemorySize { get; set; }

        [JsonProperty("uplink")]
        public int Uplink { get; set; }

        [JsonProperty("created_on")]
        public string CreatedAtTimestamp { get; set; }

        [JsonProperty("hostname")]
        public string HostName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mac")]
        public string MacAddress { get; set; }

        [JsonProperty("nodeid")]
        public string NodeId { get; set; }

        [JsonProperty("os")]
        public string OsId { get; set; }

        [JsonProperty("packet")]
        public string PacketId { get; set; }

        [JsonProperty("serviceid")]
        public string ServiceId { get; set; }

        [JsonProperty("status")]
        public string StatusId { get; set; }

        [JsonIgnore]
        public Status Status
        {
            get
            {
                switch (StatusId)
                {
                    case "running":
                        return Status.Running;

                    default:
                        throw new NotImplementedException($"Unknown Status ID: {StatusId}");
                }
            }
        }
    }
}
