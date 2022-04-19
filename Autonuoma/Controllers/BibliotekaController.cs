using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for working with 'Automobilis' entity.
    /// </summary>
    public class BibliotekaController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            return View(BibliotekosRepo.List());
        }

        /// <summary>
        /// This is invoked when creation form is first opened in browser.
        /// </summary>
        /// <returns>Creation form view.</returns>
        public ActionResult Create()
        {
            var bibliotekaEvm = new BibliotekaEditVM();
            PopulateSelections(bibliotekaEvm);

            return View(bibliotekaEvm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the creation form.
        /// </summary>
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns creation from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Create(BibliotekaEditVM bibliotekaEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                BibliotekosRepo.Insert(bibliotekaEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(bibliotekaEvm);
            return View(bibliotekaEvm);
        }

        /// <summary>
        /// This is invoked when editing form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to edit.</param>
        /// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var bibliotekaEvm = BibliotekosRepo.Find(id);
            PopulateSelections(bibliotekaEvm);

            return View(bibliotekaEvm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>		
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, BibliotekaEditVM bibliotekaEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                BibliotekosRepo.Update(bibliotekaEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(bibliotekaEvm);
            return View(bibliotekaEvm);
        }

        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var bibliotekaEvm = BibliotekosRepo.Find(id);
            return View(bibliotekaEvm);
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
                BibliotekosRepo.Delete(id);

                //deletion success, redired to list form
                return RedirectToAction("Index");
            }
            //entity in use, deletion not permitted
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;

                var bibliotekaEvm = BibliotekosRepo.Find(id);
                PopulateSelections(bibliotekaEvm);

                return View("Delete", bibliotekaEvm);
            }
        }

        /// <summary>
        /// Populates select lists used to render drop down controls.
        /// </summary>
        /// <param name="autoEvm">'Automobilis' view model to append to.</param>
        public void PopulateSelections(BibliotekaEditVM bibliotekaEvm)
        {
            //load entities for the select lists
            var tipas = TipasRepo.List();
            var miestas = MiestasRepo.List();

            //build select lists
            bibliotekaEvm.Lists.Tipai =
                tipas.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Pavadinimas
                        };
                })
                .ToList();

            bibliotekaEvm.Lists.Miestai =
                miestas.Select(it =>
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
