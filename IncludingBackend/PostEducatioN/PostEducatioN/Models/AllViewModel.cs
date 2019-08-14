using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PostEducatioN.Models.ApplicationDbContext;

namespace PostEducatioN.Models
{
    public class AllViewModel
    {
        public List<Video> Videos { get; set; }
        public List<Category> Categories { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
        public List<ApplicationUser> Users { get; set; }
        public ApplicationUser Author { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}