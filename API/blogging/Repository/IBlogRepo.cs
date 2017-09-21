using blogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace blogging.Repository
{
   public  interface IBlogRepo
    {
        IEnumerable<BlogModel> BlogModels { get; set; }
        IEnumerable<BlogModel> GetAllBlogs();
        Boolean AddBlog(BlogModel blog);
        Boolean DeleteBlog(int BlogId);
        Boolean UpdateBlog(BlogModel blog);
        IEnumerable<BlogModel> GetBlogsByUser(string userid);
        IEnumerable<BlogModel> GetBlogsByTag(string tag);
        IEnumerable<BlogModel> GetBlogsByBlogId(int id);
    }
}
