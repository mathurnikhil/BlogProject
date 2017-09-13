using Newtonsoft.Json;
using owin_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace owin_1.Controllers
{
    public class HomeController : Controller
    {
        string Baseurl = "http://demoblogapi.azurewebsites.net/";

        public ActionResult Index()
        {
            return View();
        }

        [Route("Home/GetPostByTag/{id}")]
        public async Task<ActionResult> GetPostByTag(string id)
        {
            List<BlogModel> BlogModel = new List<BlogModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("/api/values/tag/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BlogResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    BlogModel = JsonConvert.DeserializeObject<List<BlogModel>>(BlogResponse);

                }
            }

            return PartialView(BlogModel);
        }
    }
}