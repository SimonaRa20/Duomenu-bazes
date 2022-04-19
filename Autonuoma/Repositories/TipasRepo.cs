using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations for 'AutoBusena' entity.
    /// </summary>
    public class TipasRepo
    {
        public static List<Tipas> List()
        {
            List<Tipas> tipas = new List<Tipas>();

            string sqlquery = @"SELECT a.id, a.pavadinimas FROM tipai a";
            var dt = Sql.Query(sqlquery);

            foreach (DataRow item in dt)
            {
                tipas.Add(new Tipas
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return tipas;
        }
    }
}