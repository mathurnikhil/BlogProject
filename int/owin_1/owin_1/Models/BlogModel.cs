using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace owin_1.Models
{
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public string Tag { get; set; }

        public DateTime TimeStamp { get; set; }
    }
}