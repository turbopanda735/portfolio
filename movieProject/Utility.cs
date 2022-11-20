using Google.Protobuf.WellKnownTypes;
using Newtonsoft.Json.Linq;
using System.Security.Policy;

namespace movieProject
{
    //public static class Utility
    //{
    //    public static async JObject ApiResponse(string url)
    //    {
    //        var client = new HttpClient();
    //        var apiResponse = client.GetStringAsync(url).Result;
    //        return JObject.Parse(apiResponse);
    //    }
    //}
    public static class Application
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static async Task<JObject> ApiTask(string url)
        {
            var apiResponse = await _httpClient.GetStringAsync(url);
            return JObject.Parse(apiResponse);
        }
        public static JObject ApiResponse(Task<JObject> apiResponse)
        {
            return apiResponse.Result;
        }
    }
}
