using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data;
using Dapper;

namespace NextTask.Data
{
    public static class TaskRepository
    {
        
        public static IEnumerable<Task> LoadTasks()
        {
            IEnumerable<Task> tasks;

            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var sql = "select id, description, notes, Created, Completed, TimeSpentInSeconds from Task";

                     tasks = connection.Query<Task>(sql);
                }
            }
            catch
            {
                Console.WriteLine("Load Tasks failed");
                throw;
            }

            return tasks;
        }

        public static void InsertTask(Task t)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var sql = @"Insert into Task (description, notes, Created, TimeSpentInSeconds) values (@description, @notes, @Created, @TimeSpentInSeconds);";
                    connection.Execute(sql, t);

                    sql = "SELECT top(1) id from Task order by id desc";
                    var id = connection.Query<int>(sql).Single();

                    t.id = id;
                }
            }
            catch
            {
                Console.WriteLine("Insert Task failed");
                throw;    
            }
        }

        public static void UpdateTask(Task t)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var sql = "Update Task set description=@description, notes=@notes, Created=@Created, TimeSpentInSeconds=@TimeSpentInSeconds, Completed=@Completed " +
                        "where id=@id";

                    connection.Execute(sql, t);
                }
            }
            catch
            {
                Console.WriteLine("Update Task failed");
                throw;
            }
        }

        public static SqlCeConnection GetConnection()
        {
            string con = "Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "Database.sdf;Persist Security Info=False;";
            return new SqlCeConnection(con);
        }

    }
}
