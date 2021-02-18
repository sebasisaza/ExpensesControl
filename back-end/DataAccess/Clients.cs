using System;
using System.Collections.Generic;
using back_end.Commons.Entities;
using MySql.Data.MySqlClient;

namespace back_end.DataAccess
{
    public class Clients
    {
        public static ResponsePage<List<Client>> Get(int size, int page, string search) {

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

                var sql = $"select * from expenses.clients where identification like '%{search}%' limit {size} OFFSET {page-1}";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        var client = new Client();
                        client.id_client = Convert.ToInt32(dr["id_client"]);
                        client.name = Convert.ToString(dr["name"]);
                        client.identification = Convert.ToInt32(dr["identification"]);
                        client.phone = Convert.ToString(dr["phone"]);
                        client.loan = Convert.ToSingle(dr["loan"]);
                        client.time_limit = Convert.ToInt32(dr["time_limit"]);
                        client.interest_rate = Convert.ToSingle(dr["interest_rate"]);
                        client.payment_type = Convert.ToInt16(dr["payment_type"]);
                        client.days_added = Convert.ToInt16(dr["days_added"]);
                        client.created_on = Convert.ToDateTime(dr["created_on"]);

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
