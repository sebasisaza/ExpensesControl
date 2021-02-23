using back_end.Commons.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace back_end.DataAccess
{
    public class DayCollections
    {

        //1. Saber el 


        public static ResponsePage<List<DayCollection>> Get(int size, int page, string search)
        {
            var res = new ResponsePage<List<DayCollection>>();
            res.data = new List<DayCollection>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                DateTime now = DateTime.Now;
                var date_now = DateTime.Now.Date.ToString("yyyy-MM-dd", new CultureInfo("es-CO"));

                var sql = $"select * from DayCollectionsView";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        var item = new DayCollection();
                        item.id_client = Convert.ToInt32(dr["id_client"]);
                        item.name_client = Convert.ToString(dr["name_client"]);
                        item.phone_client = Convert.ToString(dr["phone_client"]);
                        item.fee_summary = Convert.ToString(dr["total_payments"])+'/'+ Convert.ToString(dr["scheduled_payments"]);
                        item.fee_value = Convert.ToString(dr["scheduled_value"]);
                        res.data.Add(item);
                    }
                }
                res.success = true;
                res.size = size;
                //res.total = Count(search);
                //res.pages = (int)Math.Ceiling((decimal)res.total / (decimal)size);
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
