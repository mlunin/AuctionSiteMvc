using System.Web.Mvc;
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
        public ActionResult Details(int postId)
        {
            var post = _repository.GetById(postId);
            return View(post);
        }

    }
}
