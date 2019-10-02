using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using WebServer.Data;
using WebServer.ViewModels;
using BookStore.Models;

namespace WebServer.Controllers
{

    [ApiController]
    [Route ("/api/[Controller]")]
    public class BooksController : Controller {

        public BookRepository Repository { get; private set; }
        public LinkGenerator LinkGenerator { get; }

        // Dependency Injection
        public BooksController (IHostingEnvironment environment, 
            IConfiguration configuration, BookRepository repository, LinkGenerator linkGenerator) 
        {
            this.Repository = repository;
            LinkGenerator = linkGenerator;
        }

        [HttpGet]
        [EnableQuery]
        public ObjectResult Get()
        {
            var data = Repository.Get()
           .Include(p => p.Author)
           .Include(p => p.Category)
           .AsQueryable();

            var result = new ObjectResult(
       data.Select(p => new
       {
           p.BookId,
           p.Name,
           p.Pagecount,
           p.Point,
           Author = new
           {
               p.Author.AuthorId,
               Name = p.Author.Name + " " + p.Author.Surname,
               
           },
           Category = new
           {
               p.Category.CategoryId,
               p.Category.Name
           }
       }).ToArray())
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            return Ok(Repository.Get().Where(p => p.Name.Contains(name)));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var match = Repository.Get(id);

            if (match == null)
            {
                return NotFound();
            }

            //BP-03 Tip: HATEOAS & Linking 


            dynamic result = new
            {
                match.BookId,
                match.Name,
                match.Pagecount,
                match.Point,
                match.AuthorId,
                match.CategoryId,
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookViewModel[] viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            foreach (var item in viewModel)
            {
                Repository.Add(item);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] Book viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var model = Repository.Get(id);

            if (model == null)
            {
                return NotFound();
            }
            model.Name = viewModel.Name;
            model.Pagecount = viewModel.Pagecount;
            model.Point = viewModel.Point;
            model.AuthorId = viewModel.AuthorId;

            Repository.Update(id, model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (Repository.Get(id) == null)
            {
                return NotFound();
            }

            Repository.Delete(id);

            return Ok();
        }
    }
}
 