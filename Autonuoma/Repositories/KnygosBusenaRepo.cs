using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations for 'AutoBusena' entity.
    /// </summary>
    public class KnygosBusenaRepo
    {
        public static List<KnygosBusena> List()
        {
            List<KnygosBusena> busenos = new List<KnygosBusena>();

            string sqlquery = $@"SELECT * FROM `busenos`";
            var dt = Sql.Query(sqlquery);

            foreach (DataRow item in dt)
            {
                busenos.Add(new KnygosBusena
                {
                    Id = Convert.ToInt32(item["id_busenos"]),
                    Pavadinimas = Convert.ToString(item["name"])
                });
            }

            return busenos;
        }
    }
}