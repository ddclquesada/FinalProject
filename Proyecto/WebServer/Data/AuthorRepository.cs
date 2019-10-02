using BookStore.Models;
using System;
using System.Linq;

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
    }
}
