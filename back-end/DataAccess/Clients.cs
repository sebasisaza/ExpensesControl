using System;
using System.Collections.Generic;
using System.Globalization;
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
                    }
                }
                res.success = true;
                res.size = size;
                res.total = Count(search);
                res.pages = (int)Math.Ceiling((decimal)res.total / (decimal)size);
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

        public static int Count(string search)
        {
            var res = 0;
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select count(1) from expenses.clients where identification like '%{search}%'";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        res = Convert.ToInt32(dr[0]);
                    }
                }
                dr.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public static ResponseItem<bool> Create(Client client)
        {
            var res = new ResponseItem<bool>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                DateTime now = DateTime.Now;
                var sql = $@"insert into expenses.clients (name,identification,phone,loan,time_limit,interest_rate,payment_type,days_added,created_on) values 
                                                          ('{client.name}','{client.identification}','{client.phone}',{client.loan},{client.time_limit},
                                                            {client.interest_rate},{client.payment_type},{client.days_added},'{now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("es-CO"))}');";

                command.CommandText = sql;
                var dr = command.ExecuteNonQuery();
                transaction.Commit();
                res.success = true;
                res.data = true;
                res.messages.Add("Se agrego el cliente correctamente.");
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.errors.Add(ex.StackTrace);
            }
            return res;
        }

        public static ResponseItem<Client> GetById(int id)
        {
            var res = new ResponseItem<Client>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select * from expenses.clients where id_client = {id}";

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
                        res.data = client;
                        res.success = true;
                    }
                }
                dr.Close();
                transaction.Commit();
            }
            catch (Exception ex)
            {
            }
            return res;
        }

        public static ResponseItem<bool> Update(Client client)
        {
            var res = new ResponseItem<bool>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                DateTime now = DateTime.Now;
                var sql = $@"update expenses.clients SET name = '{client.name}', identification = '{client.identification}', phone = '{client.phone}', loan = {client.loan}, 
                                                     time_limit = {client.time_limit}, interest_rate = {client.interest_rate}, payment_type = {client.payment_type}, days_added = {client.days_added} WHERE id_client = {client.id_client};";

                command.CommandText = sql;
                var dr = command.ExecuteNonQuery();
                transaction.Commit();
                res.success = true;
                res.data = true;
                res.messages.Add("Se actualizo el cliente correctamente.");
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
