using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for working with 'Automobilis' entity.
    /// </summary>
    public class SkaitytojasController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            return View(SkaitytojaiRepo.List());
        }

        /// <summary>
        /// This is invoked when creation form is first opened in browser.
        /// </summary>
        /// <returns>Creation form view.</returns>
        public ActionResult Create()
        {
            var skaitytojasEvm = new SkaitytojasEditVM();
            PopulateSelections(skaitytojasEvm);

            return View(skaitytojasEvm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the creation form.
        /// </summary>
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Create(SkaitytojasEditVM skaitytojasEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                SkaitytojaiRepo.Insert(skaitytojasEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(skaitytojasEvm);
            return View(skaitytojasEvm);
        }

        /// <summary>
        /// This is invoked when editing form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to edit.</param>
        /// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var skaitytojasEevm = SkaitytojaiRepo.Find(id);
            PopulateSelections(skaitytojasEevm);

            return View(skaitytojasEevm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>		
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, SkaitytojasEditVM skaitytojasEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                SkaitytojaiRepo.Update(skaitytojasEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(skaitytojasEvm);
            return View(skaitytojasEvm);
        }

        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var knygaEvm = SkaitytojaiRepo.Find(id);
            return View(knygaEvm);
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
                SkaitytojaiRepo.Delete(id);

                //deletion success, redired to list form
                return RedirectToAction("Index");
            }
            //entity in use, deletion not permitted
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;

                var skaitytojasEvm = SkaitytojaiRepo.Find(id);
                PopulateSelections(skaitytojasEvm);

                return View("Delete", skaitytojasEvm);
            }
        }

        /// <summary>
        /// Populates select lists used to render drop down controls.
        /// </summary>
        /// <param name="autoEvm">'Automobilis' view model to append to.</param>
        public void PopulateSelections(SkaitytojasEditVM skaitytojasEvm)
        {
            //load entities for the select lists
            var kategorija = KategorijaRepo.List();

            //build select lists
            skaitytojasEvm.Lists.Kategorijos =
                kategorija.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Pavadinimas
                        };
                })
                .ToList();
        }
    }
}
