using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CountryController : Controller
    {
        CountryModel countryModel = new CountryModel();
        UserModel userModel = new UserModel();

        // GET: Country
        public ActionResult Index()
        {
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            ViewBag.Admin = isAdmin;
            return View(countryModel.GetCountries());
        }

        // GET: Country/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            bool isAdmin = false;
            if (Request.IsAuthenticated)
            {
                isAdmin = userModel.CheckIfIsAdmin(User.Identity.Name);

            }
            return View();
        }

        // POST: Country/Create
        [HttpPost]
        public ActionResult Create(CountryModel model)
        {
            try
            {
                countryModel.Create(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Country/Edit/5
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

        // GET: Country/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Country/Delete/5
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
