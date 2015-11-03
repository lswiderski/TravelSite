using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models.ViewModels
{
    public class CreateUserViewModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Birth Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public System.DateTime BirthDate { get; set; }

        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Active")]
        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }
    }
}
