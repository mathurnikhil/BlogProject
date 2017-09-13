using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using blogging.Models;

namespace blogging.Repository
{
    public class BlogRepo : IBlogRepo
    {
        private BlogDbContext _blogDbContext;
        public BlogRepo(BlogDbContext blogDbContext)
        {
            this._blogDbContext = blogDbContext;
        }

        public IEnumerable<BlogModel> BlogModels { get; set; }

        public bool AddBlog(BlogModel blog)
        {
            //BlogModel model = new BlogModel();
            //model.UserId = UserId;
            //model.Content = Content;
            //model.Tag = Tag;
            blog.TimeStamp = System.DateTime.Now.ToUniversalTime();
            _blogDbContext.Blogs.Add(blog);
            _blogDbContext.SaveChanges();
            return true;
        }

        public bool DeleteBlog(int BlogId)
        {
            BlogModel delObject = _blogDbContext.Blogs.Find(BlogId);
            if( delObject!=null)
            {
                _blogDbContext.Blogs.Remove(delObject);
                _blogDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public IEnumerable<BlogModel> GetAllBlogs()
        {
            BlogModels = _blogDbContext.Blogs.AsEnumerable();
            return BlogModels;
        }

        public bool UpdateBlog(BlogModel blog)
        {
            BlogModel updateObject = _blogDbContext.Blogs.Find(blog.BlogId);
            updateObject.Content = blog.Content;
            updateObject.Tag = blog.Tag;
            updateObject.TimeStamp = System.DateTime.Now.ToUniversalTime();
            _blogDbContext.SaveChanges();
            return true;
        }

        public IEnumerable<BlogModel> GetBlogsByTag(string tag)
        {
            BlogModels = _blogDbContext.Blogs.Where(x=>x.Tag==tag).OrderByDescending(x => x.TimeStamp).AsEnumerable();
            return BlogModels;
        }

        public IEnumerable<BlogModel> GetBlogsByUser(String userid)
        {
            BlogModels = _blogDbContext.Blogs.Where(x => x.UserId == userid).OrderByDescending(x=>x.TimeStamp).AsEnumerable();
            return BlogModels;
        }
        public IEnumerable<BlogModel> GetBlogsByBlogId(int id)
        {
            BlogModels = _blogDbContext.Blogs.Where(x => x.BlogId == id).AsEnumerable();
            return BlogModels;
        }

    }
}