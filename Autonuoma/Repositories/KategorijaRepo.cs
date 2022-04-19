using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations for 'AutoBusena' entity.
    /// </summary>
    public class KategorijaRepo
    {
        public static List<Kategorija> List()
        {
            List<Kategorija> busenos = new List<Kategorija>();

            string sqlquery = @"SELECT a.id_kategoriju_tipai, a.name FROM kategoriju_tipai a";
            var dt = Sql.Query(sqlquery);

            foreach (DataRow item in dt)
            {
                busenos.Add(new Kategorija
                {
                    Id = Convert.ToInt32(item["id_kategoriju_tipai"]),
                    Pavadinimas = Convert.ToString(item["name"])
                });
            }

            return busenos;
        }
    }
}