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
        TaskService _taskService = TaskService.Instance();

        public NewTask()
        {
            InitializeComponent();
            LoadProjectsDropDown();
        }

        public void SetProjectId(int projectId)
        {
            projects.SelectedIndex = projectId;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            LoadProjectsDropDown();

            base.OnEnabledChanged(e);
        }

        protected void LoadProjectsDropDown()
        {
            projects.DataSource = null;
            projects.DataSource = _taskService._projects;
            projects.DisplayMember = "name";
            projects.ValueMember = "projectId";            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            this.Owner.Enabled = true;
            base.OnFormClosed(e);
        }
        
        private void addBack_Click(object sender, EventArgs e)
        {

            if (this.description.Text.Trim() != "" && projects.SelectedItem != null)
            {
                Task t = new Task();
                t.description = this.description.Text;
                t.notes = this.notes.Text;
                t.projectId = Int32.Parse(projects.SelectedValue.ToString());
                _taskService._tasksNotDone.AddLast(t);
                TaskRepository.InsertTask(t);
                 
                Clear();
            }
        }

        private void addNext_Click(object sender, EventArgs e)
        {
            if (this.description.Text.Trim() != "" && projects.SelectedItem != null)
            {
                if (_taskService._currentTask == null)
                {
                    addBack_Click(sender, e);
                }
                else
                {
                    Task t = new Task();
                    t.description = this.description.Text;
                    t.notes = this.notes.Text;
                    t.projectId = Int32.Parse(projects.SelectedValue.ToString());

                    //[FIX]
                    _taskService._tasksNotDone.AddAfter(_taskService._currentTask, t);
                    TaskRepository.InsertTask(t);
                    Clear();
                }
            }
        }

        private void addFront_Click(object sender, EventArgs e)
        {
            if (this.description.Text.Trim() != "" && projects.SelectedItem != null)
            {
                Task t = new Task();
                t.description = this.description.Text;
                t.notes = this.notes.Text;
                t.projectId = Int32.Parse(projects.SelectedValue.ToString());
                _taskService._tasksNotDone.AddFirst(t);
                TaskRepository.InsertTask(t);
                 
                Clear();
            }
        }

        private void Clear()
        {
            description.Text = "";
            notes.Text = "";
        }

        private void newProject_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            NewProject form = new NewProject();
            form.Show();
            form.Owner = this;
        }
    }
}
