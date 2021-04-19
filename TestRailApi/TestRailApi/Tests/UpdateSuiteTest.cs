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
    public class UpdateSuiteTest : BaseTest
    {
        private const string RequestType = "Post";
        private int SuiteId = -1;
        
        private ModelResponseSteps<SuiteResponseModel> _modelResponseSteps;

        [OneTimeSetUp]
        public void SetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<SuiteResponseModel>();

            var projectResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            var projectResponse = projectResponseSteps
                .CreateResponse(EndPoints.AddProjectEndPoint, "Post", TestData.User, TestData.Project).Result;
            ProjectId = projectResponse.Data.Id;
            
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddSuiteEndPoint + ProjectId, RequestType, TestData.User, TestData.Suite).Result;
            SuiteId = response.Data.Id;
        }
        
        [Test]
        public void UpdateSuit_ValidSuit_ShouldReturnOk()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, RequestType, TestData.User, TestData.UpdateSuite).Result;

            Console.Out.WriteLine("response Project id: " + response.Data.ProjectId);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(TestData.UpdateSuite.Name, response.Data.Name);
                Assert.AreEqual(TestData.UpdateSuite.Description, response.Data.Description);
                Assert.AreEqual(false, response.Data.IsMaster);
                Assert.AreEqual(false, response.Data.IsBaseline);
                Assert.AreEqual(false, response.Data.IsCompleted);
                Assert.AreEqual(null, response.Data.CompletedOn);
                Assert.AreEqual(ProjectId, response.Data.ProjectId);
                Assert.AreEqual(SuiteId, response.Data.Id);
                Assert.IsTrue(Uri.IsWellFormedUriString(response.Data.Url, UriKind.Absolute));
            });
        }
        
        [Test]
        public void UpdateSuite_InvalidSuiteId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + InvalidId, RequestType, TestData.User, TestData.Suite).Result;

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void UpdateSuite_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, RequestType, TestData.UserNoAccess, TestData.UpdateSuite).Result;

            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
        
        [Test]
        public void UpdateSuite_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, RequestType, TestData.FakeUser, TestData.UpdateSuite).Result;
            
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        public void UpdateSuite_RequestWithoutName_ShouldReturnOk()
        {
            var expectedResult = ModelGeneratorHelper.GetSuiteWithoutName(TestData.UpdateSuite);
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, RequestType, TestData.User, expectedResult).Result;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
                Assert.AreEqual(TestData.Suite.Name, response.Data.Name);
                Assert.AreEqual(expectedResult.Description, response.Data.Description);
            });
        }
        
        public void UpdateSuite_RequestWithoutDescription_ShouldReturnOk()
        {
            var expectedResult = ModelGeneratorHelper.GetSuiteWithoutDescription(TestData.UpdateSuite);
            var response = _modelResponseSteps.CreateResponse(EndPoints.UpdateSuiteEndPoint + SuiteId, RequestType, TestData.User, expectedResult).Result;
            
            Assert.Multiple(() =>
            {
                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
                Assert.AreEqual(TestData.Suite.Description, response.Data.Description);
                Assert.AreEqual(expectedResult.Name, response.Data.Name);
            });
        }
    }
}