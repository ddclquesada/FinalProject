using BookStore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebServer.Data;
using WebServer.ViewModels;

namespace WebServer.Controllers {
    
    [ApiController]
    [Route (ROUTE)]
    public class AuthorController : Controller {
        public const string ROUTE = "/api/[Controller]";
        public static string CONTROLLER_NAME = "Author";

        public AuthorRepository Repository { get; private set; }

        // Dependency Injection
        public AuthorController(IHostingEnvironment environment, 
            IConfiguration configuration, AuthorRepository repository) 
        {
            this.Repository = repository;
        }

        [HttpGet]
        public ObjectResult Get ()
        {
            var data = Repository.Get().AsQueryable();

            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }


        [HttpGet("{id}")]
        public ObjectResult GetById(int id)
        {
            var data = Repository.Get(id);

            var result = new ObjectResult(data)
            {
                StatusCode = (int)HttpStatusCode.OK
            };

            return result;
        }


        [HttpPost]
        public IActionResult Post([FromBody] AuthorViewModel[] viewModel)
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
        public IActionResult Put([FromRoute] int id, [FromBody] Author viewModel)
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
            model.Surname = viewModel.Surname;
            
            Repository.Update(id, model);

            return Ok();
        }
    }
}