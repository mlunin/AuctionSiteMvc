using System.Web.Mvc;
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
        public ViewResult Details(int id)
        {
            var post = _repository.GetById(id);
            return View(post);
        }

        [HttpGet]
        public ViewResult Edit(int postId)
        {
            var post = _repository.GetById(postId);
            return View(post);
        }

        [HttpPost]
        public RedirectToRouteResult Edit(Post post)
        {
            var p =_repository.Save(post);
            return RedirectToAction("Details", new { postId = p.Id});
        }
    }
}
