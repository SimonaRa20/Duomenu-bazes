using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations for 'AutoBusena' entity.
    /// </summary>
    public class MiestasRepo
    {
        public static List<Miestas> List()
        {
            List<Miestas> miestas = new List<Miestas>();

            string sqlquery = @"SELECT a.id, a.pavadinimas FROM miestas a";
            var dt = Sql.Query(sqlquery);

            foreach (DataRow item in dt)
            {
                miestas.Add(new Miestas
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"])
                });
            }

            return miestas;
        }
    }
}