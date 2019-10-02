using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WebClient.Helper
{
    public class Helper<T>
    {
        public async Task<List<T>> Request(string APIName)
        {

            IEnumerable<T> EmpInfo = null;

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri("https://localhost:44357/api/");

                client.DefaultRequestHeaders.Clear();
                //Define request data format    
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(APIName);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<T>>(EmpResponse);

                }
                //returning the employee list to view  
                return EmpInfo.ToList();
            }

        }
    }
}
