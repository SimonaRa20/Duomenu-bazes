using System.ComponentModel;


namespace Org.Ktu.Isk.P175B602.Autonuoma.ViewModels
{
    /// <summary>
    /// View model for 'Knyga' entity in list.
    /// </summary>
    public class DarbuotojasListVM
    {
        [DisplayName("Tabelio_nr")]
        public int Tabelio_nr { get; set; }

        [DisplayName("Vardas")]
        public string Vardas { get; set; }

        [DisplayName("Pavardė")]
        public string Pavardė { get; set; }

        [DisplayName("Telefonas")]
        public string Telefonas { get; set; }

        [DisplayName("Pareigos")]
        public string Pareigos { get; set; }
    }
}