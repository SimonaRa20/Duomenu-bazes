using Microsoft.AspNetCore.Mvc;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers
{
    /// <summary>
    /// Controller for producing reports.
    /// </summary>
    public class AtaskaitaController : Controller
    {
        /// <summary>
        /// Produces services report.
        /// </summary>
        /// <param name="dateFrom">Starting date. Can be null.</param>
        /// <param name="dateTo">Ending date. Can be null.</param>
        /// <returns>Report view.</returns>
        public ActionResult Paslaugos(DateTime? dateFrom, DateTime? dateTo)
        {
            var report = AtaskaitaRepo.GetTotalServicesOrdered(dateFrom, dateTo);
            report.DateFrom = dateFrom;
            report.DateTo = dateTo?.AddHours(23).AddMinutes(59).AddSeconds(59); //move time of end date to end of day

            report.Paslaugos = AtaskaitaRepo.GetServicesOrdered(dateFrom, dateTo);

            return View(report);
        }
    }
}
