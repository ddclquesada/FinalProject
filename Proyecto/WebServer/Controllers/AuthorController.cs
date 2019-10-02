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
    }
}