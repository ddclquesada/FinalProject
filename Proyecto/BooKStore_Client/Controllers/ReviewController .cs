using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooKStore_Client.Helper;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Reviewstore_Client.Controllers
{
    public class ReviewController : Controller
    {
        private object categoryList = new object();
        private object authorList = new object();
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

     
        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Book collection)
        {
            try
            {
                var book = new Helper<Book>();
                book.Post("Reviews", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var helper = new Helper<Book>();
            List<Book> bookObject = await helper.Request("Reviews" + $"/{id}");
            
            return View(bookObject.FirstOrDefault());
        }

        // POST: Book/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromBody] Book collection)
        {
            try
            {
                var book = new Helper<Book>();
                book.Put("book", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var book = new Helper<Book>();
                book.Delete("Reviews", id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}