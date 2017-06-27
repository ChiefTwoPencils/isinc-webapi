using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggerApp.Models
{
    public class Blog
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}