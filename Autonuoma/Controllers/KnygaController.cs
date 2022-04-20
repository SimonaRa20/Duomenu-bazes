using Autonuoma.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for working with 'Automobilis' entity.
    /// </summary>
    public class KnygaController : Controller
    {
        /// <summary>
        /// This is invoked when either 'Index' action is requested or no action is provided.
        /// </summary>
        /// <returns>Entity list view.</returns>
        public ActionResult Index()
        {
            return View(KnygosRepo.List());
        }

        public ActionResult Create()
        {
            var knygaEvm = new KnygaEditVM();
            PopulateSelections(knygaEvm);

            return View(knygaEvm);
        }

        /// <summary>
        /// This is invoked when creation form is first opened in browser.
        /// </summary>
        /// <returns>Creation form view.</returns>

        [HttpPost]
        public ActionResult Create(int? save, int? add, int? remove, KnygaEditVM knygaEditVM)
        {
            if (add != null)
            {
                KnygaEditVM.KnygaM addNew = new KnygaEditVM.KnygaM()
                {
                    ISBN = knygaEditVM.NaujaKnyga.Count > 0 ? knygaEditVM.NaujaKnyga.Max(it => it.ISBN) + 1 : 0,
                    Pavadinimas = null,
                    Puslapiu_skaicius = 0,
                    LeidimoMetai = null,
                    Kalba = null,
                    Kiekis = 0,
                    FkZanras = 0,
                    FkAutorius = 0,
                    FkLeidykla = 0
                };
                knygaEditVM.NaujaKnyga.Add(addNew);
                ModelState.Clear();
                PopulateSelections(knygaEditVM);
                return View(knygaEditVM);
            }
            if (remove != null)
            {
                knygaEditVM.NaujaKnyga =
                    knygaEditVM
                        .NaujaKnyga
                        .Where(it => Convert.ToInt32(it.ISBN) != remove.Value)
                        .ToList();

                ModelState.Clear();

                PopulateSelections(knygaEditVM);
                return View(knygaEditVM);
            }

            if (save != null)
            {
                if (ModelState.IsValid)
                {
                    KnygosRepo.Insert(knygaEditVM);

                    foreach (var upVm in knygaEditVM.NaujaKnyga)
                        KnygosRepo.Insert(knygaEditVM.Knyga.ISBN, upVm);

                    return RedirectToAction("Index");
                }
                else
                {
                    PopulateSelections(knygaEditVM);
                    return View(knygaEditVM);
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
            var knygaEevm = KnygosRepo.Find(id);
            PopulateSelections(knygaEevm);

            return View(knygaEevm);
        }

        /// <summary>
        /// This is invoked when buttons are pressed in the editing form.
        /// </summary>
        /// <param name="id">ID of the entity being edited</param>		
        /// <param name="autoEvm">Entity model filled with latest data.</param>
        /// <returns>Returns editing from view or redirects back to Index if save is successfull.</returns>
        [HttpPost]
        public ActionResult Edit(int id, KnygaEditVM knygaEvm)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                KnygosRepo.Update(knygaEvm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }

            //form field validation failed, go back to the form
            PopulateSelections(knygaEvm);
            return View(knygaEvm);
        }

        /// </summary>
        /// <param name="id">ID of the entity to delete.</param>
        /// <returns>Deletion form view.</returns>
        public ActionResult Delete(int id)
        {
            var knygaEvm = KnygosRepo.Find(id);
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
                KnygosRepo.Delete(id);

                //deletion success, redired to list form
                return RedirectToAction("Index");
            }
            //entity in use, deletion not permitted
            catch (MySql.Data.MySqlClient.MySqlException)
            {
                //enable explanatory message and show delete form
                ViewData["deletionNotPermitted"] = true;

                var knygaEvm = KnygosRepo.Find(id);
                PopulateSelections(knygaEvm);

                return View("Delete", knygaEvm);
            }
        }

        /// <summary>
        /// Populates select lists used to render drop down controls.
        /// </summary>
        /// <param name="autoEvm">'Automobilis' view model to append to.</param>
        public void PopulateSelections(KnygaEditVM knygaEvm)
        {
            //load entities for the select lists
            var zanrai = ZanrasRepo.List();
            var autoriai = AutoriusRepo.List();
            var leidyklos = LeidyklaRepo.List();
            var busenos = KnygosBusenaRepo.List();

            //build select lists
            knygaEvm.Lists.Autoriai =
                autoriai.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Vardas + " " + it.Pavarde
                        };
                })
                .ToList();

            knygaEvm.Lists.Zanrai =
                zanrai.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Pavadinimas
                        };
                })
                .ToList();

            knygaEvm.Lists.Leidyklos =
                leidyklos.Select(it =>
                {
                    return
                        new SelectListItem()
                        {
                            Value = Convert.ToString(it.Id),
                            Text = it.Pavadinimas
                        };
                })
                .ToList();


            knygaEvm.Lists.Busenos =
                busenos.Select(it =>
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
