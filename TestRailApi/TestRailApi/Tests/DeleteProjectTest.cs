using System.Net;
using NUnit.Framework;
using TestRailApi.BaseEntities;
using TestRailApi.Constants;
using TestRailApi.Helpers;
using TestRailApi.Models;
using TestRailApi.Steps;

namespace TestRailApi.Tests
{
    public class DeleteProjectTest : BaseTest
    {
        private const string RequestType = "Post";

        private ModelResponseSteps<ProjectResponseModel> _modelResponseSteps;
        

        [SetUp]
        public void SetUp()
        {
            _modelResponseSteps = new ModelResponseSteps<ProjectResponseModel>();
            
            var response = _modelResponseSteps.CreateResponse(EndPoints.AddProjectEndPoint, "Post", TestData.User, TestData.Project).Result;

            ProjectId = response.Data.Id;
        }

        [Test]
        public void DeleteProject_ExistentProject_ShouldReturnOk()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId, RequestType, TestData.User).Result;
            
            Assert.Multiple(() =>
            { 
                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode); 
                Assert.AreEqual(null, response.Data);
            });
        }

        [Test]
        public void DeleteProject_NonExistentProject_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + FakeProjectId, RequestType, TestData.User).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
        [Test]
        public void DeleteProject_UserNoAccess_ShouldReturnForbidden()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId, RequestType, TestData.UserNoAccess).Result;
            
            Assert.AreEqual(HttpStatusCode.Forbidden, response.StatusCode);
        }
        
        [Test]
        public void DeleteProject_UnauthorizedUser_ShouldReturnUnauthorized()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + ProjectId, RequestType, TestData.FakeUser).Result;
            
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        
        [Test]
        public void DeleteProject_InvalidProjectId_ShouldReturnBadRequest()
        {
            var response = _modelResponseSteps.CreateResponse(EndPoints.DeleteProjectEndPoint + InvalidId, RequestType, TestData.User).Result;
            
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}