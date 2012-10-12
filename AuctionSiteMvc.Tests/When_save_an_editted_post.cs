using System;
using AuctionSiteMvc.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AuctionSiteMvc.Persistent;
using System.Web.Mvc;
using AuctionSiteMvc.Domain;
using Rhino.Mocks;
using SharpTestsEx;

namespace AuctionSiteMvc.Tests
{
    /// <summary>
    ///This is a test case for testing post controller http get Edit function
    ///</summary>
    [TestClass()]
    public class When_save_an_editted_post
    {
        private static IPostRepository _repository;
        private static PostController Sut { get; set; }
        protected static RedirectToRouteResult Result { get; set; }
        protected static int postId { get; set; }
        protected static Post ModelToSave { get; set; }
        protected static Post ExpectedModel { get; set; }

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            // generate a mock repository
            _repository = MockRepository.GenerateStub<IPostRepository>();

            // the subject under test
            Sut = new PostController(_repository);

            // a random id to test
            postId = new Random().Next();

            // set a dumy post 
            ModelToSave = new Post(postId, "", "", "", DateTime.Now, DateTime.MinValue);

            ExpectedModel = new Post(postId, "saved", "", "", DateTime.Now, DateTime.MinValue);


            // stub the repo to return a post when it is called GetById with a id is PostId
            _repository.Stub(repo => repo.Save(ModelToSave)).Return(ExpectedModel);


            // the result returned by calling Edit to the controller
            Result = Sut.Edit(ModelToSave);
        }


        [TestMethod()]
        public void It_should_call_repository_save()
        {
            _repository.AssertWasCalled(repo => repo.Save(ModelToSave)); 
        }

        [TestMethod()]
        public void It_should_redirect_to_details()
        {
            Result.RouteValues["action"].Should().Be("Details");
        }        
        
        [TestMethod()]
        public void It_should_reture_to_details_for_correct_post()
        {
            Result.RouteValues["postId"].Should().Be(ExpectedModel.Id.Value);
        }
    }
}
