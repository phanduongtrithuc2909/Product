using SAYUFOOD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAYUFOOD.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCard
        // 
        ApplicationDbContext _db = new ApplicationDbContext();

        public ShoppingCart GetCart()
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            if(cart == null || Session["Cart"] == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // gio hang
        public ActionResult Index()
        {
            if (Session["Cart"] == null)
                return RedirectToAction("Index", "ShoppingCart");
            ShoppingCart cart = Session["Cart"] as ShoppingCart;


            return View(cart);
        }
        //them vao gio hang
        public ActionResult AddToCart(int id)
        {
            var pro = _db.Products.SingleOrDefault(x => x.Id == id);
            if(pro != null)
            {
                GetCart().Add(pro);
            }
            return RedirectToAction("Index", "ShoppingCart");
        }
        // gio hang



        
        public ActionResult Update_quantity_cart(FormCollection form)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            int id_pro = int.Parse(form["Id_product"]);
            int id_quantity = int.Parse(form["quantity"]);

            cart.Update_quantity(id_pro, id_quantity);

            return RedirectToAction("Index", "ShoppingCart");
        }


        public ActionResult XoaItemCart(int id)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            cart.Remove_CartItem(id);
            return RedirectToAction("Index", "ShoppingCart");
        }



    }
}