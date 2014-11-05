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

        public string imageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
