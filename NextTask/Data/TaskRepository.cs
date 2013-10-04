using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

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
                using (SqlCeConnection connection = GetConnection())
                {
                    string queryString = String.Format(@"Insert into Task (description, notes, Created, TimeSpentInSeconds)
                                values ('{0}', '{1}', '{2}', '{3}')", t.description, t.notes, 
                                t.Created.ToShortDateString().Replace('/', '-'), 
                                t.TimeSpentInSeconds);

                    SqlCeCommand command = new SqlCeCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
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
