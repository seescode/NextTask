using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextTask.Data
{
    public partial class Task
    {
        public int id { get; set; }
        public string description { get; set; } 
        public string notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }
        public long TimeSpentInSeconds { get; set; }

        static public string GetFormattedTime(long timeSpendInSeconds)
        {
            string time = "";

            if (timeSpendInSeconds < 60)
            {
                time = timeSpendInSeconds + " secs";
            }
            else if (timeSpendInSeconds < 360)
            {
                time = timeSpendInSeconds / 60 + " mins";
            }
            else 
            {
                long hours = timeSpendInSeconds / 360;
                long mins = timeSpendInSeconds % 360;

                time = hours + " hrs " + mins + " mins";
            }

            return "(" + time + ")";
        }

        public Task()
        {
            id = -1;
            description = "";
            notes = "";           
            TimeSpentInSeconds = 0;
            Created = DateTime.Now;
        }


    } 
}
