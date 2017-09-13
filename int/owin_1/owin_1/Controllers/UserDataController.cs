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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace owin_1.Controllers
{
    [Authorize]
    public class UserDataController : Controller
    {
        string Baseurl = "http://demoblogapi.azurewebsites.net/";

        public async Task<ActionResult> Index()
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
                HttpResponseMessage Res = await client.GetAsync("/api/values/user/" + User.Identity.GetUserName());

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var BlogResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    BlogInfo = JsonConvert.DeserializeObject<List<BlogModel>>(BlogResponse);

                }
                //returning the employee list to view  
                return View(BlogInfo);
            }
        }

        public ActionResult AddBlog()
        {
            var dropDownList = new SelectList(
                        new List<SelectListItem>
                        {
                            new SelectListItem { Text = "Featured", Value = "featured"},
                            new SelectListItem { Text = "Music", Value = "music"},
                            new SelectListItem { Text = "Sports", Value = "sports"},
                            new SelectListItem { Text = "Entertainment", Value = "entertainment"},
                            new SelectListItem { Text = "Technology", Value = "technology"}
                        }, "Value", "Text");
            ViewBag.Tag = dropDownList;
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> AddBlog(BlogModel blogModel)
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
                var sendData = new BlogModel() { UserId = User.Identity.GetUserName(), Tag = blogModel.Tag, Content = blogModel.Content };
                HttpResponseMessage Res = await client.PostAsJsonAsync("/api/values/", sendData);

                var dropDownList = new SelectList(
                        new List<SelectListItem>
                        {
                            new SelectListItem { Text = "Featured", Value = "featured"},
                            new SelectListItem { Text = "Music", Value = "music"},
                            new SelectListItem { Text = "Sports", Value = "sports"},
                            new SelectListItem { Text = "Entertainment", Value = "entertainment"},
                            new SelectListItem { Text = "Technology", Value = "technology"}
                        }, "Value", "Text");
                ViewBag.Tag = dropDownList;

                return PartialView();
            }
        }

        /*
         * GET BY TAG - api/values/tag/
         * POST - api/values/{UserId:, Content:, Tag:}
         * UPDATE - api/values/update
         * DELETE - api/values/delete/{blogid}
         */
    }
}