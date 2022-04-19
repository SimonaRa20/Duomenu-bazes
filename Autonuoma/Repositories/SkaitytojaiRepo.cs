using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Automobilis' entity.
    /// </summary>
    public class SkaitytojaiRepo
    {
        public static List<SkaitytojasListVM> List()
        {
            var skaitytojai = new List<SkaitytojasListVM>();

            var query =
                $@"SELECT
					a.id,
                    a.vardas,a.pavarde,
					b.name AS kategorija
				FROM
					skaitytojai a
					LEFT JOIN `kategoriju_tipai` b ON b.id_kategoriju_tipai = a.kategorija
				ORDER BY a.id ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                skaitytojai.Add(new SkaitytojasListVM
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Kategorija = Convert.ToString(item["kategorija"])
                });
            }

            return skaitytojai;
        }

        public static SkaitytojasEditVM Find(int id)
        {
            var skaitytojasEvm = new SkaitytojasEditVM();

            var query = $@"SELECT * FROM `skaitytojai` WHERE id=?id";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                skaitytojasEvm.Skaitytojas.Id = Convert.ToInt32(item["Id"]);
                skaitytojasEvm.Skaitytojas.Vardas = Convert.ToString(item["vardas"]);
                skaitytojasEvm.Skaitytojas.Pavarde = Convert.ToString(item["pavarde"]);
                skaitytojasEvm.Skaitytojas.Gimimo_data = Convert.ToDateTime(item["gimimo_data"]);
                skaitytojasEvm.Skaitytojas.Telefonas = Convert.ToString(item["telefonas"]);
                skaitytojasEvm.Skaitytojas.El_pastas = Convert.ToString(item["el_pastas"]);
                skaitytojasEvm.Skaitytojas.Adresas = Convert.ToString(item["adresas"]);

                skaitytojasEvm.Skaitytojas.FkKategorija = Convert.ToInt32(item["kategorija"]);
            }

            return skaitytojasEvm;
        }

        public static void Insert(SkaitytojasEditVM skaitytojasEvm)
        {
            var query =
                $@"INSERT INTO `skaitytojai`
				(
					`id`,
					`vardas`,
					`pavarde`,
					`gimimo_data`,
					`telefonas`,
					`el_pastas`,
					`adresas`,
					`kategorija`
				)
				VALUES (
					?id,
					?vardas,
					?pavarde,
					?gimimodata,
					?telefonas,
					?el_pastas,
					?adresas,
					?kategorija
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = skaitytojasEvm.Skaitytojas.Id;
                args.Add("?vardas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Pavarde;
                args.Add("?gimimodata", MySqlDbType.Date).Value = skaitytojasEvm.Skaitytojas.Gimimo_data?.ToString("yyyy-MM-dd");
                args.Add("?telefonas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Telefonas;
                args.Add("?el_pastas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.El_pastas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Adresas;
                args.Add("?kategorija", MySqlDbType.Int32).Value = skaitytojasEvm.Skaitytojas.FkKategorija;

            });
        }

        public static void Update(SkaitytojasEditVM skaitytojasEvm)
        {
            var query =
                $@"UPDATE `skaitytojai`
				SET
					`Id` = ?id,
					`vardas` = ?vardas,
					`pavarde` = ?pavarde,
					`gimimo_data` = ?gimimodata,
					`telefonas` = ?telefonas,
					`el_pastas` = ?el_pastas,
					`adresas` = ?adresas,
					`kategorija` = ?kategorija
				WHERE
					Id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = skaitytojasEvm.Skaitytojas.Id;
                args.Add("?vardas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Pavarde;
                args.Add("?gimimodata", MySqlDbType.Date).Value = skaitytojasEvm.Skaitytojas.Gimimo_data?.ToString("yyyy-MM-dd");
                args.Add("?telefonas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Telefonas;
                args.Add("?el_pastas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.El_pastas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = skaitytojasEvm.Skaitytojas.Adresas;
                args.Add("?kategorija", MySqlDbType.Int32).Value = skaitytojasEvm.Skaitytojas.FkKategorija;

            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `skaitytojai` WHERE id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}