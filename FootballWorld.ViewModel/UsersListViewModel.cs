using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballWorld.ViewModel
{
    public class UsersListViewModel
    {
        [Key]
        public string Id { get; set; }

        [DisplayName("Потребителско име")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string UserName { get; set; }

        [DisplayName("Първо име")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string FirstName { get; set; }

        [DisplayName("Фамилия")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string LastName { get; set; }

        [Phone]
        [DisplayName("Телефонен номер")]
        public string PhoneNumber { get; set; }

        [DisplayName("Имейл")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Аватар")]
        public byte[] ProfileImage { get; set; }
    }
}
