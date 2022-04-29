using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HANDICRAFTSHOPPING.Controllers
{
    public class HomeController : Controller
    {
       //var T = this.Session["ID"];
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        public ActionResult UpdateProduct()
        {
            return View();
        }
        public ActionResult CategoryProductDetails(int e)
        {

            return View();

        }
        public ActionResult ProductDetails(int p)
        {
            return View();

        }
        public ActionResult BYProduct(int R,int T)
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
       

    }
}