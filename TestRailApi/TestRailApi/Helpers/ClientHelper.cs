using System;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using TestRailApi.Constants;
using TestRailApi.Models;
using TestRailApi.Services;
using TestRailApi.Utils;

namespace TestRailApi.Helpers
{
    public static class ClientHelper
    {
        public static RestClient GetClient(User user)
        {
            return new RestClient(Configurator.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(user.Username, user.Password)
            };
        }
        
        public static async Task<IRestResponse<T>> GetResponse<T>(RestClient client, Request req)
        {
            var request = req.HttpMethod switch
            {
                RequestType.Get => new RestRequest(req.Uri, Method.GET),
                RequestType.Delete => new RestRequest(req.Uri, Method.DELETE),
                RequestType.Post => new RestRequest(req.Uri, Method.POST),
                RequestType.Put => new RestRequest(req.Uri, Method.PUT),
                RequestType.Patch => new RestRequest(req.Uri, Method.PUT),
                _ => throw new NotImplementedException($"Request type: {req.HttpMethod} is not implemented.")
            };

            if (req.HttpMethod != "Get" || req.HttpMethod != "Delete")
            {
                request.AddJsonBody(Serializer.Serialize(req.Body));
            }

            return await client.ExecuteAsync<T>(request);
        }
        
    }
}