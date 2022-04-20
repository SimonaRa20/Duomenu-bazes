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
                    a.vardas,a.pavarde,
                    a.telefonas,
                    b.pavadinimas AS pareigos
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
                    Pavarde = Convert.ToString(item["pavarde"]),
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

        public static void Insert(DarbuotojasEditVM darbuotojasEvm)
        {
            var query =
                $@"INSERT INTO `darbuotojai`
				(
					`tabelio_nr`,
					`vardas`,
					`pavarde`,
					`telefonas`,
					`val_atlyginimas`,
					`atlyginimas`,
					`banko_saskaita`,
					`fk_bibliotekaid_biblioteka`,
					`fk_pareigosid_pareigos`
				)
				VALUES (
					?tabelio_nr,
					?vardas,
					?pavarde,
					?telefonas,
					?val_atlyginimas,
					?atlyginimas,
					?banko_saskaita,
					?fk_bibliotekaid_biblioteka,
					?fk_pareigosid_pareigos
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?tabelio_nr", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.Tabelio_nr;
                args.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Pavarde;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Telefonas;
                args.Add("?val_atlyginimas", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.Val_atlyginimas;
                args.Add("?atlyginimas", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Atlyginimas;
                args.Add("?banko_saskaita", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Banko_saskaita;
                args.Add("?fk_bibliotekaid_biblioteka", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.FkBiblioteka;
                args.Add("?fk_pareigosid_pareigos", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.FkPareigos;
            });
        }

        public static void Insert(int ISBN, DarbuotojasEditVM.DarbuotojasM darbuotojasEvm)
        {
            var query =
                $@"INSERT INTO `darbuotojai`
				(
					`tabelio_nr`,
					`vardas`,
					`pavarde`,
					`telefonas`,
					`val_atlyginimas`,
					`atlyginimas`,
					`banko_saskaita`,
					`fk_bibliotekaid_biblioteka`,
					`fk_pareigosid_pareigos`
				)
				VALUES (
					?tabelio_nr,
					?vardas,
					?pavarde,
					?telefonas,
					?val_atlyginimas,
					?atlyginimas,
					?banko_saskaita,
					?fk_bibliotekaid_biblioteka,
					?fk_pareigosid_pareigos
				)";

            Sql.Insert(query, args =>
            {
                args.Add("?tabelio_nr", MySqlDbType.Int32).Value = darbuotojasEvm.Tabelio_nr;
                args.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojasEvm.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojasEvm.Pavarde;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = darbuotojasEvm.Telefonas;
                args.Add("?val_atlyginimas", MySqlDbType.Int32).Value = darbuotojasEvm.Val_atlyginimas;
                args.Add("?atlyginimas", MySqlDbType.Int32).Value = darbuotojasEvm.Atlyginimas;
                args.Add("?banko_saskaita", MySqlDbType.VarChar).Value = darbuotojasEvm.Banko_saskaita;
                args.Add("?fk_bibliotekaid_biblioteka", MySqlDbType.Int32).Value = darbuotojasEvm.FkBiblioteka;
                args.Add("?fk_pareigosid_pareigos", MySqlDbType.Int32).Value = darbuotojasEvm.FkPareigos;
            });
        }

        public static void Update(DarbuotojasEditVM darbuotojasEvm)
        {
            var query =
                $@"UPDATE `darbuotojai`
				SET
					`tabelio_nr` = ?tabelio_nr,
					`vardas` = ?vardas,
					`pavarde` = ?pavarde,
					`telefonas` = ?telefonas,
					`val_atlyginimas` = ?val_atlyginimas,
					`atlyginimas` = ?atlyginimas,
					`banko_saskaita` = ?banko_saskaita,
					`fk_bibliotekaid_biblioteka` = ?fk_bibliotekaid_biblioteka,
					`fk_pareigosid_pareigos` = ?fk_pareigosid_pareigos
				WHERE
					tabelio_nr=?tabelio_nr";

            Sql.Update(query, args =>
            {
                args.Add("?tabelio_nr", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.Tabelio_nr;
                args.Add("?vardas", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Vardas;
                args.Add("?pavarde", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Pavarde;
                args.Add("?telefonas", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Telefonas;
                args.Add("?val_atlyginimas", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.Val_atlyginimas;
                args.Add("?atlyginimas", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.Atlyginimas;
                args.Add("?banko_saskaita", MySqlDbType.VarChar).Value = darbuotojasEvm.Darbuotojas.Banko_saskaita;
                args.Add("?fk_bibliotekaid_biblioteka", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.FkBiblioteka;
                args.Add("?fk_pareigosid_pareigos", MySqlDbType.Int32).Value = darbuotojasEvm.Darbuotojas.FkPareigos;
            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `darbuotojai` WHERE tabelio_nr=?tabelio_nr";
            Sql.Delete(query, args =>
            {
                args.Add("?tabelio_nr", MySqlDbType.Int32).Value = id;
            });
        }
    }
}