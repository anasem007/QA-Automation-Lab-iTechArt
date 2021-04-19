
namespace TestRailApi.Models
{
    public class Request
    {
        public string Uri { get; set; }
        public string HttpMethod { get; set; }
        public object Body { get; set; }
    }
}