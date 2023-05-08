using DatalixAPI.Enums;
using DatalixAPI.Models;
using DatalixAPI.Utils;

using Newtonsoft.Json.Linq;

using System.Collections.Generic;
using System.Threading.Tasks;

using OperatingSystem = DatalixAPI.Models.OperatingSystem;

namespace DatalixAPI
{
    public class DatalixApiService
    {
        public HttpUtils Http { get; }

        public DatalixApiService(string apiToken)
        {
            Http = new HttpUtils()
            {
                ApiToken = apiToken
            };
        }

        public async Task<HashSet<ServiceInfo>> GetServicesAsync()
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/list");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<HashSet<ServiceInfo>>();
        }

        public async Task<Service> GetServiceAsync(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<Service>();
        }

        public async Task<Status?> GetServiceStatus(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/status");

            if (result is null || !result.Success)
                return null;

            if (!result.Object.TryGetValue("status", out var statusToken))
                return null;

            if (!ApiResult.TryGetStatusId(statusToken.Value<string>(), out var statusId))
                return null;

            return statusId;
        }

        public async Task<HashSet<OperatingSystem>> GetOperatingSystems(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/os");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<HashSet<OperatingSystem>>();
        }

        public async Task<IpAddress> GetIpAddressAsync(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/ip");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<IpAddress>();
        }

        public async Task<HashSet<Backup>> GetBackupsAsync(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/backup");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<HashSet<Backup>>();
        }

        public async Task<HashSet<Cron>> GetCronsAsync(string serviceId)
        {
            var result = await Http.GetAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/cron");

            if (result is null || !result.Success)
                return null;

            return result.Deserialize<HashSet<Cron>>();
        }

        public async Task<bool> CreateBackupAsync(string serviceId)
        {
            return (await Http.PostAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/backup", string.Empty))?.Success ?? false;
        }

        public async Task<bool> CreateCronAsync(string serviceId, string name, string action, string expression)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/cron", 
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("action", action),
                new KeyValuePair<string, string>("expression", expression))
                                                )?.Success ?? false; 
        }

        public async Task<bool> CreateCronAsync(string serviceId, string cronId, string name, string action, string expression)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/cron/{cronId}",
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("action", action),
                new KeyValuePair<string, string>("expression", expression))
                                                )?.Success ?? false;
        }

        public async Task<bool> DeleteCronAsync(string serviceId, string cronId)
        {
            return (await Http.DeleteAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/cron/{cronId}/delete"))?.Success ?? false;
        }

        public async Task<bool> DeleteBackupAsync(string serviceId, string backupId)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/backup/delete", 
                new KeyValuePair<string, string>("backup", backupId)))?.Success ?? false;
        }

        public async Task<bool> RestoreBackupAsync(string serviceId, string backupId)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/backup/restore", 
                new KeyValuePair<string, string>("backup", backupId)))?.Success ?? false;
        }

        public async Task<bool> StopAsync(string serviceId)
        {
            return (await Http.PostAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/stop", string.Empty))?.Success ?? false;
        }

        public async Task<bool> StartAsync(string serviceId)
        {
            return (await Http.PostAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/start", string.Empty))?.Success ?? false;
        }

        public async Task<bool> ShutdownAsync(string serviceId)
        {
            return (await Http.PostAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/shutdown", string.Empty))?.Success ?? false;
        }

        public async Task<bool> ReinstallAsync(string serviceId, string operatingSystem)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/reinstall", 
                new KeyValuePair<string, string>("OS", operatingSystem)))?.Success ?? false;
        }

        public async Task<bool> ExtendAsync(string serviceId, int days, int credit)
        {
            return (await Http.PostMultiPartAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/extend",
                new KeyValuePair<string, string>("days", days.ToString()),
                new KeyValuePair<string, string>("credit", credit.ToString()))
                   )?.Success ?? false;
        }

        public async Task<bool> HideAsync(string serviceId)
        {
            return (await Http.PostAsync($"{HttpUtils.ServiceUrlBase}/{serviceId}/hide", string.Empty))?.Success ?? false;
        }
    }
}