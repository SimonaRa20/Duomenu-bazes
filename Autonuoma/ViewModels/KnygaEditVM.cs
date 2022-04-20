using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Automobilis' entity in creation and editing forms.
    /// </summary>
    public class KnygaEditVM
    {
        /// <summary>
        /// Entity data.
        /// </summary>
        public class KnygaM
        {
            [DisplayName("ISBN")]
            [Required]
            public int ISBN { get; set; }

            [DisplayName("Pavadinimas")]
            [Required]
            public string Pavadinimas { get; set; }

            [DisplayName("Puslapių sk.")]
            [Required]
            public int Puslapiu_skaicius { get; set; }

            [DisplayName("Leidimo metai")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            [Required]
            public DateTime? LeidimoMetai { get; set; }

            [DisplayName("Kalba")]
            [Required]
            public string Kalba { get; set; }

            [DisplayName("Kiekis")]
            [Required]
            public int Kiekis { get; set; }

            [DisplayName("Būsena")]
            public int? Busena { get; set; }

            [DisplayName("Žanras")]
            [Required]
            public int FkZanras { get; set; }

            [DisplayName("Autorius")]
            [Required]
            public int FkAutorius { get; set; }

            [DisplayName("Leidykla")]
            [Required]
            public int FkLeidykla { get; set; }



        }

        /// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
        public class ListsM
        {
            public IList<SelectListItem> Zanrai { get; set; }
            public IList<SelectListItem> Autoriai { get; set; }
            public IList<SelectListItem> Leidyklos { get; set; }
            public IList<SelectListItem> Busenos { get; set; }
        }

        public IList<KnygaM> NaujaKnyga { get; set; } = new List<KnygaM>();

        /// <summary>
        /// Entity view.
        /// </summary>
        public KnygaM Knyga { get; set; } = new KnygaM();

        /// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
    }
}