using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    public class PlaceController : Controller
    {
        UserModel userModel = new UserModel();
        PlaceModel placeModel = new PlaceModel();
        // GET: Places
        public ActionResult Index()
        {
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            ViewBag.Admin = isAdmin;
            if (isAdmin)
            {
                return View(placeModel.GetPlaces());
            }
            else
            {
                return View(placeModel.GetAccpetedPlaces());
            }

        }

        // GET: Place/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.PlaceId = id;
            return View(placeModel.GetPlace(id));
        }
        public ActionResult PlaceByUser(int id)
        {
            return PartialView(placeModel.GetPlacesAddedByUser(id));
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Place/Create
        [HttpPost]
        public ActionResult Create(CreatePlaceViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    placeModel.Create(model);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
            return View(model);
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Place/Edit/5
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

        // GET: Place/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Place/Delete/5
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
