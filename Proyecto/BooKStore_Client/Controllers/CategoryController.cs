using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using BooKStore_Client.Helper;

namespace CategoryStore_Client.Controllers
{
    public class CategoryController : Controller
    {
        private object categoryList = new object();
        private object authorList = new object();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

     
        // GET: Category/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromBody] Category collection)
        {
            try
            {
                var Category = new Helper<Category>();
                Category.Post("Categories", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var helper = new Helper<Category>();
            List<Category> CategoryObject = await helper.RequestById("Categories", id);
            
            return View(CategoryObject.FirstOrDefault());
        }

        // POST: Category/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromBody] Category collection)
        {
            try
            {
                var Category = new Helper<Category>();
                Category.Put("Categories", collection);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var Category = new Helper<Category>();
                Category.Delete("Categories", id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}