using back_end.Commons.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DataAccess
{
    public class ClientsPayments
    {

        public static ResponseItem<Dictionary<int, int>> GetClientsWithOutPayments()
        {
            var res = new ResponseItem<Dictionary<int, int>>();
            res.data = new Dictionary<int, int>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                var sql = $@"select
                             id_client,
                             (select count(1) from expenses.clients_payments where id_client = c.id_client) as 'payments'
                             from expenses.clients c
                             where 'payments' = 0";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        res.data.Add(Convert.ToInt32(dr[0]), Convert.ToInt32(dr[1]));
                    }
                }
                res.success = true;
                dr.Close();
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.errors.Add(ex.StackTrace);
            }
            return res;
        }

        public static ResponseItem<ClientDetail> GetByClient(int id_client)
        {
            var res = new ResponseItem<ClientDetail>();
            res.data = new ClientDetail();
            res.data.payments = new List<ClientPayment>();
            try
            {
                var client = Clients.GetById(id_client);
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select * from expenses.clients_payments where id_client = {id_client}";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        var client_payment = new ClientPayment();
                        client_payment.id_client_payment = Convert.ToInt32(dr["id_client_payment"]);
                        client_payment.id_client = id_client;
                        client_payment.value = Convert.ToSingle(dr["value"]);
                        client_payment.date = Convert.ToDateTime(dr["date"]);
                        res.data.payments.Add(client_payment);
                    }
                }
                res.data.id_client = id_client;
                res.data.name = client.data.name;
                res.data.phone = client.data.phone;
                res.data.identification = client.data.identification;
                res.data.interest_rate = client.data.interest_rate;
                res.data.loan = client.data.loan;

                res.data.payment_paid = res.data.payments.Sum(x => x.value);
                res.data.payment_owed = client.data.loan - res.data.payments.Sum(x => x.value);
                res.success = true;
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

        public static ResponseItem<bool> Create(ClientPayment client_payment)
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
                var date = client_payment.date.ToString("yyyy-MM-dd", new CultureInfo("es-CO"));
                var sql = $@"insert into expenses.clients_payments (id_client,value,date,created_on) values ({client_payment.id_client},{client_payment.value},'{date}','{now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("es-CO"))}');";

                command.CommandText = sql;
                var dr = command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                res.success = true;
                res.data = true;
                res.messages.Add("Se agrego el pago correctamente.");
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
