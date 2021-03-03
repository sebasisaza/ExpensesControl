using back_end.Commons.Utilities;
using MySql.Data.MySqlClient;
using System;

namespace back_end.DataAccess
{
    public class Login
    {
        public static bool Check(string username, string password)
        {
            var res = false;
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select id_user from expenses.users where user = '{username}' and password = '{Encrypt.MD5Hash(password)}'";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        res = true;
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
    }
}
