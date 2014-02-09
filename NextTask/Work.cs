using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NextTask.Data;
using System.Diagnostics;

namespace NextTask
{
    public partial class Work : Form
    {
        TaskService _taskService = TaskService.Instance();
        Stopwatch _stopwatch = new Stopwatch();

        public Work()
        {
            InitializeComponent();
         
            if (_taskService._tasksNotDone.Count > 0)
            {
                _taskService._currentTask = _taskService._currentTask ?? _taskService._tasksNotDone.First;
                LoadForm();
            }
            else
            {
                ShowFinishedStatus();
            }
        }

        protected void ShowFinishedStatus()
        {
            finished.Visible = true;
            done.Visible = false;
            update.Visible = false;
            skip.Visible = false;
            description.Visible = false;
            notes.Visible = false;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (_taskService._tasksNotDone.Count > 0)
            {
                _taskService._currentTask = _taskService._currentTask ?? _taskService._tasksNotDone.First;
                LoadForm();

                finished.Visible = false;
                done.Visible = true;
                update.Visible = true;
                skip.Visible = true;
                description.Visible = true;
                notes.Visible = true;
            }

            base.OnEnabledChanged(e);
        }

        private void LoadForm()
        {
            _stopwatch.Reset();
            _stopwatch.Start();

            description.Text = _taskService._currentTask.Value.description;
            notes.Text = _taskService._currentTask.Value.notes;
            LoadProjectsDropDown();
        }

        protected void LoadProjectsDropDown()
        {
            projects.DataSource = null;

            var projectsWithTasks = _taskService._tasksNotDone.Select(n => n.projectId).Distinct();

            projects.DataSource = _taskService._projects.Where(n => projectsWithTasks.Any(z => z == n.projectId)).ToList();
            projects.DisplayMember = "name";
            projects.ValueMember = "projectId";
        }

        private void skip_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();

            update_Click(sender, e);

            _taskService.SkipTask();

            description.Text = _taskService._currentTask.Value.description;
            notes.Text = _taskService._currentTask.Value.notes;
        }


        private void done_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();

            _taskService._currentTask.Value.Completed = DateTime.Now;
            update_Click(sender, e);

            Task clonedTask = new Task();
            clonedTask.description = _taskService._currentTask.Value.description;
            clonedTask.notes = _taskService._currentTask.Value.notes;
            clonedTask.id = _taskService._currentTask.Value.id;
            clonedTask.TimeSpentInSeconds = _taskService._currentTask.Value.TimeSpentInSeconds;
            clonedTask.Created = _taskService._currentTask.Value.Created;
            clonedTask.Completed = _taskService._currentTask.Value.Completed;

            _taskService._tasksDone.AddLast(clonedTask);

            LinkedListNode<Task> newCurrentTask = null;

            if (_taskService._currentTask.Next != null)
            {
                newCurrentTask = _taskService._currentTask.Next;
                _taskService._tasksNotDone.Remove(_taskService._currentTask);
                _taskService._currentTask = newCurrentTask;
            }
            else if (_taskService._currentTask.Previous != null)
            {
                newCurrentTask = _taskService._currentTask.Previous;
                _taskService._tasksNotDone.Remove(_taskService._currentTask);
                _taskService._currentTask = newCurrentTask;
            }
            else
            {
                _taskService._tasksNotDone.Remove(_taskService._currentTask);

                ShowFinishedStatus();
            }

            description.Text = _taskService._currentTask.Value.description;
            notes.Text = _taskService._currentTask.Value.notes;

        }

        private void update_Click(object sender, EventArgs e)
        {
            _taskService._currentTask.Value.description = description.Text;
            _taskService._currentTask.Value.notes = notes.Text;
            TaskRepository.UpdateTask(_taskService._currentTask.Value);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Environment.Exit(0);
        }

        private void newTask_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();
            this.Enabled = false;

            NewTask form = new NewTask();
            form.SetProjectId(projects.SelectedIndex);
            form.Show();
            form.Owner = this;
        }

        private void summary_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();
            this.Enabled = false;

            Summary form = new Summary();
            form.Show();
            form.Owner = this;
        }

        private void SaveElapsedTime()
        {
            if (_taskService._currentTask != null)
            {
                _taskService._currentTask.Value.TimeSpentInSeconds += (_stopwatch.ElapsedMilliseconds / 1000);
            }
            _stopwatch.Stop();
            _stopwatch.Reset();
        }

        private void projects_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projects.SelectedIndex > 0)
            {
                _taskService.SwitchProject(Int32.Parse(projects.SelectedValue.ToString()));
                description.Text = _taskService._currentTask.Value.description;
                notes.Text = _taskService._currentTask.Value.notes;
            }
        }
    }
}
