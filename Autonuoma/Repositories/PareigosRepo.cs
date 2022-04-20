using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations for 'AutoBusena' entity.
    /// </summary>
    public class PareigosRepo
    {
        public static List<Pareigos> List()
        {
            List<Pareigos> pareigos = new List<Pareigos>();

            string sqlquery = @"SELECT a.id, a.pavadinimas FROM pareigos a";
            var dt = Sql.Query(sqlquery);

            foreach (DataRow item in dt)
            {
                pareigos.Add(new Pareigos
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return pareigos;
        }
    }
}