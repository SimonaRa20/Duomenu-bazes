using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
    public class Autorius
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Vardas")]
        [Required]
        public string Vardas { get; set; }

        [DisplayName("Pavarde")]
        [Required]
        public string Pavarde { get; set; }
    }
}