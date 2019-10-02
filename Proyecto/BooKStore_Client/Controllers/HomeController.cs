using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookStore.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using BooKStore_Client.Models;

namespace BooKStore_Client.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            IEnumerable<Book> bookInfo = null;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format    
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("Books");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var bookResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    bookInfo = JsonConvert.DeserializeObject<List<Book>>(bookResponse);

                }
                //returning the employee list to view  
                return View(bookInfo);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
