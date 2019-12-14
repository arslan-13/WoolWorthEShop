using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoolWorthEShop.DB;
using WoolWorthEShop.Entities;

namespace WoolWorthEShop.Services
{
    public class CategoriesService : DbContext
    {
        public Category GetCategoryID(int ID)
        {
            using (var context = new WWContext())
            {
                return context.Categories.Find(ID);
            }
        }
        public List<Category> GetCategory()
        {
            using (var context = new WWContext())
            {
                return context.Categories.ToList();

            }
        }
        public List<Category> GetFeaturedCategory()
        {
            using (var context = new WWContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();

            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new WWContext())
            {
                context.Categories.Add(category);
                context.SaveChanges();

            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new WWContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

            }
        }


        public void DeleteCategory(int ID)
        {
            using (var context = new WWContext())
            {
                //  context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                var category = context.Categories.Find(ID);
                context.Categories.Remove(category);
                context.SaveChanges();

            }
        }

    }
}
