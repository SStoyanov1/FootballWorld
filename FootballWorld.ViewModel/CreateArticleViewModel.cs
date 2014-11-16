using FootballWorld.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FootballWorld.ViewModel
{
    public class CreateArticleViewModel
    {
        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Title { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Subtitle { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 6)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        [DisplayName("Video address")]
        public string VideoAddress { get; set; }

        [DisplayName("Select File to Upload")]
        public HttpPostedFileBase Image { get; set; }

        public string AuthorId { get; set; }

        public Category Category { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}