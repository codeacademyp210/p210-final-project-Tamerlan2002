using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostEducatioN.Models
{
    public class Like
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public int VideoId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Video Video { get; set; }
    }
}