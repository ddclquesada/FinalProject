using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebClient.Helper;
using BookStore.Models;

namespace WebClient.Controllers
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

        // GET: Book/Details/5
        public ActionResult Details(int id)
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private async Task LoadInitialData()
        {
            var category = new Helper<Category>();
            List<Category> catList = await category.Request("Categories");
            ViewBag.categoryList = new SelectList(catList.Select(c => new { c.CategoryId, c.Name }), "CategoryId", "Name");

            var author = new Helper<Author>();
            List<Author> authorList = await author.Request("Author");
            ViewBag.authorList = new SelectList(authorList.Select(a => new { a.AuthorId, a.Name }), "AuthorId", "Name");
        }
    }
}
