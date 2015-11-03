using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebProject.Models.ViewModels
{
    public class CreateCommentViewModel
    {
        public int CommentId { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
        public int PlaceId { get; set; }
        public string UserEmail { get; set; }
        public int UserId { get; set; }
    }
}
