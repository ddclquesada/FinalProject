using BookStore.Models;
using System;
using System.Linq;
using WebServer.ViewModels;

namespace WebServer.Data
{
    public class AuthorRepository
    {
        public BookStoreContext Context { get; }

        public AuthorRepository(BookStoreContext context)
        {
            Context = context;
        }

        public IQueryable<Author> Get()
        {
            return Context.Author.AsQueryable();
        }

        public Author Get(int id)
        {
            return Context.Author.Find(id);
        }

        public int Add(AuthorViewModel viewModel)
        {
            var model = new Author();
            model.Name = viewModel.Name;
            model.Surname = viewModel.Surname;
            
            Context.Author.Add(model);

            Context.SaveChanges();

            return model.AuthorId;

        }

        public void Update(int id, Author model)
        {
            var match = Context.Author.FirstOrDefault(m => m.AuthorId == id);

            if (match != null)
            {
                model.AuthorId = id;
                Context.Author.Update(match);

                Context.SaveChanges();
            }
        }
    }
}
