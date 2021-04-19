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
    public class GetProjectTest : BaseTest
    {
        private const string RequestType = "Get";

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;

        [OneTimeSetUp]
        public new void OneTimeSetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, "Post", TestData.User, TestData.Project).Result;

            ProjectId = response.Data.Id;
        }

        [Test]
        public void GetProject_ExistentProject_ShouldReturnOk()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, RequestType, TestData.User).Result;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(TestData.Project.Name, response.Data.Name);
                Assert.AreEqual(TestData.Project.Announcement, response.Data.Announcement);
                Assert.AreEqual(TestData.Project.ShowAnnouncement, response.Data.ShowAnnouncement); //в запросе ShowAnnouncement = true, при ответе =false
                Assert.AreEqual(TestData.Project.SuiteMode, response.Data.SuiteMode); //выбирает 3, хотя по идее должно быть либо обязательный параметр, либо 1
                Assert.AreEqual(null, response.Data.CompletedOn); // в документации пример response при IsCompleted = false, CompletedOn = null
                Assert.AreEqual(false, response.Data.IsCompleted);
                Assert.AreEqual(ProjectId, response.Data.Id);
                Assert.IsTrue(Uri.IsWellFormedUriString(response.Data.Url, UriKind.Absolute));
            });
        }

        [Test]
        public void GetProject_ProjectWithFakeId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + FakeProjectId, RequestType, TestData.User).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void GetProject_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.GetProjectEndPoint + InvalidId, RequestType, TestData.User).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Test]
        public void GetProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps
                .CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, RequestType, TestData.UserNoAccess).Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
        
        [Test]
        public void GetProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.GetProjectEndPoint + ProjectId, RequestType, TestData.FakeUser).Result;
            
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
    }
}