using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebProject.Models.ViewModels
{
    public class AllUserInfoViewModel
    {
        [Key]
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

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public List<CreateCommentViewModel> Comments;

        public List<PlaceViewModel> Places;

        public List<PlaceViewModel> Visited;

    }
}