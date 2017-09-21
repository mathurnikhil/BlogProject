using blogging.Models;
using blogging.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;

namespace blogging.Controllers
{
    public class ValuesController : ApiController
    {
        private IBlogRepo _blogRepo;
        public ValuesController()
        {
            _blogRepo = new BlogRepo(new BlogDbContext());
        }

        public IHttpActionResult GetAllBlogs()
        {
            var blogs = _blogRepo.GetAllBlogs();
            if(blogs==null)
            {
                return NotFound();

            }
            return Ok(blogs);
        }

        [HttpPost]
        public IHttpActionResult AddBlog(BlogModel blog)
        {
            bool check = _blogRepo.AddBlog(blog);
            return Ok(check);
        }

        [HttpDelete]
        [Route("api/values/Delete/{BlogId}")]
        public IHttpActionResult DeleteBlog(int BlogId)
        {
            
            bool check = _blogRepo.DeleteBlog(BlogId);
            return Ok(check);
        }

        [HttpPut]
        [Route("api/values/Update")]
        public IHttpActionResult UpdateBlog(BlogModel blog)
        {

            bool check = _blogRepo.UpdateBlog(blog);
            return Ok(check);
        }

        [HttpGet]
        [Route("api/values/user/{id}")]
        public IHttpActionResult GetBlogsByUser(string id)
        {
            var blogs = _blogRepo.GetBlogsByUser(id);
            if (blogs == null)
            {
                return NotFound();

            }
            return Ok(blogs);
        }

        [HttpGet]
        [Route("api/values/tag/{tag}")]
        public IHttpActionResult GetBlogsByTag(string tag)
        {
            var blogs = _blogRepo.GetBlogsByTag(tag); 
            if (blogs == null)
            {
                return NotFound();

            }
            return Ok(blogs);
        }
        [HttpGet]
        [Route("api/values/blog/{id}")]
        public IHttpActionResult GetBlogsById(int id)
        {
            var blogs = _blogRepo.GetBlogsByBlogId(id);
            if (blogs == null)
            {
                return NotFound();

            }
            return Ok(blogs);
        }








        //    // GET api/values
        //    public IEnumerable<string> Get()
        //    {
        //        return new string[] { "value1", "value2" };
        //    }

        //    // GET api/values/5
        //    public string Get(int id)
        //    {
        //        return "value";
        //    }

        //    // POST api/values
        //    public void Post([FromBody]string value)
        //    {
        //    }

        //    // PUT api/values/5
        //    public void Put(int id, [FromBody]string value)
        //    {
        //    }

        //    // DELETE api/values/5
        //    public void Delete(int id)
        //    {
        //    }
    }
    }
