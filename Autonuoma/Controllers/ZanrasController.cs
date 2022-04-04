﻿using Autonuoma.Repositories;
using Microsoft.AspNetCore.Mvc;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;

namespace Autonuoma.Controllers
{

    public class ZanrasController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            var zanras = ZanrasRepo.List();
            return View(zanras);
        }

        /// <summary>
        /// This is invoked when creation form is first opened in browser.
        /// </summary>
        /// <returns>Creation form view.</returns>
        public ActionResult Create()
        {
            var zanras = new Zanras();
            return View(zanras);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the creation form.
        /// </summary>
        /// <param name="marke">Entity model filled with latest data.</param>
        /// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Create(Zanras zanras)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                ZanrasRepo.Insert(zanras);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            return View(zanras);
        }

        /// <summary>
        /// This is invoked when editing form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to edit.</param>
        /// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var zanras = ZanrasRepo.Find(id);
            return View(zanras);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>		
        /// <param name="zanras">Entity model filled with latest data.</param>
        /// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, Zanras zanras)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                ZanrasRepo.Update(zanras);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            return View(zanras);
        }

        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var zanras = ZanrasRepo.Find(id);
            return View(zanras);
        }

        /// <summary>
        /// This is invoked when deletion is confirmed in deletion form
        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view on error, redirects to Index on success.</returns>
        [HttpPost]
        public ActionResult DeleteConfirm(int id)
        {
            //try deleting, this will fail if foreign key constraint fails
            try
            {
                ZanrasRepo.Delete(id);

                //deletion success, redired to list form
                return RedirectToAction("Index");
            }
            //entity in use, deletion not permitted
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;

                var zanras = ZanrasRepo.Find(id);
                return View("Delete", zanras);
            }
        }
    }
}