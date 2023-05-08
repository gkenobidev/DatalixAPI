using DatalixAPI.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System;

namespace DatalixAPI.Utils
{
    public class ApiResult
    {
        public bool Success { get; }

        public string Error { get; }
        public string Json { get; }

        public JObject Object { get; }

        public ApiResult(string json)
        {
            Json = json;
            Object = JsonConvert.DeserializeObject<JObject>(Json);

            if (Object.ContainsKey("error"))
            {
                Success = false;
                Error = Object.GetValue("error")?.Value<string>() ?? "unknown";
            }    
            else
            {
                Success = true;
            }
        }

        public T Deserialize<T>()
        {
            if (!Success)
            {
                throw new InvalidOperationException("Cannot deserialize an unsuccesfull response.");
            }

            return JsonConvert.DeserializeObject<T>(Json);
        }

        public static bool TryGetStatusId(string statusId, out Status result)
        {
            switch (statusId)
            {
                case "preorder":
                    result = Status.AwaítingDeployment;
                    return true;

                case "createbackup":
                    result = Status.CreatingBackup;
                    return true;

                case "restorebackup":
                    result = Status.RestoringBackup;
                    return true;

                case "backupplanned":
                    result = Status.PlannedBackup;
                    return true;

                case "restoreplanned":
                    result = Status.PlannedBackup;
                    return true;

                default:
                    return Enum.TryParse(statusId, true, out result);
            }
        }
    }
}
