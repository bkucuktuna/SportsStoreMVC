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
        private List<Product> products = new List<Product>();
        public void AddToCart(Product p) { products.Add(p); }
        public IEnumerable<Product> Products
        {
            get { return products; }
        }
    }
}
