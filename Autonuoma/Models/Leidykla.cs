using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Models
{
    public class Leidykla
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        [Required]
        public string Pavadinimas { get; set; }
    }
}
