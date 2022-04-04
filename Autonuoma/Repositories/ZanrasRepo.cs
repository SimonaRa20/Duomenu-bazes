using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;

namespace Autonuoma.Repositories
{
    public class ZanrasRepo
    {
        public static List<Zanras> List()
        {
            var zanrai = new List<Zanras>();

            string query = $@"SELECT * FROM `zanrai` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                zanrai.Add(new Zanras
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }

            return zanrai;
        }

        public static Zanras Find(int id)
        {
            var zanras = new Zanras();

            var query = $@"SELECT * FROM `zanrai` WHERE id=?id";
            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                zanras.Id = Convert.ToInt32(item["id"]);
                zanras.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }

            return zanras;
        }

        public static void Update(Zanras zanras)
        {
            var query =
                $@"UPDATE `zanrai` 
				SET 
					pavadinimas=?pavadinimas 
				WHERE 
					id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = zanras.Pavadinimas;
                args.Add("?id", MySqlDbType.VarChar).Value = zanras.Id;
            });
        }

        public static void Insert(Zanras zanras)
        {
            var query = $@"INSERT INTO `zanrai` ( pavadinimas ) VALUES ( ?pavadinimas )";
            Sql.Insert(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = zanras.Pavadinimas;
            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `zanrai` where id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}
