using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    public class RankingController : Controller
    {
        // GET: Ranking
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ranking/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ranking/Create
        public ActionResult Create(int placeId, int score)
        {
            CreateRankingViewModel model = new CreateRankingViewModel { PlaceId = placeId, Score = score, UserEmail = User.Identity.Name };
            ViewBag.PlaceId = placeId;
            return PartialView(model);
        }

        // POST: Ranking/Create
        [HttpPost]
        public void Create(CreateRankingViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
            }
            catch
            {
                
            }
        }

        // GET: Ranking/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ranking/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ranking/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ranking/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
