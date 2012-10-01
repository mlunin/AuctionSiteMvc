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
    public class When_edit_post_by_http_get
    {
        private static IPostRepository _repository;
        private static PostController Sut { get; set; }
        protected static ViewResult Actual { get; set; }
        protected static int postId { get; set; }
        protected static Post ExpectedModel { get; set; }

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            // set a dumy post 
            ExpectedModel = new Post(postId, "","","",DateTime.Now, DateTime.MinValue);

            // generate a mock repository
            _repository = MockRepository.GenerateStub<IPostRepository>();

            // stub the repo to return a post when it is called GetById with a id is PostId
            _repository.Stub(repo => repo.GetById(postId)).Return(ExpectedModel);

            // the subject under test
            Sut = new PostController(_repository);

            // a random id to test
            postId = new Random().Next();

            // the result returned by calling Edit to the controller
            Actual = Sut.Edit(postId);
        }


        [TestMethod()]
        public void It_should_call_repository_get_by_id()
        {
            _repository.AssertWasCalled(repo => repo.GetById(postId));
        }

        [TestMethod()]
        public void It_should_return_a_correct_post()
        {
            Actual.Model.Should().Be(ExpectedModel);
        }
    }
}
