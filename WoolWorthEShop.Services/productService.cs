using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoolWorthEShop.Entities;
using WoolWorthEShop.DB;

namespace WoolWorthEShop.Services
{
    public class productService
    {

        public Product GetProductID(int ID)
        {
            using (var context = new WWContext())
            {
                return context.Products.Find(ID);
            }
        }
        public List<Product> GetProduct()
        {
            using (var context = new WWContext())
            {
                return context.Products.ToList();

            }
        }

        public void SaveProduct(Product product)
        {
            using (var context = new WWContext())
            {
                context.Products.Add(product);
                context.SaveChanges();

            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new WWContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }


        public void DeleteProduct(int ID)
        {
            using (var context = new WWContext())
            {
                //  context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();

            }
        }

    }
}

