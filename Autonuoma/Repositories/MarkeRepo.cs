﻿using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using System.Data;


namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories
{
    public class MarkeRepo
    {
        public static List<Marke> List()
        {
            var markes = new List<Marke>();

            string query = $@"SELECT * FROM `markes` ORDER BY id ASC";
            var dt = Sql.Query(query);

            foreach (DataRow item in dt)
            {
                markes.Add(new Marke
                {
                    Id = Convert.ToInt32(item["id"]),
                    Pavadinimas = Convert.ToString(item["pavadinimas"]),
                });
            }

            return markes;
        }

        public static Marke Find(int id)
        {
            var marke = new Marke();

            var query = $@"SELECT * FROM `markes` WHERE id=?id";
            var dt =
                Sql.Query(query, args =>
                {
                    args.Add("?id", MySqlDbType.Int32).Value = id;
                });

            foreach (DataRow item in dt)
            {
                marke.Id = Convert.ToInt32(item["id"]);
                marke.Pavadinimas = Convert.ToString(item["pavadinimas"]);
            }

            return marke;
        }

        public static void Update(Marke marke)
        {
            var query =
                $@"UPDATE `markes` 
				SET 
					pavadinimas=?pavadinimas 
				WHERE 
					id=?id";

            Sql.Update(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = marke.Pavadinimas;
                args.Add("?id", MySqlDbType.VarChar).Value = marke.Id;
            });
        }

        public static void Insert(Marke marke)
        {
            var query = $@"INSERT INTO `markes` ( pavadinimas ) VALUES ( ?pavadinimas )";
            Sql.Insert(query, args =>
            {
                args.Add("?pavadinimas", MySqlDbType.VarChar).Value = marke.Pavadinimas;
            });
        }

        public static void Delete(int id)
        {
            var query = $@"DELETE FROM `markes` where id=?id";
            Sql.Delete(query, args =>
            {
                args.Add("?id", MySqlDbType.Int32).Value = id;
            });
        }
    }
}