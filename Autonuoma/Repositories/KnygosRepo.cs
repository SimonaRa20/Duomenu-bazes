using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Automobilis' entity.
    /// </summary>
    public class KnygosRepo
    {
        public static List<KnygaListVM> List()
        {
            var knygos = new List<KnygaListVM>();

            var query =
                $@"SELECT
					a.ISBN,
					a.pavadinimas,
                    CONCAT(b.vardas, ' ', b.pavarde) AS autorius,
					m.pavadinimas AS leidykla,
					mm.pavadinimas AS zanras
				FROM
					knygos a
					LEFT JOIN `autoriai` b ON b.id = a.fk_autoriusid_autorius
					LEFT JOIN `leidyklos` m ON m.id = a.fk_leidyklaid_leidykla
					LEFT JOIN `zanrai` mm ON mm.id = a.fk_zanrasid_zanras
				ORDER BY a.ISBN ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                knygos.Add(new KnygaListVM
                {
                    ISBN = Convert.ToInt32(item["ISBN"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    Autorius = Convert.ToString(item["autorius"]),
                    Leidykla = Convert.ToString(item["leidykla"]),
                    Zanras = Convert.ToString(item["zanras"])
                });
            }

            return knygos;
        }

        public static KnygaEditVM Find(int id)
        {
            var knygaEvm = new KnygaEditVM();

            var query = $@"SELECT * FROM `knygos` WHERE isbn=?isbn";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?isbn", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                knygaEvm.Knyga.ISBN = Convert.ToInt32(item["ISBN"]);
                knygaEvm.Knyga.Pavadinimas = Convert.ToString(item["pavadinimas"]);
                knygaEvm.Knyga.Puslapiu_skaicius = Convert.ToInt32(item["puslapiu_skaicius"]);
                knygaEvm.Knyga.LeidimoMetai = Convert.ToDateTime(item["leidimo_metai"]);
                knygaEvm.Knyga.Kalba = Convert.ToString(item["kalba"]);
                knygaEvm.Knyga.Kiekis = Convert.ToInt32(item["kiekis"]);
                knygaEvm.Knyga.Busena = Convert.ToInt32(item["busena"]);

                knygaEvm.Knyga.FkZanras = Convert.ToInt32(item["fk_zanrasid_zanras"]);
                knygaEvm.Knyga.FkAutorius = Convert.ToInt32(item["fk_autoriusid_autorius"]);
                knygaEvm.Knyga.FkLeidykla = Convert.ToInt32(item["fk_leidyklaid_leidykla"]);
            }

            return knygaEvm;
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
					`fk_zanrasid_zanras`,
					`fk_autoriusid_autorius`,
					`fk_leidyklaid_leidykla`
				)
				VALUES (
					?ISBN,
					?pavadinimas,
					?puslapiu_skaicius,
					?leidimo_metai,
					?kalba,
					?kiekis,
					?busena,
					?fk_zanrasid_zanras,
					?fk_autoriusid_autorius,
					?fk_leidyklaid_leidykla
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?ISBN", MySqlDbType.Int32).Value = knygaEvm.Knyga.ISBN;
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Pavadinimas;
                args.Add("?puslapiu_skaicius", MySqlDbType.Int32).Value = knygaEvm.Knyga.Puslapiu_skaicius;
                args.Add("?leidimo_metai", MySqlDbType.Date).Value = knygaEvm.Knyga.LeidimoMetai?.ToString("yyyy-MM-dd");
                args.Add("?kalba", MySqlDbType.VarChar).Value = knygaEvm.Knyga.Kalba;
                args.Add("?kiekis", MySqlDbType.Int32).Value = knygaEvm.Knyga.Kiekis;
                args.Add("?busena", MySqlDbType.Int32).Value = knygaEvm.Knyga.Busena;
                args.Add("?fk_zanrasid_zanras", MySqlDbType.Int32).Value = knygaEvm.Knyga.FkZanras;
                args.Add("?fk_autoriusid_autorius", MySqlDbType.Int32).Value = knygaEvm.Knyga.FkAutorius;
                args.Add("?fk_leidyklaid_leidykla", MySqlDbType.Int32).Value = knygaEvm.Knyga.FkLeidykla;

            });
        }

        public static void Insert(int ISBN, KnygaEditVM.KnygaM knygaEvm)
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
					`fk_zanrasid_zanras`,
					`fk_autoriusid_autorius`,
					`fk_leidyklaid_leidykla`
				)
				VALUES (
					?ISBN,
					?pavadinimas,
					?puslapiu_skaicius,
					?leidimo_metai,
					?kalba,
					?kiekis,
					?busena,
					?fk_zanrasid_zanras,
					?fk_autoriusid_autorius,
					?fk_leidyklaid_leidykla
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?ISBN", MySqlDbType.Int32).Value = knygaEvm.ISBN;
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = knygaEvm.Pavadinimas;
                args.Add("?puslapiu_skaicius", MySqlDbType.Int32).Value = knygaEvm.Puslapiu_skaicius;
                args.Add("?leidimo_metai", MySqlDbType.Date).Value = knygaEvm.LeidimoMetai?.ToString("yyyy-MM-dd");
                args.Add("?kalba", MySqlDbType.VarChar).Value = knygaEvm.Kalba;
                args.Add("?kiekis", MySqlDbType.Int32).Value = knygaEvm.Kiekis;
                args.Add("?busena", MySqlDbType.Int32).Value = knygaEvm.Busena;
                args.Add("?fk_zanrasid_zanras", MySqlDbType.Int32).Value = knygaEvm.FkZanras;
                args.Add("?fk_autoriusid_autorius", MySqlDbType.Int32).Value = knygaEvm.FkAutorius;
                args.Add("?fk_leidyklaid_leidykla", MySqlDbType.Int32).Value = knygaEvm.FkLeidykla;
            });
        }

        public static void Update(KnygaEditVM knygaEvm)
        {
            var query =
                $@"UPDATE `knygos`
				SET
					`ISBN` = ?isbn,
					`pavadinimas` = ?pav,
					`puslapiu_skaicius` = ?pusl_sk,
					`leidimo_metai` = ?leidimometai,
					`kalba` = ?kalba,
					`kiekis` = ?kiek,
					`busena` = ?bus,
					`fk_zanrasid_zanras` = ?zan,
					`fk_autoriusid_autorius` = ?autor,
					`fk_leidyklaid_leidykla` = ?leid
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