using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Automobilis' entity in creation and editing forms.
    /// </summary>
    public class SkaitytojasEditVM
    {
        /// <summary>
        /// Entity data.
        /// </summary>
        public class SkaitytojasM
        {
            [DisplayName("Id")]
            [Required]
            public int Id { get; set; }

            [DisplayName("Vardas")]
            [Required]
            public string Vardas { get; set; }

            [DisplayName("Pavardė")]
            [Required]
            public string Pavarde { get; set; }

            [DisplayName("Gimimo_data")]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            [Required]
            public DateTime? Gimimo_data { get; set; }

            [DisplayName("Telefonas")]
            [Required]
            public string Telefonas { get; set; }

            [DisplayName("El_pastas")]
            [Required]
            public string El_pastas { get; set; }


            [DisplayName("Adresas")]
            [Required]
            public string Adresas { get; set; }

            [DisplayName("Kategorija")]
            [Required]
            public int FkKategorija { get; set; }

        }

        /// <summary>
        /// Select lists for making drop downs for choosing values of entity fields.
        /// </summary>
        public class ListsM
        {
            public IList<SelectListItem> Kategorijos { get; set; }
        }

        /// <summary>
        /// Entity view.
        /// </summary>
        public SkaitytojasM Skaitytojas { get; set; } = new SkaitytojasM();

        /// <summary>
        /// Lists for drop down controls.
        /// </summary>
        public ListsM Lists { get; set; } = new ListsM();
    }
}