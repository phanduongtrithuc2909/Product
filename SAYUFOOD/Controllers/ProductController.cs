using SAYUFOOD.Models;
using SAYUFOOD.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAYUFOOD.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _dbcontext = new ApplicationDbContext();        // GET: Product
        public ActionResult Index()
        {
            List<Product> items = _dbcontext.Products.ToList<Product>();
            return View(items);
        }
    }
}