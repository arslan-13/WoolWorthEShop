using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoolWorthEShop.Entities;
using WoolWorthEShop.DB;
using System.Data.Entity;

namespace WoolWorthEShop.Services
{
    public class productService
    {
        #region Constructor
        public static productService Instance
        {
            get
            {
                if (PrivateInstance == null)
                {
                    PrivateInstance = new productService();
                }
                return PrivateInstance;

            }
        }
        private static productService PrivateInstance { get; set; }
        public productService()
        {
        }

        #endregion

        public Product GetProductID(int ID)
        {
            using (var context = new WWContext())
            {
                return context.Products.Where(x => x.ID == ID).Include(x => x.category).FirstOrDefault();
            }
        }

        public List<Product> GetProductsByID(List<int> IDs)
        {
            using (var context = new WWContext())
            {
                return context.Products.Where(x => IDs.Contains(x.ID)).ToList();
            }
        }

        public List<Product> GetProduct(int pageno)
        {
            int pageSize = 5;

            using (var context = new WWContext())
            {
                return context.Products.OrderBy(x => x.ID).Skip((pageno - 1) * pageSize).Take(pageSize).Include(x => x.category).ToList();
                // return context.Products.Include(x => x.category).ToList();

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

