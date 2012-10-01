﻿using System.Web.Mvc;
using AuctionSiteMvc.Domain;
using AuctionSiteMvc.Persistent;

namespace AuctionSiteMvc.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ViewResult Details(int postId)
        {
            var post = _repository.GetById(postId);
            return View(post);
        }

        [HttpGet]
        public ViewResult Edit(int postId)
        {
            return null;
        }

        [HttpPost]
        public ViewResult Edit(Post post)
        {
            return null;
        }
    }
}