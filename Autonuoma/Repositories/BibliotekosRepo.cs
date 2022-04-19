using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.ViewModels;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    /// <summary>
    /// Database operations related to 'Automobilis' entity.
    /// </summary>
    public class BibliotekosRepo
    {
        public static List<BibliotekaListVM> List()
        {
            var bibliotekos = new List<BibliotekaListVM>();

            var query =
                $@"SELECT
					a.id,
                    a.pavadinimas,
					b.pavadinimas AS miestas
				FROM
					bibliotekos a
					LEFT JOIN `miestas` b ON b.id = a.fk_miestasid_miestas
				ORDER BY a.id ASC";

            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                bibliotekos.Add(new BibliotekaListVM
                {
                    Id = Convert.ToInt32(item["Id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                    Miestas = Convert.ToString(item["miestas"])
                });
            }

            return bibliotekos;
        }

        public static BibliotekaEditVM Find(int id)
        {
            var bibliotekaEvm = new BibliotekaEditVM();

            var query = $@"SELECT * FROM `bibliotekos` WHERE id=?id";

            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                bibliotekaEvm.Biblioteka.Id = Convert.ToInt32(item["id"]);
                bibliotekaEvm.Biblioteka.Pavadinimas = Convert.ToString(item["pavadinimas"]);
                bibliotekaEvm.Biblioteka.Adresas = Convert.ToString(item["adresas"]);
                bibliotekaEvm.Biblioteka.Telefonas = Convert.ToString(item["telefonas"]);
                bibliotekaEvm.Biblioteka.El_pastas = Convert.ToString(item["el_pastas"]);
                bibliotekaEvm.Biblioteka.Darbo_laikas = Convert.ToString(item["darbo_laikas"]);
                bibliotekaEvm.Biblioteka.FkTipas = Convert.ToInt32(item["fk_tipasid_tipas"]);
                bibliotekaEvm.Biblioteka.FkMiestas = Convert.ToInt32(item["fk_miestasid_miestas"]);
            }

            return bibliotekaEvm;
        }

        public static void Insert(BibliotekaEditVM bibliotekaEvm)
        {
            var query =
                $@"INSERT INTO `bibliotekos`
				(
					`id`,
					`pavadinimas`,
					`adresas`,
					`telefonas`,
					`el_pastas`,
					`darbo_laikas`,
					`fk_tipasid_tipas`,
                    `fk_miestasid_miestas`
				)
				VALUES (
					?id,
					?pavadinimas,
					?adresas,
					?telefonas,
					?el_pastas,
					?darbo_laikas,
					?fk_tipasid_tipas,
					?fk_miestasid_miestas
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.Id;
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Pavadinimas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Adresas;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Telefonas;
                args.Add("?el_pastas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.El_pastas;
                args.Add("?darbo_laikas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Darbo_laikas;
                args.Add("?fk_tipasid_tipas", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.FkTipas;
                args.Add("?fk_miestasid_miestas", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.FkMiestas;

            });
        }

        public static void Update(BibliotekaEditVM bibliotekaEvm)
        {
            var query =
                $@"UPDATE `bibliotekos`
				SET
					`id` = ?id,
					`pavadinimas` = ?pavadinimas,
					`adresas` = ?adresas,
					`telefonas` = ?telefonas,
					`el_pastas` = ?el_pastas,
					`darbo_laikas` = ?darbo_laikas,
					`fk_tipasid_tipas` = ?fk_tipasid_tipas,
					`fk_miestasid_miestas` = ?fk_miestasid_miestas
				WHERE
					id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.Id;
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Pavadinimas;
                args.Add("?adresas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Adresas;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Telefonas;
                args.Add("?el_pastas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.El_pastas;
                args.Add("?darbo_laikas", MySqlDbType.VarChar).Value = bibliotekaEvm.Biblioteka.Darbo_laikas;
                args.Add("?fk_tipasid_tipas", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.FkTipas;
                args.Add("?fk_miestasid_miestas", MySqlDbType.Int32).Value = bibliotekaEvm.Biblioteka.FkMiestas;

            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `bibliotekos` WHERE id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}