using IShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IShop.Controllers
{
    public class CategoriesViewController : Controller
    {
        // GET: CategoriesView
        public ActionResult Index()
        {
            var categories = new List<Category>();

            return View(categories);
        }
    }
}