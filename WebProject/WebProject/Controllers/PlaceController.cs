using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    public class PlaceController : BaseController
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
        public ActionResult NotAccepted()
        {
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            ViewBag.Admin = isAdmin;
            if (isAdmin)
            {
                return View(placeModel.GetNotAccpetedPlaces());
            }
            else
            {
                return View(placeModel.GetAccpetedPlaces());
            }
        }
        public ActionResult GetPlaceByRanking()
        {
            return PartialView("PartialPlace", placeModel.GetPlacesByRanking());
        }
        public ActionResult GetPlaceByPopularDESC()
        {
            return PartialView("PartialPlace", placeModel.GetPlacesByPopularDesc());
        }
        public ActionResult GetPlaceByPopularASC()
        {
            return PartialView("PartialPlace",placeModel.GetPlacesByPopularASC());
        }
        public ActionResult GetPlaceByAddDate()
        {
            return PartialView("PartialPlace", placeModel.GetPlacesByAdds());
        }
        public ActionResult SetRanking(CreateRankingViewModel model)
        {
            return View();
        }
        // GET: Place/Details/5
        public ActionResult Details(int id)
        {
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            ViewBag.Admin = isAdmin;
            ViewBag.PlaceId = id;
            return View(placeModel.GetPlace(id));
        }
        public ActionResult PlaceByUser(int id)
        {
            return PartialView(placeModel.GetPlacesAddedByUser(id));
        }
        public ActionResult Accept(int id)
        {
            placeModel.Accept(id);
            ViewBag.PlaceId = id;
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            ViewBag.Admin = isAdmin;
            return View("Details",placeModel.GetPlace(id));
        }

        // GET: Place/Create
        public ActionResult Create()
        {
            return View(placeModel.GetCountriesForCreate());
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
                    return RedirectToAction("Index");
                }
                return View(placeModel.GetCountriesForCreate());
            }
            catch
            {
                return View(placeModel.GetCountriesForCreate());
            }
        }

        // GET: Place/Edit/5
        public ActionResult Edit(int id)
        {
            return View(placeModel.GetPlaceToEdit(id));
        }

        // POST: Place/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditPlaceViewModel model)
        {
            try
            {
                model.PlaceId = id;
                placeModel.EditPlace(model);

                return RedirectToAction("Details",new { @Id = id});
            }
            catch
            {
                return RedirectToAction("Details", new { @Id = id });
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
