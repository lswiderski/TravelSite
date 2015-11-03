using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;
using WebProject.Models.ViewModels;

namespace WebProject.Controllers
{
    public class CommentController : Controller
    {
        CommentModel commentModel = new CommentModel();

        // GET: Comment/Place/5 //list of comment by place
        public ActionResult Place(int id)
        {
            ViewBag.PlaceId = id;
            return PartialView(commentModel.GetCommentByPlace(id));
        }
        // GET: Comment/User/5 //list of comment by user
        public ActionResult User(int id)
        {
            return PartialView(commentModel.GetCommentByUser(id));
        }

        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }

        // GET: Comment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Comment/Create
        public ActionResult Create(int id)
        {
            ViewBag.PlaceId = id;
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        public ActionResult Create(CreateCommentViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    commentModel.Create(model);
                }
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(model);
            }
            return View(model);
        }

        // GET: Comment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Comment/Edit/5
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

        // GET: Comment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Comment/Delete/5
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
