using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class TravelsService
    {
        public void Create(CreateTravelViewModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var userId = db.User.Where(x => x.Email == model.UserEmail).Select(x => x.UserId).Single();
                db.Travels.Add(new Travels
                {
                    Date = model.Date,
                    PlaceId = model.PlaceId,
                    UserId = userId
                });
                db.SaveChanges();
            }
        }

        public List<TravelsByUserViewModel> GetByUser(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var travels = db.Travels
                    .Where(x => x.UserId == id)
                    .Select(x => new TravelsByUserViewModel { Place = x.Place.Name, PlaceId = x.PlaceId })
                    .ToList();
                return travels;
            }
        }
        public void RemoveVisit(int placeId, string userEmail)
        {
            using (var db = new DBEntitiesProxy())
            {
                var visits = db.Travels
                    .Where(x => x.PlaceId == placeId && x.User.Email.Trim() == userEmail).ToList();
                foreach (var v in visits)
                {
                    db.Travels.Remove(v);
                }               
                db.SaveChanges();
            }
        }
    }
}
