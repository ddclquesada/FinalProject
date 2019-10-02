using BookStore.Models;
using System;
using System.Linq;
using WebServer.ViewModels;

namespace WebServer.Data
{
    public class ReviewRepository
    {
        public BookStoreContext Context { get; }

        public ReviewRepository(BookStoreContext context)
        {
            Context = context;
        }

        public IQueryable<Review> Get()
        {
            return Context.Review.AsQueryable();
        }

        public Review Get(int id)
        {
            return Context.Review.Find(id);
        }


        public int? Add(ReviewViewModel viewModel)
        {
            var model = new Review();
            model.Person = viewModel.Person;
            model.ReviewText = viewModel.ReviewText;
            model.Date = DateTime.Now;
            model.BookId = viewModel.BookId;

            Context.Review.Add(model);

            Context.SaveChanges();

            return model.BookId;

        }

    }
}
