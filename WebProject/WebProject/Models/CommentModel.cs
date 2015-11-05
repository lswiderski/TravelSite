using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public System.DateTime Date { get; set; }
        public string Content { get; set; }
        public int PlaceId { get; set; }
        public int UserId { get; set; }

        public void Create(CommentModel model)
        {
            var userModel = new UserModel();
            using (var db = new DBEntitiesProxy())
            {
                db.COMMENT.Add(new COMMENT()
                {
                    Content = model.Content,
                    PlaceId = model.PlaceId,
                    UserId = model.UserId,
                    Date = System.DateTime.Now
                });
                db.SaveChanges();
            }
        }
        public void Create(CreateCommentViewModel model)
        {
            var userModel = new UserModel();
            using (var db = new DBEntitiesProxy())
            {
                db.COMMENT.Add(new COMMENT()
                {
                    Content = model.Content,
                    PlaceId = model.PlaceId,
                    Date = System.DateTime.Now,
                    UserId = userModel.GetUserID(model.UserEmail)
                });
                db.SaveChanges();
            }
        }
        public List<CommentModel> GetComments()
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.COMMENT.Select(x => new CommentModel { CommentId = x.CommentId, Content = x.Content, Date = x.Date, UserId = x.UserId, PlaceId = x.PlaceId }).ToList();
            }
        }
        public List<CreateCommentViewModel> GetCommentsWithUser()
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.COMMENT.Select(x => new CreateCommentViewModel { CommentId = x.CommentId, Content = x.Content, Date = x.Date, UserId = x.UserId, PlaceId = x.PlaceId, UserEmail = x.User.Email }).ToList();
            }
        }
        public CreateCommentViewModel GetComment(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.COMMENT.Select(x => new CreateCommentViewModel { CommentId = x.CommentId, Content = x.Content, Date = x.Date, UserId = x.UserId, PlaceId = x.PlaceId, UserEmail = x.User.Email }).Where(x => x.CommentId == id).SingleOrDefault();
            }
        }
        public List<CreateCommentViewModel> GetCommentByPlace(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.COMMENT.Select(x => new CreateCommentViewModel { CommentId = x.CommentId, Content = x.Content, Date = x.Date, UserId = x.UserId, PlaceId = x.PlaceId, UserEmail = x.User.Email }).Where(x => x.PlaceId == id).ToList();
            }
        }
        public List<CreateCommentViewModel> GetCommentByUser(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.COMMENT.Select(x => new CreateCommentViewModel { CommentId = x.CommentId, Content = x.Content, Date = x.Date, UserId = x.UserId, PlaceId = x.PlaceId, UserEmail = x.User.Email }).Where(x => x.UserId == id).ToList();
            }
        }
    }
}