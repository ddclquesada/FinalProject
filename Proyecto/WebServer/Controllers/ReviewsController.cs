using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebServer.Data;
using WebServer.ViewModels;

namespace WebServer.Controllers
{

    [ApiController]
    [Route(ROUTE)]
    public class ReviewsController : Controller
    {
        public const string ROUTE = "/api/[Controller]";
        public static string CONTROLLER_NAME = "Reviews";

        public ReviewRepository Repository { get; private set; }

        // Dependency Injection
        public ReviewsController(IHostingEnvironment environment,
            IConfiguration configuration, ReviewRepository repository)
        {
            this.Repository = repository;
        }

        [HttpGet]
        public ObjectResult Get()
        {
            var data = Repository.Get()
                .Include(r => r.Book);

            var result = new ObjectResult(
                data.Select(r => new
                {
                    r.ReviewId,
                    r.ReviewText,
                    r.BookId,
                    r.Book.Name

                }).ToArray())
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
        public IActionResult Post([FromBody] ReviewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var id = Repository.Add(viewModel);

            return CreatedAtAction(nameof(GetById), new { Id = id }, viewModel);
        }
    }
}