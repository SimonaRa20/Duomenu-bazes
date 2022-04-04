using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Darbuotojas' entity.
    /// </summary>
    public class DarbuotojasRepo
    {
        public static List<Darbuotojas> List()
        {
            var darbuotojai = new List<Darbuotojas>();

            string query = $@"SELECT * FROM `darbuotojai` ORDER BY tabelio_nr ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                darbuotojai.Add(new Darbuotojas
                {
                    Tabelis = Convert.ToString(item["tabelio_nr"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Telefonas = Convert.ToString(item["telefonas"])
                });
            }

            return darbuotojai;
        }

        public static Darbuotojas Find(string tabnr)
        {
            var query = $@"SELECT * FROM `darbuotojai` WHERE tabelio_nr=?tab";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?tab", MySqlDbType.VarChar).Value = tabnr;
                });

            if (dt.Count > 0)
            {
                var darbuotojas = new Darbuotojas();

                foreach (DataRow item in dt)
                {
                    darbuotojas.Tabelis = Convert.ToString(item["tabelio_nr"]);
                    darbuotojas.Vardas = Convert.ToString(item["vardas"]);
                    darbuotojas.Pavarde = Convert.ToString(item["pavarde"]);
                    darbuotojas.Telefonas = Convert.ToString(item["telefonas"]);
                }

                return darbuotojas;
            }

            return null;
        }

        public static void Update(Darbuotojas darb)
        {
            var query =
                $@"UPDATE `darbuotojai`
				SET 
					vardas=?vardas, 
					pavarde=?pavarde,
					telefonas=?telefonas
				WHERE 
					tabelio_nr=?tab";

            Sql.Update(query, args =>
            {
                args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Pavarde;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = darb.Telefonas;
                args.Add("?tab", MySqlDbType.VarChar).Value = darb.Tabelis;
            });
        }

        public static void Insert(Darbuotojas darb)
        {
            var query =
                $@"INSERT INTO `darbuotojai`
				(
					tabelio_nr,
					vardas,
					pavarde,
					telefonas
				)
				VALUES(
					?tabelio_nr,
					?vardas,
					?pavarde,
					?telefonas
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?vardas", MySqlDbType.VarChar).Value = darb.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = darb.Pavarde;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = darb.Telefonas;
                args.Add("?tabelio_nr", MySqlDbType.VarChar).Value = darb.Tabelis;
            });
        }

        public static void Delete(string id)
        {
            var query = $@"DELETE FROM `darbuotojai` WHERE tabelio_nr=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.VarChar).Value = id;
            });
        }
    }
}