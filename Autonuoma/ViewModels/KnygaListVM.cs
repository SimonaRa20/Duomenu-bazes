using System.ComponentModel;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Knyga' entity in list.
    /// </summary>
    public class KnygaListVM
    {
        [DisplayName("ISBN")]
        public int ISBN { get; set; }

        [DisplayName("Pavadinimas")]
        public string Pavadinimas { get; set; }

        [DisplayName("Autorius")]
        public string Autorius { get; set; }

        [DisplayName("Leidykla")]
        public string Leidykla { get; set; }

        [DisplayName("Žanras")]
        public string Zanras { get; set; }
    }
}