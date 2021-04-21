using System.IO;
using System.Reflection;
using System.Text.Json;
using TestRailApi.Models;

namespace TestRailApi.Helpers
{
    public static class TestData
    {
        
        private const string ProjectFileName = "projectRequestModel";
        private const string UserNoAccessFileName = "userNoAccess";
        private const string SuiteFileName = "suite";
        private const string FakeUserFileName = "fakeUser";
        private const string UserFileName = "user";
        private const string InvalidProjectFileName = "invalidProject";
        private const string UpdateSuiteFileName = "updateSuite";
        
        public static ProjectRequestModel Project => GenerateModel<ProjectRequestModel>(ProjectFileName);
        public static ProjectRequestModel InvalidProject => GenerateModel<ProjectRequestModel>(InvalidProjectFileName);
        public static User User => GenerateModel<User>(UserFileName);
        public static User UserNoAccess => GenerateModel<User>(UserNoAccessFileName);
        public static User FakeUser => GenerateModel<User>(FakeUserFileName);
        public static SuiteRequestModel Suite => GenerateModel<SuiteRequestModel>(SuiteFileName);
        public static SuiteRequestModel UpdateSuite => GenerateModel<SuiteRequestModel>(UpdateSuiteFileName);
        
        private static T GenerateModel<T>(string name)
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fullPathToFile = Path.Combine(basePath ?? string.Empty, $"TestData{Path.DirectorySeparatorChar}", $@"{name}.json");

            var jsonSerializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            var jsonStream = File.ReadAllText(fullPathToFile);
            
            return JsonSerializer.Deserialize<T>(jsonStream);
        }
    }
}