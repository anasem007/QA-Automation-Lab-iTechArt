using RestSharp;
using TestRailApi.Helpers;
using TestRailApi.Models;

namespace TestRailApi.Steps
{
    public class ModelResponseSteps<T>
    {
        public  IRestResponse<T> CreateResponse(string endPoint, string requestType,
            User user, object model = null)
        {
            var request = new Request
            {
                Uri = endPoint,
                HttpMethod = requestType,
                Body = model
            };
            
            var client = ClientHelper.GetClient(user);
            return ClientHelper.GetResponse<T>(client, request).Result;
        }
    }
}