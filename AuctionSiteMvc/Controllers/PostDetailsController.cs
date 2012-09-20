using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctionSiteMvc.Domain;

namespace AuctionSiteMvc.Controllers
{
    public class PostDetailsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PrintPostDetails(string PostDescription)
        {
            ViewBag.PostDescription = PostDescription;
            return View();
        }

    }
}
