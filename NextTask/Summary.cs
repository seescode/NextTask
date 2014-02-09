using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NextTask.Data;

namespace NextTask
{
    public partial class Summary : Form
    {
        TaskService _taskService = TaskService.Instance();

        public Summary()
        {
            InitializeComponent();

            LoadTasksCompleted();
            LoadTasksRemaining();
        }

        public void LoadTasksCompleted()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Tasks Completed:" + Environment.NewLine);

            int x = 1;
            long totalTimeInSeconds = 0;
            foreach (var i in _taskService._tasksDone)
            {                
                sb.Append(x + ")" + i.description + " " + Task.GetFormattedTime(i.TimeSpentInSeconds) + Environment.NewLine);
                x++;
                totalTimeInSeconds += i.TimeSpentInSeconds;
            }

            sb.Append("Total Time: " + Task.GetFormattedTime(totalTimeInSeconds));

            tasksCompleted.Text = sb.ToString();
        }

        public void LoadTasksRemaining()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Tasks Remaining:" + Environment.NewLine);

            int x = 1;
            long totalTimeInSeconds = 0;
            foreach (var i in _taskService._tasksNotDone)
            {
                sb.Append(x + ")" + i.description + " " + Task.GetFormattedTime(i.TimeSpentInSeconds) + Environment.NewLine);
                x++;
                totalTimeInSeconds += i.TimeSpentInSeconds;
            }

            sb.Append("Total Time: " + Task.GetFormattedTime(totalTimeInSeconds));
            tasksRemaining.Text = sb.ToString();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            base.OnFormClosed(e);
        }
    }
}
