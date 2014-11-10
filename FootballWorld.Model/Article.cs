using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.Model
{
    public class Article
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
            this.Categories = new HashSet<Category>();
        }

        [Key]
        public int Id { get; set; }

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

        public string ImageName { get; set; }

        public byte[] Image { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
