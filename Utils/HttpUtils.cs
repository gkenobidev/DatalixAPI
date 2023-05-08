using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DatalixAPI.Utils
{
    public  class HttpUtils
    {
        public const string DatalixUrlBase = "https://backend.datalix.de/v1";
        public const string ServiceUrlBase = DatalixUrlBase + "/service";

        public string ApiToken { get; set; }

        public async Task<ApiResult> GetAsync(string url)
            => await DoAsync(url, "GET");

        public async Task<ApiResult> PostAsync(string url, string content)
            => await DoAsync(url, "POST", content);

        public async Task<ApiResult> DeleteAsync(string url)
            => await DoAsync(url, "DELETE");

        public async Task<ApiResult> PostMultiPartAsync(string url, params KeyValuePair<string, string>[] content)
        {
            url += $"?token={ApiToken}";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Post, url))
            {
                var multipartFormDataContent = new MultipartFormDataContent();

                foreach (var part in content)
                {
                    multipartFormDataContent.Add(new StringContent(part.Value), part.Key);
                }

                request.Content = multipartFormDataContent;

                using (var response = await client.SendAsync(request))
                {
                    if (response.Content != null)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(responseJson))
                        {
                            return new ApiResult(responseJson);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<ApiResult> DoAsync(string url, string method, string content = null)
        {
            method = method.ToLower();
            url += $"?token={ApiToken}";

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.RequestUri = new Uri(url);

                switch (method)
                {
                    case "get":
                        request.Method = HttpMethod.Get;
                        break;

                    case "post":
                        request.Method = HttpMethod.Post;
                        request.Content = new StringContent(content);
                        break;

                    case "delete":
                        request.Method = HttpMethod.Delete;
                        break;

                    default:
                        throw new ArgumentException("Invalid HTTP method.");
                }

                using (var response = await client.SendAsync(request))
                {
                    if (response.Content != null)
                    {
                        var responseJson = await response.Content.ReadAsStringAsync();

                        if (!string.IsNullOrWhiteSpace(responseJson))
                        {
                            return new ApiResult(responseJson);
                        }
                    }
                }
            }

            return null;
        }
    }
}