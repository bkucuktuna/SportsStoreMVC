using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        IProductRepository repositoryCart;
        public CartController(IProductRepository rep) { repositoryCart = rep; }

        // GET: ShoppingCart
        public ActionResult AddToCart(int productId)
        {
            //cartItems.AddToCart( repositoryCart.Products.Where(p => p.ProductID == productId).First());
            Product product = repositoryCart.Products.Where(p => p.ProductID == productId).First();
            CartItems cartItems = (CartItems)Session["cart"];
            if (Session["cart"]==null)
            {
                cartItems = new CartItems();
                cartItems.AddToCart(product);
                Session["cart"] = cartItems;
            }
            else
            {
                cartItems.AddToCart(product);
            }
            return View(cartItems);
        }
    }
}