using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebProject.Models.ViewModels;

namespace WebProject.Models
{
    public class RankingService
    {
        public void Create(CreateRankingViewModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var userId = db.User.Where(x => x.Email == model.UserEmail).Select(x => x.UserId).Single();
                db.Ranking.Add(new Ranking
                {
                    Score = model.Score,
                    PlaceId = model.PlaceId,
                    UserId = userId
                });
                var list = db.Ranking.Where(x => x.PlaceId == model.PlaceId).Select(x => x.Score).ToList();
                double avg = model.Score;
                if (list.Count>0)
                {
                    avg = list.Average();
                }
                var place = db.Place.Where(x => x.PlaceId == model.PlaceId).SingleOrDefault();
                if (place != null)
                {
                    place.Ranking = Convert.ToInt32(avg);
                }
                db.SaveChanges();
            }
        }

        public int GetScoreByPlaceId(int id)
        {
            using (var db = new DBEntitiesProxy())
            {
                var score = db.Ranking.Where(x => x.PlaceId == id).Select(x => x.Place.Ranking).SingleOrDefault();
                if (score != null)
                    return score.Value;
                else return 0;
            }
        }
        public int GetScoreByUser(CreateRankingViewModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var userId = db.User.Where(x => x.Email == model.UserEmail).Select(x => x.UserId).Single();
                var score = db.Ranking.Where(x => x.PlaceId == model.PlaceId && x.UserId == userId)
                    .Select(x => x.Place.Ranking).SingleOrDefault();
                if (score != null)
                    return score.Value;
                else return 0;
            }
        }
        public void UpdateRanking(CreateRankingViewModel model)
        {
            using (var db = new DBEntitiesProxy())
            {
                var userId = db.User.Where(x => x.Email == model.UserEmail).Select(x => x.UserId).Single();
                var score = db.Ranking.Where(x => x.PlaceId == model.PlaceId && x.UserId == userId)
                   .SingleOrDefault();
                score.Score = model.Score;

                var avg = db.Ranking.Where(x => x.PlaceId == model.PlaceId).Select(x => x.Score).ToList().Average();
                var place = db.Place.Where(x => x.PlaceId == model.PlaceId).SingleOrDefault();
                if (place != null)
                {
                    place.Ranking = Convert.ToInt32(avg);
                }
                db.SaveChanges();
            }
        }
    }
}
