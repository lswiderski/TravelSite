using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }
    }
}
