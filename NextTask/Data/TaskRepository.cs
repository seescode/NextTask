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
        
        public static void LoadTasks()
        {
        }

        public static void InsertTask(Task t)
        {
            try
            {
                using (IDbConnection connection = GetConnection())
                {
                    var sql = "Insert into Task (description, notes, Created, TimeSpentInSeconds) values (@description, @notes, @Created, @TimeSpentInSeconds)";
                              //"Select cast(scope_identity() as int)";

                    connection.Execute(sql, t);
                    //var id = connection.Query<int>(sql, t).SingleOrDefault();
                    //t.id = id;
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

        }

        public static void DeleteTask(int id)
        {

        }

        public static SqlCeConnection GetConnection()
        {
            string con = "Data Source=Database.sdf;Persist Security Info=False;";
            return new SqlCeConnection(con);
        }

    }
}
