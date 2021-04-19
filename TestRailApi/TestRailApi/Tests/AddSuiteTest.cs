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
    public class AddSuiteTest : BaseTest
    {
        private const string RequestType = "Post";

        private ModelResponseSteps<SuiteResponseModel> _suiteResponseSteps;
        
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _suiteResponseSteps = new ModelResponseSteps<SuiteResponseModel>();

            var projectResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var response = projectResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, RequestType, TestData.User, TestData.Project).Result;

            ProjectId = response.Data.Id;
        }
        
        [Test]
        public void AddSuit_ValidSuit_ShouldReturnOk()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType, TestData.User, TestData.Suite).Result;

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(TestData.Suite.Name, response.Data.Name);
                Assert.AreEqual(TestData.Suite.Description, response.Data.Description);
                Assert.AreEqual(false, response.Data.IsMaster);
                Assert.AreEqual(false, response.Data.IsBaseline);
                Assert.AreEqual(false, response.Data.IsCompleted);
                Assert.AreEqual(null, response.Data.CompletedOn);
                Assert.IsFalse(response.Data.Id.Equals(null));
                Assert.AreEqual(ProjectId, response.Data.ProjectId);
                Assert.IsTrue(Uri.IsWellFormedUriString(response.Data.Url, UriKind.Absolute));
            });
        }
        
        [Test]
        public void AddSuit_NonExistentProject_ShouldReturnBadRequest()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + FakeProjectId, RequestType, TestData.User, TestData.Suite).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void AddSuit_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType, TestData.UserNoAccess, TestData.User).Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
        
        [Test]
        public void AddSuit_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType, TestData.FakeUser, TestData.User).Result;

            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        [Test]
        public void AddSuite_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + InvalidId, RequestType, TestData.User, TestData.Suite).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void AddSuite_SuiteWithoutName_ShouldReturnBadRequest()
        {
            var expectedProject = ModelGeneratorHelper.GetSuiteWithoutName(TestData.Suite);
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType,
                TestData.User, expectedProject).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void AddSuite_SuiteWithoutDescription_ShouldReturnOk()
        {
            var expectedProject = ModelGeneratorHelper.GetSuiteWithoutDescription(TestData.Suite);
            var response = _suiteResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType,
                TestData.User, expectedProject).Result;

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}