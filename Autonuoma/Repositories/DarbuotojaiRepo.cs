using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Automobilis' entity.
    /// </summary>
    public class DarbuotojaiRepo
    {
        public static List<DarbuotojasListVM> List()
        {
            var darbuotojai = new List<DarbuotojasListVM>();

            var query =
                $@"SELECT
					a.tabelio_nr,
                    CONCAT(a.vardas, ' ', a.pavarde) AS darbuotojas,
                    a.telefonas,
                    m.pavadinimas AS pareigos
				FROM
					darbuotojai a
					LEFT JOIN `pareigos` b ON b.id = a.fk_pareigosid_pareigos
				ORDER BY a.tabelio_nr ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                darbuotojai.Add(new DarbuotojasListVM
                {
                    Tabelio_nr = Convert.ToInt32(item["tabelio_nr"]),
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavardė = Convert.ToString(item["pavarde"]),
                    Telefonas = Convert.ToString(item["telefonas"]),
                    Pareigos = Convert.ToString(item["pareigos"])
                });
            }

            return darbuotojai;
        }

        public static DarbuotojasEditVM Find(int id)
        {
            var darbuotojasEvm = new DarbuotojasEditVM();

            var query = $@"SELECT * FROM `darbuotojai` WHERE tabelio_nr=?tabelio_nr";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?tabelio_nr", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                darbuotojasEvm.Darbuotojas.Tabelio_nr = Convert.ToInt32(item["tabelio_nr"]);
                darbuotojasEvm.Darbuotojas.Vardas = Convert.ToString(item["vardas"]);
                darbuotojasEvm.Darbuotojas.Pavarde = Convert.ToString(item["pavarde"]);
                darbuotojasEvm.Darbuotojas.Telefonas = Convert.ToString(item["telefonas"]);
                darbuotojasEvm.Darbuotojas.Val_atlyginimas = Convert.ToInt32(item["val_atlyginimas"]);
                darbuotojasEvm.Darbuotojas.Atlyginimas = Convert.ToInt32(item["atlyginimas"]);
                darbuotojasEvm.Darbuotojas.Banko_saskaita = Convert.ToString(item["banko_saskaita"]);

                darbuotojasEvm.Darbuotojas.FkBiblioteka = Convert.ToInt32(item["fk_bibliotekaid_biblioteka"]);
                darbuotojasEvm.Darbuotojas.FkPareigos = Convert.ToInt32(item["fk_pareigosid_pareigos"]);
            }

            return darbuotojasEvm;
        }

        public static void Insert(KnygaEditVM knygaEvm)
        {
            var query =
                $@"INSERT INTO `knygos`
				(
					`ISBN`,
					`pavadinimas`,
					`puslapiu_skaicius`,
					`leidimo_metai`,
					`kalba`,
					`kiekis`,
					`busena`,
					`zanras`,
					`autorius`,
					`leidykla`
				)
				VALUES (
					?isbn,
					?pav,
					?pusl_sk,
					?leidimometai,
					?kalba,
					?kiek,
					?bus,
					?zan,
					?autor,
					?leid
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?isbn", MySqlDbType.Int32).Value = knygaEvm.Knyga.ISBN;
                args.Add("?pav", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Pavadinimas;
                args.Add("?pusl_sk", MySqlDbType.Int32).Value = knygaEvm.Knyga.Puslapiu_skaicius;
                args.Add("?leidimometai", MySqlDbType.Date).Value = knygaEvm.Knyga.LeidimoMetai?.ToString("yyyy-MM-dd");
                args.Add("?kalba", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Kalba;
                args.Add("?kiek", MySqlDbType.Int32).Value = knygaEvm.Knyga.Kiekis;
                args.Add("?bus", MySqlDbType.Int32).Value = knygaEvm.Knyga.Busena;
                args.Add("?zan", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkZanras;
                args.Add("?autor", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkAutorius;
                args.Add("?leid", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkLeidykla;
            });
        }

        public static void Update(KnygaEditVM knygaEvm)
        {
            var query =
                $@"UPDATE `knyga`
				SET
					`ISBN` = ?isbn,
					`pavadinimas` = ?pav,
					`puslapiu_skaicius` = ?pusl_sk,
					`leidimo_metai` = ?leidimometai,
					`kalba` = ?kalba,
					`kiekis` = ?kiek,
					`busena` = ?bus,
					`zanras` = ?zan,
					`autorius` = ?autor,
					`leidykla` = ?leid
				WHERE
					ISBN=?isbn";

            Sql.Update(query, args =>
            {
                args.Add("?isbn", MySqlDbType.Int32).Value = knygaEvm.Knyga.ISBN;
                args.Add("?pav", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Pavadinimas;
                args.Add("?pusl_sk", MySqlDbType.Int32).Value = knygaEvm.Knyga.Puslapiu_skaicius;
                args.Add("?leidimometai", MySqlDbType.Date).Value = knygaEvm.Knyga.LeidimoMetai;
                args.Add("?kalba", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Kalba;
                args.Add("?kiek", MySqlDbType.Int32).Value = knygaEvm.Knyga.Kiekis;
                args.Add("?bus", MySqlDbType.Int32).Value = knygaEvm.Knyga.Busena;
                args.Add("?zan", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkZanras;
                args.Add("?autor", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkAutorius;
                args.Add("?leid", MySqlDbType.VarChar).Value = knygaEvm.Knyga.FkLeidykla;

            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `knygos` WHERE isbn=?isbn";
            Sql.Delete(query, args =>
            {
                args.Add("?isbn", MySqlDbType.Int32).Value = id;
            });
        }
    }
}