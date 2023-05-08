using Newtonsoft.Json;
using System;

namespace DatalixAPI.Models
{
    public class Backup
    {
        [JsonProperty("backupname")]
        public string Name { get; set; }

        [JsonProperty("displayname")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("proxmoxid")]
        public string ProxMoxId { get; set; }

        [JsonProperty("created_on")]
        public long CreatedAtTimestamp { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get => new DateTime(CreatedAtTimestamp); }
    }
}