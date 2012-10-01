using System.Web.Mvc;
using AuctionSiteMvc.Persistent;

namespace AuctionSiteMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostRepository _repository;

        public HomeController(IPostRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var posts = _repository.List();

            return View(posts);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
