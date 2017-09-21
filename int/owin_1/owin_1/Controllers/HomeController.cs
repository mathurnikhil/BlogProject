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
        string Baseurl = "http://blobbloggingapi.azurewebsites.net/";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostTemplate(BlogModel model)
        {
            return PartialView(model);
        }

        public async Task<PartialViewResult> GetByTag(string tag)
        {
            List<BlogModel> BlogInfo = new List<BlogModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                //HttpResponseMessage Res = await client.GetAsync("api/values/tag/{tag}");
                HttpResponseMessage Res = await client.GetAsync("/api/values/tag/" + tag);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BlogResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    BlogInfo = JsonConvert.DeserializeObject<List<BlogModel>>(BlogResponse);
                }
                //returning the employee list to view  
                return PartialView(BlogInfo);
            }
        }
    }
}