using back_end.Commons.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.DataAccess
{
    public class General
    {
        public static decimal GetInitialBalance() 
        {
            var res = new decimal();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select initial_balance from expenses.general";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        res = Convert.ToDecimal(dr[0]);
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

        public static Commons.Entities.General Get(string month)
        {
            var res = new Commons.Entities.General();
            res.initial_balance = GetInitialBalance();
            res.expenses_month = Expenses.SumExpensesByMonth(month);
            res.payment_pending = ClientsPayments.SumAllPendingPayments();
            
            return res;
        }
    }
}
