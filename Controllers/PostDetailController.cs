using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSiteMvc.Persistent;

namespace AuctionSiteMvc.Controllers
{       
    public class PostDetailController : Controller
    {
        private readonly IPostRepository _repository;

        public PostDetailController(IPostRepository repository)
        {
            _repository = repository;
        }//
        // GET: /PostDetail/

        public ActionResult Index(string id)
        {
            var posts = _repository.List();
            ViewBag.Id = id;
            ViewBag.Posts = posts;
            return View();
        }

    }
}
