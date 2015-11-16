using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class PlaceModel
    {
        [Key]
        public int PlaceId { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Photo_URI { get; set; }

        public int CountryId { get; set; }

        public int UserId { get; set; }

        public bool IsAccepted { get; set; }

        public void Create(CreatePlaceViewModel model)
        {
            var userModel = new UserModel();
            using (var db = new DBEntitiesProxy())
            {
                db.Place.Add(new Place()
                {
                    Name = model.Name,
                    Content = model.Content,
                    Photo_URI = model.Photo_URI,
                    CountryId = model.CountryId,
                    IsAccepted = false,
                    UserId = userModel.GetUserID(model.UserEmail)
                });
                db.SaveChanges();
            }
        }
        public void Accept(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var place = db.Place.Where(x => x.PlaceId == id).SingleOrDefault();
                if(place != null)
                {
                    place.IsAccepted = true;
                }
               
                db.SaveChanges();
            }
        }
        public PlaceViewModel GetPlace(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI, Score = (int)x.Ranking }).Where(x => x.PlaceId == id).SingleOrDefault();
            }

        }
        public List<PlaceViewModel> GetPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName+" "+x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
        }
        public List<PlaceViewModel> GetAccpetedPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == true).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
        }
        public List<PlaceViewModel> GetNotAccpetedPlaces()
        {
            var db = new DBEntitiesProxy();
            return db.Place.Where(x => x.IsAccepted == false).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
        }
        public List<PlaceViewModel> GetPlacesAddedByUser(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Where(x => x.UserId == id).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
            }
        }
        public List<PlaceViewModel> GetPlacesAddedByUser(string email)
        {
            using (var db = new DBEntitiesProxy())
            {
                return db.Place.Where(x => x.User.Email == email).Select(x => new PlaceViewModel { PlaceId = x.PlaceId, Name = x.Name, Content = x.Content, UserName = x.User.FirstName + " " + x.User.LastName, Country = x.Country.Name, Photo_URI = x.Photo_URI }).ToList();
            }
        }
    }
}
