using System;
using System.Collections.Generic;
using back_end.Commons.Entities;
using MySql.Data.MySqlClient;

namespace back_end.DataAccess
{
    public class Clients
    {
        public static ResponsePage<List<Client>> Get() {

            var res = new ResponsePage<List<Client>>();
            res.data = new List<Client>();

            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = "SELECT * FROM expenses.clients";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        var client = new Client();
                        client.name = Convert.ToString(dr["name"]);
                        client.identification = Convert.ToInt32(dr["identification"]);

                        res.data.Add(client);
                        res.success = true;
                    }
                }
                dr.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.errors.Add(ex.StackTrace);
            }

            return res;
        }
    }
}
