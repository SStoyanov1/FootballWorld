using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FootballWorld.ViewModel
{
    public class DetailsArticleViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public string AuthorName { get; set; }

        public byte[] Image { get; set; }
    }
}
