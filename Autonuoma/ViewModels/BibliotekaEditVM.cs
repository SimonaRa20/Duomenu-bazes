using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Automobilis' entity in creation and editing forms.
    /// </summary>
    public class BibliotekaEditVM
    {
        /// <summary>
        /// Entity data.
        /// </summary>
        public class BibliotekaM
        {
            [DisplayName("Id")]
            [Required]
            public int Id { get; set; }

            [DisplayName("Pavadinimas")]
            [Required]
            public string Pavadinimas { get; set; }

            [DisplayName("Adresas")]
            [Required]
            public string Adresas { get; set; }

            [DisplayName("Telefonas")]
            [Required]
            public string Telefonas { get; set; }

            [DisplayName("El_pastas")]
            [Required]
            public string El_pastas { get; set; }

            [DisplayName("Darbo_laikas")]
            [Required]
            public string Darbo_laikas { get; set; }

            [DisplayName("Tipas")]
            [Required]
            public int FkTipas { get; set; }

            [DisplayName("Miestas")]
            [Required]
            public int FkMiestas { get; set; }
        }

        /// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
        public class ListsM
        {
            public IList<SelectListItem> Tipai { get; set; }
            public IList<SelectListItem> Miestai { get; set; }
        }


        /// <summary>
        /// Entity view.
        /// </summary>
        public BibliotekaM Biblioteka { get; set; } = new BibliotekaM();

        /// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
    }
}