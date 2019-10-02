using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.ViewModels;

namespace WebServer.Data
{
    public class BookRepository
    {
        public BookStoreContext DbContext { get; }

        public BookRepository(BookStoreContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<Book> Get()
        {
            return DbContext.Book.AsQueryable();
        }

        public Book Get(int id)
        {
            return DbContext.Book.Include(p => p.Category)
                            .FirstOrDefault();
        }

        public int Add(BookViewModel viewModel)
        {
            var model = new Book();
            model.Name = viewModel.Name;
            model.Pagecount = viewModel.Pagecount;
            model.Point = viewModel.Point;
            model.AuthorId = viewModel.AuthorId;
            model.CategoryId = viewModel.CategoryId;

            DbContext.Book.Add(model);

            DbContext.SaveChanges();

            return model.BookId;
            
        }

        public void Update(int id, Book model)
        {
            var match = DbContext.Book.FirstOrDefault(m => m.BookId == id);

            if (match != null)
            {
                model.BookId = id;
                DbContext.Book.Update(match);

                DbContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var match = DbContext.Book.FirstOrDefault(m => m.BookId == id);

            if (match != null)
            {
                DbContext.Book.Remove(match);
                DbContext.SaveChanges();
            }
        }
    }
}
