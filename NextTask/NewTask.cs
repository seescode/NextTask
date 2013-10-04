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
    public partial class NewTask : Form
    {
        TaskSet _taskSet = TaskSet.Instance();

        public NewTask()
        {
            InitializeComponent();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            base.OnFormClosed(e);
        }
        
        private void addBack_Click(object sender, EventArgs e)
        {

            if (this.description.Text.Trim() != "")
            {
                Task t = new Task();
                t.description = this.description.Text;
                t.notes = this.notes.Text;
                _taskSet._tasksNotDone.AddLast(t);
                TaskRepository.InsertTask(t);
                 
                Clear();
            }
        }

        private void addNext_Click(object sender, EventArgs e)
        {
            if (this.description.Text.Trim() != "")
            {
                if (_taskSet._currentTask == null)
                {
                    addBack_Click(sender, e);
                }
                else
                {
                    Task t = new Task();
                    t.description = this.description.Text;
                    t.notes = this.notes.Text;                    
                    _taskSet._tasksNotDone.AddAfter(_taskSet._currentTask, t);
                    TaskRepository.InsertTask(t);
                    Clear();
                }
            }
        }

        private void addFront_Click(object sender, EventArgs e)
        {
            if (this.description.Text.Trim() != "")
            {
                Task t = new Task();
                t.description = this.description.Text;
                t.notes = this.notes.Text;                
                _taskSet._tasksNotDone.AddFirst(t);
                TaskRepository.InsertTask(t);
                 
                Clear();
            }
        }

        private void Clear()
        {
            description.Text = "";
            notes.Text = "";
        }
    }
}
