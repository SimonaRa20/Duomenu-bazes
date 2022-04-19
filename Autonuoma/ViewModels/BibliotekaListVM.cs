using System.ComponentModel;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    public class BibliotekaListVM
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }

        [DisplayName("Miestas")]
        public string Miestas { get; set; }
    }
}