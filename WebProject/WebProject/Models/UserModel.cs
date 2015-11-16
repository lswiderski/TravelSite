using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProject.Models.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Helpers;

namespace WebProject.Models
{
    public class UserModel
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

        [Required]
        [DisplayName("Password")]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public void Create(UserModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var hashedPassword = Crypto.HashPassword(model.Password);
                db.User.Add(new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDate = model.BirthDate,
                    Email = model.Email,
                    Password = hashedPassword,
                    AddDate = System.DateTime.Now,
                    ModifiedDate = null,
                    IsActive = model.IsActive
                });
                db.SaveChanges();
            }
        }
        public int GetUserID(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User.Where(x => x.Email == email).Select(x => new { x.UserId}).SingleOrDefault();
                return user.UserId;
            }

        }
        public int GetUserByEmail(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User.Where(x => x.Email == email).Select(x => new UserModel{ BirthDate = x.BirthDate, Email = x.Email, FirstName = x.FirstName, IsActive = x.IsActive, IsAdmin = x.IsAdmin, LastName = x.LastName, UserId = x.UserId }).SingleOrDefault();
                return user.UserId;
            }

        }
        public int GetUserById(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User.Where(x => x.UserId == id).Select(x => new UserModel { BirthDate = x.BirthDate, Email = x.Email, FirstName = x.FirstName, IsActive = x.IsActive, IsAdmin = x.IsAdmin, LastName = x.LastName, UserId = x.UserId }).SingleOrDefault();
                return user.UserId;
            }

        }
        public AllUserInfoViewModel GetUser(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User
                    .Where(x => x.UserId == id)
                    .Select(x => new AllUserInfoViewModel
                    {
                        BirthDate = x.BirthDate,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        IsActive = x.IsActive,
                        IsAdmin = x.IsAdmin,
                        LastName = x.LastName,
                        UserId = x.UserId,
                        Comments = x.COMMENT.Select(y => new CreateCommentViewModel { CommentId = y.CommentId, Content= y.Content, Date= y.Date, PlaceId = y.PlaceId, UserEmail = y.User.Email, UserId = y.UserId }).ToList(),
                        Places = x.Place.Select(y => new PlaceViewModel { Content = y.Content, PlaceId = y.PlaceId, Country = y.Country.Name, IsAccepted =y.IsAccepted, Name= y.Name, Photo_URI =y.Photo_URI, UserName = y.User.Email }).ToList(),
                    }
                        ).SingleOrDefault();

                return user;
            }
        }
        public AllUserInfoViewModel GetUser(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User
                    .Where(x => x.Email == email)
                    .Select(x => new AllUserInfoViewModel
                    {
                        BirthDate = x.BirthDate,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        IsActive = x.IsActive,
                        IsAdmin = x.IsAdmin,
                        LastName = x.LastName,
                        UserId = x.UserId,
                        Comments = x.COMMENT.Select(y => new CreateCommentViewModel { CommentId = y.CommentId, Content = y.Content, Date = y.Date, PlaceId = y.PlaceId, UserEmail = y.User.Email, UserId = y.UserId }).ToList(),
                        Places = x.Place.Select(y => new PlaceViewModel { Content = y.Content, PlaceId = y.PlaceId, Country = y.Country.Name, IsAccepted = y.IsAccepted, Name = y.Name, Photo_URI = y.Photo_URI, UserName = y.User.Email }).ToList(),
                        Visited = x.Travels.Select(y => new PlaceViewModel { Content = y.Place.Content, PlaceId = y.PlaceId, Country = y.Place.Country.Name, IsAccepted = y.Place.IsAccepted, Name = y.Place.Name, Photo_URI = y.Place.Photo_URI, UserName = y.User.Email }).ToList(),
                    }
                        ).SingleOrDefault();

                return user;
            }
        }
        public bool IsValid(string _username, string _password)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User.Select(x => new { x.Email, x.Password }).Where(x => x.Email == _username).SingleOrDefault();
                if (user != null)
                {
                    var hashedPassword = user.Password;
                    bool doesPasswordMatch = false;
                    try
                    {
                        doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, _password);
                    }
                    catch (Exception)
                    {

                        //badpassword
                    }
                    
                    return doesPasswordMatch;
                }
                else
                {
                    return false;
                }

            }
        }
        public bool CheckIfIsAdmin(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                var user = db.User.Select(x => new { x.Email, x.IsAdmin }).Where(x => x.Email == email).SingleOrDefault();
                if (user == null)
                {
                    return false;
                }
                if (!user.IsAdmin)
                {
                    return false;
                }
                return true;
            }
        }
    }
}