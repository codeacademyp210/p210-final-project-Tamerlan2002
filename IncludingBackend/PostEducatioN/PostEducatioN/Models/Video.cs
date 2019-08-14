using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostEducatioN.Models
{

    public class Video
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string VideoPath { get; set; }
        public DateTime DateAdded { get; set; }
        public string ApplicationUserId { get; set; }
        public string ImagePath { get; set; }
        [Column(TypeName = "text")]
        [AllowHtml]
        public string Description { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}