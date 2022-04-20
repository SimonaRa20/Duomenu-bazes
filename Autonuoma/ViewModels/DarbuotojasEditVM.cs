using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Automobilis' entity in creation and editing forms.
    /// </summary>
    public class DarbuotojasEditVM
    {
        /// <summary>
        /// Entity data.
        /// </summary>
        public class DarbuotojasM
        {
            [DisplayName("Tabelio_nr")]
            [Required]
            public int Tabelio_nr { get; set; }

            [DisplayName("Vardas")]
            [Required]
            public string Vardas { get; set; }

            [DisplayName("Pavardė")]
            [Required]
            public string Pavarde { get; set; }

            [DisplayName("Telefonas")]
            [Required]
            public string Telefonas { get; set; }

            [DisplayName("Valandinis_atlyginimas")]
            [Required]
            public int Val_atlyginimas { get; set; }

            [DisplayName("Atlyginimas")]
            [Required]
            public int Atlyginimas { get; set; }

            [DisplayName("Banko_saskaita")]
            [Required]
            public string Banko_saskaita { get; set; }

            [DisplayName("Biblioteka")]
            [Required]
            public int FkBiblioteka { get; set; }

            [DisplayName("Pareigos")]
            [Required]
            public int FkPareigos { get; set; }
        }

        /// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
        public class ListsM
        {
            public IList<SelectListItem> Bibliotekos { get; set; }
            public IList<SelectListItem> Pareigos { get; set; }
        }

        public IList<DarbuotojasM> NaujasDarbuotojas { get; set; } = new List<DarbuotojasM>();

        /// <summary>
        /// Entity view.
        /// </summary>
        public DarbuotojasM Darbuotojas { get; set; } = new DarbuotojasM();

        /// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
    }
}