using Newtonsoft.Json;
using System;

namespace DatalixAPI.Models
{
    public class ServiceInfo
    {
        private DateTime? _createdAt;
        private DateTime? _deleteAt;
        private DateTime? _deleteDoneAt;
        private DateTime? _expiresAt;

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("productdisplay")]
        public string Display { get; set; }

        [JsonProperty("created_on")]
        public long CreationTimestamp { get; set; }

        [JsonProperty("delete_at")]
        public long DeletionTimestamp { get; set; }

        [JsonProperty("deletedone")]
        public long DeletionDoneTimestamp { get; set; }

        [JsonProperty("expire_at")]
        public long ExpirationTimestamp { get; set; }

        [JsonProperty("preorder")]
        public int PreorderStatus { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonIgnore]
        public bool IsPreorder { get => PreorderStatus == 0; }

        [JsonIgnore]
        public DateTime CreatedAt
        {
            get
            {
                if (!_createdAt.HasValue)
                    _createdAt = new DateTime(CreationTimestamp);

                return _createdAt.Value;
            }
        }

        [JsonIgnore]
        public DateTime DeleteAt
        {
            get
            {
                if (!_deleteAt.HasValue)
                    _deleteAt = new DateTime(DeletionTimestamp);

                return _deleteAt.Value;
            }
        }

        [JsonIgnore]
        public DateTime DeleteDoneAt
        {
            get
            {
                if (!_deleteDoneAt.HasValue)
                    _deleteDoneAt = new DateTime(DeletionDoneTimestamp);

                return _deleteDoneAt.Value;
            }
        }

        [JsonIgnore]
        public DateTime ExpiresAt
        {
            get
            {
                if (!_expiresAt.HasValue)
                    _expiresAt = new DateTime(ExpirationTimestamp);

                return _expiresAt.Value;
            }
        }
    }
}