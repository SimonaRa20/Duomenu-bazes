using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    public class LeidyklaRepo
    {
        public static List<Leidykla> List()
        {
            var leidyklos = new List<Leidykla>();

            string query = $@"SELECT * FROM `leidyklos` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                leidyklos.Add(new Leidykla
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    Adresas = Convert.ToString(item["adresas"])
                });
            }

            return leidyklos;
        }

        public static Leidykla Find(int id)
        {
            var leidykla = new Leidykla();

            var query = $@"SELECT * FROM `leidyklos` WHERE id=?id";
            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                leidykla.Id = Convert.ToInt32(item["id"]);
                leidykla.Pavadinimas = Convert.ToString(item["pavadinimas"]);
                leidykla.Adresas = Convert.ToString(item["adresas"]);
            }

            return leidykla;
        }

        public static void Update(Leidykla leidykla)
        {
            var query =
                $@"UPDATE `leidyklos` 
				SET 
					pavadinimas=?pavadinimas
                    adresas=?adresas
				WHERE 
					id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = leidykla.Pavadinimas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = leidykla.Adresas;
                args.Add("?id", MySqlDbType.VarChar).Value = leidykla.Id;
            });
        }

        public static void Insert(Leidykla leidykla)
        {
            var query = $@"INSERT INTO `leidyklos` ( id, pavadinimas, adresas ) VALUES ( ?id, ?pavadinimas, ?adresas )";
            Sql.Insert(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = leidykla.Pavadinimas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = leidykla.Adresas;
                args.Add("?id", MySqlDbType.VarChar).Value = leidykla.Id;


            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `leidyklos` where id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}