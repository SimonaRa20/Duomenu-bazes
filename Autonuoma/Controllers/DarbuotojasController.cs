using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for working with 'Automobilis' entity.
    /// </summary>
    public class DarbuotojasController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            return View(DarbuotojaiRepo.List());
        }

        public ActionResult Create()
        {
            var darbuotojasEvm = new DarbuotojasEditVM();
            PopulateSelections(darbuotojasEvm);

            return View(darbuotojasEvm);
        }

        /// <summary>
        /// This is invoked when creation form is first opened in browser.
        /// </summary>
        /// <returns>Creation form view.</returns>

        [HttpPost]
        public ActionResult Create(int? save, int? add, int? remove, DarbuotojasEditVM darbuotojasEditVM)
        {
            if (add != null)
            {
                DarbuotojasEditVM.DarbuotojasM addNew = new DarbuotojasEditVM.DarbuotojasM()
                {
                    Tabelio_nr = darbuotojasEditVM.NaujasDarbuotojas.Count > 0 ? darbuotojasEditVM.NaujasDarbuotojas.Max(it => it.Tabelio_nr) + 1 : 0,
                    Vardas = null,
                    Pavarde = null,
                    Telefonas = null,
                    Val_atlyginimas = 0,
                    Atlyginimas = 0,
                    Banko_saskaita = null,
                    FkBiblioteka = 0,
                    FkPareigos = 0
                };
                darbuotojasEditVM.NaujasDarbuotojas.Add(addNew);
                ModelState.Clear();
                PopulateSelections(darbuotojasEditVM);
                return View(darbuotojasEditVM);
            }
            if (remove != null)
            {
                darbuotojasEditVM.NaujasDarbuotojas =
                    darbuotojasEditVM
                        .NaujasDarbuotojas
                        .Where(it => Convert.ToInt32(it.Tabelio_nr) != remove.Value)
                        .ToList();

                ModelState.Clear();

                PopulateSelections(darbuotojasEditVM);
                return View(darbuotojasEditVM);
            }

            if (save != null)
            {
                if (ModelState.IsValid)
                {
                    DarbuotojaiRepo.Insert(darbuotojasEditVM);

                    foreach (var upVm in darbuotojasEditVM.NaujasDarbuotojas)
                        DarbuotojaiRepo.Insert(darbuotojasEditVM.Darbuotojas.Tabelio_nr, upVm);

                    return RedirectToAction("Index");
                }
                else
                {
                    PopulateSelections(darbuotojasEditVM);
                    return View(darbuotojasEditVM);
                }
            }

            //should not reach here
            throw new Exception("Should not reach here.");
        }


        /// <summary>
        /// This is invoked when editing form is first opened in browser.
        /// </summary>
        /// <param name="id">ID of the entity to edit.</param>
        /// <returns>Editing form view.</returns>
        public ActionResult Edit(int id)
        {
            var darbuotojasEevm = DarbuotojaiRepo.Find(id);
            PopulateSelections(darbuotojasEevm);

            return View(darbuotojasEevm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>		
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, DarbuotojasEditVM darbuotojasEevm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                DarbuotojaiRepo.Update(darbuotojasEevm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(darbuotojasEevm);
            return View(darbuotojasEevm);
        }

        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var darbuotojasEvm = DarbuotojaiRepo.Find(id);
            return View(darbuotojasEvm);
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
                DarbuotojaiRepo.Delete(id);

                //deletion success, redired to list form
                return RedirectToAction("Index");
            }
            //entity in use, deletion not permitted
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;

                var darbuotojasEvm = DarbuotojaiRepo.Find(id);
                PopulateSelections(darbuotojasEvm);

                return View("Delete", darbuotojasEvm);
            }
        }

        /// <summary>
        /// Populates select lists used to render drop down controls.
        /// </summary>
        /// <param name="autoEvm">'Automobilis' view model to append to.</param>
        public void PopulateSelections(DarbuotojasEditVM darbuotojasEvm)
        {
            //load entities for the select lists
            var bibliotekos = BibliotekosRepo.List();
            var pareigos = PareigosRepo.List();


            //build select lists
            darbuotojasEvm.Lists.Bibliotekos =
                bibliotekos.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Pavadinimas
                        };
                })
                .ToList();

            darbuotojasEvm.Lists.Pareigos =
                pareigos.Select(it =>
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
