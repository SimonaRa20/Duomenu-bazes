using System.ComponentModel;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    public class SkaitytojasListVM
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Vardas")]
        public string Vardas { get; set; }

        [DisplayName("Pavardė")]
        public string Pavarde { get; set; }

        [DisplayName("Kategorija")]
        public string Kategorija { get; set; }
    }
}