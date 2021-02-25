using System;
using System.Collections.Generic;
using System.Globalization;
using back_end.Commons.Entities;
using MySql.Data.MySqlClient;

namespace back_end.DataAccess
{
    public class Expenses
    {
        public static ResponsePage<List<Expense>> Get(int size, int page)
        {
            var res = new ResponsePage<List<Expense>>();
            res.data = new List<Expense>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                MySqlTransaction transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;

                var sql = $"select * from expenses.expenses limit {size} OFFSET {page - 1}";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        var expense = new Expense();
                        expense.id_expense = Convert.ToInt32(dr["id_expense"]);
                        expense.description = Convert.ToString(dr["description"]);
                        expense.value = Convert.ToInt32(dr["value"]);
                        expense.date = Convert.ToDateTime(dr["date"]);
                        res.data.Add(expense);
                    }
                }
                res.success = true;
                res.size = size;
                res.total = Count();
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

        public static int Count()
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

                var sql = $"select count(1) from expenses.expenses";

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

        public static ResponseItem<bool> Create(Expense expense)
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
                var date = expense.date.ToString("yyyy-MM-dd", new CultureInfo("es-CO"));
                var sql = $@"insert into expenses.expenses (description,value,date,created_on) values 
                                                          ('{expense.description}',{expense.value},'{date}','{now.ToString("yyyy/MM/dd HH:mm:ss", new CultureInfo("es-CO"))}');";

                command.CommandText = sql;
                var dr = command.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                res.success = true;
                res.data = true;
                res.messages.Add("Se agrego el gasto correctamente.");
            }
            catch (Exception ex)
            {
                res.errors.Add(ex.Message);
                res.errors.Add(ex.StackTrace);
            }
            return res;
        }

        public static ResponseItem<bool> Delete(int id)
        {
            var res = new ResponseItem<bool>();
            try
            {
                using MySqlConnection connection = new MySqlConnection("server=localhost; Database=expenses; uid=admin; Pwd=database123;");
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                var sql = $"delete from expenses.expenses where id_expense = {id}";

                command.CommandText = sql;
                var dr = command.ExecuteReader();
                res.success = true;
                res.data = true;
                res.messages.Add("Se elimino el gasto correctamente.");

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
