using TestRailApi.Models;

namespace TestRailApi.Helpers
{
    public static class ModelGeneratorHelper
    {
        public static ProjectRequestModel GetProjectWithoutName(ProjectRequestModel project)
        {
            return new ProjectRequestModel
            {
                Announcement = project.Announcement,
                ShowAnnouncement = project.ShowAnnouncement,
                SuiteMode = project.SuiteMode
            };
        }

        public static ProjectRequestModel GetProjectWithoutAnnouncement(ProjectRequestModel project)
        {
            return new ProjectRequestModel
            {
                Name = project.Name,
                ShowAnnouncement = project.ShowAnnouncement,
                SuiteMode = project.SuiteMode
            };
        }

        public static ProjectRequestModel GetProjectWithoutShowAnnouncement(ProjectRequestModel project)
        {
            return new ProjectRequestModel
            {
                Name = project.Name,
                Announcement = project.Announcement,
                SuiteMode = project.SuiteMode
            };
        }
        
        public static ProjectRequestModel GetProjectWithoutSuiteMode(ProjectRequestModel project)
        {
            return new ProjectRequestModel
            {
                Name = project.Name,
                Announcement = project.Announcement,
                ShowAnnouncement = project.ShowAnnouncement
            };
        }
        
        public static SuiteRequestModel GetSuiteWithoutName(SuiteRequestModel suite)
        {
            return new SuiteRequestModel
            {
                Description = suite.Description
            };
        }
        
        public static SuiteRequestModel GetSuiteWithoutDescription(SuiteRequestModel suite)
        {
            return new SuiteRequestModel
            {
                Name = suite.Name
            };
        }
    }
}