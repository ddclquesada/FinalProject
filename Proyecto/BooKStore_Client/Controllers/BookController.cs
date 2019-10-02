using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BooKStore_Client.Helper;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BooKStore_Client.Controllers
{
    public class BookController : Controller
    {
        private object categoryList = new object();
        private object authorList = new object();
        // GET: Book
        public async Task<ActionResult> Index()
        {
            await LoadInitialData();
            return View();
        }

     
        // GET: Book/Create
        public async Task<ActionResult> Create()
        {
            await LoadInitialData();
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
                book.Post("Books", collection);

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
            await LoadInitialData();

            var helper = new Helper<Book>();
            List<Book> bookObject = await helper.RequestById("Books", id);
            
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
                book.Delete("Books", id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task LoadInitialData() {
            var category = new Helper<Category>();
            List<Category> catList = await category.Request("Categories");
            ViewBag.categoryList = new SelectList(catList.Select(c => new { c.CategoryId, c.Name }), "CategoryId","Name");

            var author = new Helper<Author>();
            List<Author> authorList = await author.Request("Author");
            ViewBag.authorList = new SelectList(authorList.Select(a => new { a.AuthorId, a.Name}), "AuthorId", "Name");
        }
    }
}