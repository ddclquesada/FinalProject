using BookStore.Models;
using System;
using System.Linq;
using WebServer.ViewModels;

namespace WebServer.Data
{
    public class CategoryRepository
    {
        public BookStoreContext Context { get; }

        public CategoryRepository(BookStoreContext context)
        {
            Context = context;
        }

        public IQueryable<Category> Get()
        {
            return Context.Category.AsQueryable();
        }

        public Category Get(int id)
        {
            return Context.Category.Find(id);
        }


        public int? Add(CategoryViewModel viewModel)
        {
            var model = new Category();
            model.Name= viewModel.name;
            
            Context.Category.Add(model);

            Context.SaveChanges();

            return model.CategoryId;

        }

        public void Update(int id, Category model)
        {
            var match = Context.Category.FirstOrDefault(m => m.CategoryId == id);

            if (match != null)
            {
                match.Name = model.Name;
                Context.Category.Update(match);

                Context.SaveChanges();
            }
        }

    }
}
