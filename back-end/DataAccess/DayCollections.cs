using back_end.Commons.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace back_end.DataAccess
{
    public class DayCollections
    {
        public static ResponseItem<List<DayCollection>> Get()
        {
            var res = new ResponseItem<List<DayCollection>>();
            res.data = new List<DayCollection>();

            var id_clients = ClientsPayments.GetClientsWithOutPayments();
            var clients_payment_today = GetClientsTochargeToday(id_clients.data.Keys.ToList());

            foreach (var item in clients_payment_today.data)
            {
                var payment_days = 1;
                if (item.payment_type == 2)
                    payment_days = 7;
                else if (item.payment_type == 3)
                    payment_days = 14;
                else if (item.payment_type == 4)
                    payment_days = 30;

                var day_collection = new DayCollection();
                day_collection.id_client = item.id_client;
                day_collection.name_client = item.name;
                day_collection.phone_client = item.phone;
                day_collection.payments = id_clients.data.Where(x => x.Key == item.id_client).FirstOrDefault().Value.ToString();
                day_collection.payments_scheduled = Math.Round((decimal)item.time_limit / (decimal)payment_days).ToString();
                var interest_rate = item.loan * (item.interest_rate / 100);
                day_collection.payments_value = (item.loan / (item.time_limit / payment_days)).ToString();

                res.data.Add(day_collection);
            }

            res.data.RemoveAll(x => x.payments == x.payments_scheduled);
            return res;
        }

        public static ResponseItem<List<Client>> GetClientsTochargeToday(List<int> id_clients)
        {
            var res = new ResponseItem<List<Client>>();
            res.data = new List<Client>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=MYSQL5043.site4now.net; Database=db_a7024a_expense; uid=a7024a_expense; Pwd=Database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                DateTime now = DateTime.Now;
                var date_now = DateTime.Now.Date.ToString("yyyy-MM-dd", new CultureInfo("es-CO"));

                var sql = $@"select * from expenses.clients 
                             where id_client in ({string.Join(",", id_clients)})
                             and '{date_now}' =
                             (CASE
                                WHEN payment_type = 1
                                    THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+1 day)
                                WHEN payment_type = 2
                                    THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+7 day)
                                WHEN payment_type = 3
                                    THEN DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL days_added+14 day)
                                WHEN payment_type = 4
                                    THEN DATE_ADD(DATE_ADD(DATE_FORMAT(created_on, '%Y-%m-%d'), INTERVAL 1 month), interval days_added day)
                             end)";

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
                        res.data.Add(client);
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

    }
}
