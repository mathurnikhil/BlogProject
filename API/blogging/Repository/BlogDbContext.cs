using blogging.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace blogging.Repository
{
    public class BlogDbContext: DbContext
    {
        public BlogDbContext() : base("name=DemoConnString"){ }
        public DbSet<BlogModel> Blogs { get; set; }
            
    }
}