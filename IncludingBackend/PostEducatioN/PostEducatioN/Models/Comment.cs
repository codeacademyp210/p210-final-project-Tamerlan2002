using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostEducatioN.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Column(TypeName = "text")]
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public int VideoId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Video Video { get; set; }
    }
}