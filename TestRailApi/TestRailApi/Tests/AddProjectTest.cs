using System;
using System.Net;
using NUnit.Framework;
using TestRailApi.BaseEntities;
using TestRailApi.Constants;
using TestRailApi.Helpers;
using TestRailApi.Models;
using TestRailApi.Steps;

namespace TestRailApi.Tests
{
    public class AddProjectTest : BaseTest
    {
        private const string RequestType = "Post";

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;

        [SetUp]
        public void SetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
        }

        [Test]
        public void AddProject_ExistentProject_ShouldReturnOk()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint,
                RequestType, TestData.User, TestData.Project).Result;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(TestData.Project.Name, response.Data.Name);
                Assert.AreEqual(TestData.Project.Announcement, response.Data.Announcement);
                Assert.AreEqual(TestData.Project.ShowAnnouncement, response.Data.ShowAnnouncement); //в запросе ShowAnnouncement = true, при ответе = false
                Assert.AreEqual(TestData.Project.SuiteMode, response.Data.SuiteMode); //выбирает 3, хотя по идее 2
                Assert.AreEqual(null, response.Data.CompletedOn); // в документации пример response при IsCompleted = false, CompletedOn = null
                Assert.AreEqual(false, response.Data.IsCompleted);
                Assert.AreEqual(response.Data.Id.GetType(), typeof(int));
                Assert.IsFalse(response.Data.Id.Equals(null));
                Assert.IsTrue(Uri.IsWellFormedUriString(response.Data.Url, UriKind.Absolute));
            });
        }

        [Test]
        public void AddProject_ProjectWithoutName_ShouldReturnBadRequest()
        {
            
            var expectedProject = ModelGeneratorHelper.GetProjectWithoutName(TestData.Project);
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType,
                TestData.User, expectedProject).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void AddProject_ProjectWithoutAnnouncement_ShouldReturnOk()
        {
            var expectedProject = ModelGeneratorHelper.GetProjectWithoutAnnouncement(TestData.Project);
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType, 
                TestData.User, expectedProject).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void AddProject_ProjectWithoutSuiteMode_ShouldReturnBadRequest()
        {
            var expectedProject = ModelGeneratorHelper.GetProjectWithoutSuiteMode(TestData.Project);
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType, 
                TestData.User, expectedProject).Result;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(1, response.Data.SuiteMode);
            });
        }
        

        [Test]
        public void AddProject_ProjectWithoutShowAnnouncement_ShouldReturnOk()
        {
            var expectedProject = ModelGeneratorHelper.GetProjectWithoutShowAnnouncement(TestData.Project);
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType,
                TestData.User, expectedProject).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Test]
        public void AddProject_ProjectWithInvalidSuiteMode_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType, 
                TestData.User, TestData.InvalidProject).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void AddProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, 
                RequestType, TestData.UserNoAccess, TestData.Project).Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
        
        [Test]
        public void AddProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType,
                TestData.FakeUser).Result;
            
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}