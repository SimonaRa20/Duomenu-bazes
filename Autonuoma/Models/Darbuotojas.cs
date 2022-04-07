using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
    /// <summary>
    /// Model of 'Darbuotojas' entity.
    /// </summary>
    public class Darbuotojas
    {
        [DisplayName("Tabelio Nr.")]
        [MaxLength(10)]
        [Required]
        public string Tabelis { get; set; }

        [DisplayName("Vardas")]
        [Required]
        public string Vardas { get; set; }

        [DisplayName("Pavardė")]
        [Required]
        public string Pavarde { get; set; }

        [DisplayName("Telefonas")]
        [Required]
        public string Telefonas { get; set; }
    }
}