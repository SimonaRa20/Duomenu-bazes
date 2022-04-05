using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;

namespace Autonuoma.Repositories
{
    public class AutoriusRepo
    {
        public static List<Autorius> List()
        {
            var autoriai = new List<Autorius>();

            string query = $@"SELECT * FROM `autoriai` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                autoriai.Add(new Autorius
                {
                    Id = Convert.ToInt32(item["id"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                });
            }

            return autoriai;
        }

        public static Autorius Find(int id)
        {
            var autorius = new Autorius();

            var query = $@"SELECT * FROM `autoriai` WHERE id=?id";
            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                autorius.Id = Convert.ToInt32(item["id"]);
                autorius.Vardas = Convert.ToString(item["vardas"]);
                autorius.Pavarde = Convert.ToString(item["pavarde"]);
            }

            return autorius;
        }

        public static void Update(Autorius autorius)
        {
            var query =
                $@"UPDATE `autoriai` 
				SET 
					vardas=?vardas,
                    pavarde=?pavarde
				WHERE 
					id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?vardas", MySqlDbType.VarChar).Value = autorius.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = autorius.Pavarde;
                args.Add("?id", MySqlDbType.VarChar).Value = autorius.Id;
            });
        }

        public static void Insert(Autorius autorius)
        {
            var query = $@"INSERT INTO `autoriai` ( vardas, pavarde ) VALUES ( ?vardas, ?pavarde )";
            Sql.Insert(query, args =>
            {
                args.Add("?vardas", MySqlDbType.VarChar).Value = autorius.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = autorius.Pavarde;
            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `autoriai` where id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}
