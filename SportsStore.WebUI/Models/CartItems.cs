using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class CartItems
    {
        private List<CartLine> lineItems = new List<CartLine>();
        public void AddToCart(Product p)
        {
            if (lineItems.Find(li=>li.product.ProductID==p.ProductID)!=null)
            {
                CartLine cartLine = lineItems.Find(li => li.product.ProductID == p.ProductID);
                cartLine.quantity += 1;
            }
            else
            {
                CartLine cartLine = new CartLine();
                cartLine.product = p;
                cartLine.quantity = 1;
                lineItems.Add(cartLine);
            }
        }
        public void RemoveFromCart(Product p)
        {
            if (lineItems.Find(li => li.product.ProductID == p.ProductID) != null)
            {
                
                CartLine cartLine = lineItems.Find(li => li.product.ProductID == p.ProductID);
                lineItems.Remove(cartLine);
            }
            else
            {
                //CartLine cartLine = new CartLine();
                //cartLine.product = p;
                //cartLine.quantity = 1;
                //lineItems.Add(cartLine);
            }
        }
        public IEnumerable<CartLine> LineItems
        {
            get { return lineItems; }
        }
        public string ReturnURL;
    }
}
