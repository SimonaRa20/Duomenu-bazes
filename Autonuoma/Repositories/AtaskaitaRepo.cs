using MySql.Data.MySqlClient;
using System.Data;
using ServicesReport = Org.Ktu.Isk.P175B602.Autonuoma.ViewModels.ServicesReport;

namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    public class AtaskaitaRepo
    {
        public static List<ServicesReport.Knyga> GetServicesOrdered(DateTime? dateFrom, DateTime? dateTo)
        {
            var result = new List<ServicesReport.Knyga>();

            var query =
                $@"SELECT
					a.vardas, a.pavarde, k.leidimo_metai,
					k.pavadinimas, l.pavadinimas AS leidykla, z.pavadinimas AS zanras, SUM(k.kiekis) AS kiekis
				FROM
                    knygos k
					LEFT JOIN `autoriai` a ON a.id = k.fk_autoriusid_autorius
                    LEFT JOIN `leidyklos` l ON l.id = k.fk_leidyklaid_leidykla
                    LEFT JOIN `zanrai` z ON z.id = k.fk_zanrasid_zanras
				WHERE
					a.id = k.fk_autoriusid_autorius
					AND k.leidimo_metai >= IFNULL(?nuo, k.leidimo_metai)
					AND k.leidimo_metai <= IFNULL(?iki, k.leidimo_metai)
				GROUP BY
					a.vardas, a.pavarde, k.pavadinimas
				ORDER BY
					kiekis DESC";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
                    args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
                });

            foreach (DataRow item in dt)
            {

                result.Add(new ServicesReport.Knyga
                {
                    Vardas = Convert.ToString(item["vardas"]),
                    Pavarde = Convert.ToString(item["pavarde"]),
                    Leidimo_metai = Convert.ToDateTime(item["leidimo_metai"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    Leidykla = Convert.ToString(item["leidykla"]),
                    Zanras = Convert.ToString(item["zanras"]),
                    Kiekis = Convert.ToInt32(item["kiekis"])
                }); ;
            }

            return result;
        }
        public static ServicesReport.Report GetTotalServicesOrdered(DateTime? dateFrom, DateTime? dateTo)
        {
            var result = new ServicesReport.Report();

            var query =
                $@"SELECT
					a.vardas, a.pavarde, k.leidimo_metai,
					k.pavadinimas, l.pavadinimas AS leidykla, z.pavadinimas AS zanras, SUM(k.kiekis) AS kiekis
				FROM
                    knygos k
					LEFT JOIN `autoriai` a ON a.id = k.fk_autoriusid_autorius
                    LEFT JOIN `leidyklos` l ON l.id = k.fk_leidyklaid_leidykla
                    LEFT JOIN `zanrai` z ON z.id = k.fk_zanrasid_zanras
				WHERE
					a.id = k.fk_autoriusid_autorius
					AND k.leidimo_metai >= IFNULL(?nuo, k.leidimo_metai)
					AND k.leidimo_metai <= IFNULL(?iki, k.leidimo_metai)
				GROUP BY
					a.vardas, a.pavarde, k.pavadinimas
				ORDER BY
					kiekis DESC";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?nuo", MySqlDbType.DateTime).Value = dateFrom;
                    args.Add("?iki", MySqlDbType.DateTime).Value = dateTo;
                });

            foreach (DataRow item in dt)
            {
                result.VisoUzsakyta = result.VisoUzsakyta + Convert.ToInt32(item["kiekis"] == System.DBNull.Value ? 0 : item["kiekis"]);
            }

            return result;
        }
    }
}
