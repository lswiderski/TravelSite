using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    public class TravelsController : BaseController
    {
        private TravelsService travelsService = new TravelsService();
        // GET: Travels
        public ActionResult Index()
        {
            return View();
        }

        // GET: Travels/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Travels/Create
        public ActionResult Create(string UserEmail, int PlaceId)
        {
            CreateTravelViewModel model = new CreateTravelViewModel() { PlaceId = PlaceId, UserEmail = UserEmail, Date = System.DateTime.Now };
            travelsService.Create(model);
            return RedirectToAction("Index","Place");
        }

        // POST: Travels/Create
        [HttpPost]
        public ActionResult Create(CreateTravelViewModel model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    model.Date = System.DateTime.Now;
                    travelsService.Create(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return PartialView();
            }
        }

        // GET: Travels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Travels/Edit/5
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

        // GET: Travels/Delete/5
        public ActionResult RemoveVisit(int Id)
        {
            travelsService.RemoveVisit(Id, User.Identity.Name);
            return RedirectToAction("Details", "Place", new { @Id = Id });
        }

        // POST: Travels/Delete/5
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
