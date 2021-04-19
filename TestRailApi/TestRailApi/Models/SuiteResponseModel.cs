using System;

namespace TestRailApi.Models
{
    public class SuiteResponseModel
    {
        public string Description { get; set; }
        public DateTime CompletedOn { get; set; }
        public int Id { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsBaseline { get; set; }
        public bool IsMaster { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public string Url { get; set; }
    }
}