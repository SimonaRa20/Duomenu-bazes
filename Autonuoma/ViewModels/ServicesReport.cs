using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ServicesReport
{

    public class Knyga
    {
        [DisplayName("Vardas")]
        public string Vardas { get; set; }

        [DisplayName("Pavarde")]
        public string Pavarde { get; set; }

        [DisplayName("leidimo_metai")]
        public DateTime Leidimo_metai { get; set; }

        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }

        [DisplayName("Kiekis")]
        public int Kiekis { get; set; }
    }

    /// <summary>
    /// View model of the whole report.
    /// </summary>
    public class Report
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateFrom { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateTo { get; set; }

        public List<Knyga> Paslaugos { get; set; }

        public int VisoUzsakyta { get; set; }
    }

}
