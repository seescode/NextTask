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
        TaskSet _taskSet = TaskSet.Instance();
        Stopwatch _stopwatch = new Stopwatch();

        public Work()
        {
            InitializeComponent();

            if (_taskSet._tasksNotDone.Count > 0)
            {
                _taskSet._currentTask = _taskSet._currentTask ?? _taskSet._tasksNotDone.First;
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
            if (_taskSet._tasksNotDone.Count > 0)
            {
                _taskSet._currentTask = _taskSet._currentTask ?? _taskSet._tasksNotDone.First;
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

            description.Text = _taskSet._currentTask.Value.description;
            notes.Text = _taskSet._currentTask.Value.notes;
        }

        private void skip_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();

            update_Click(sender, e);
            _taskSet._currentTask = _taskSet._currentTask.Next;

            if (_taskSet._currentTask == null)
            {
                _taskSet._currentTask = _taskSet._tasksNotDone.First;
            }

            LoadForm();
        }


        private void done_Click(object sender, EventArgs e)
        {
            SaveElapsedTime();

            update_Click(sender, e);

            Task clonedTask = new Task();
            clonedTask.description = _taskSet._currentTask.Value.description;
            clonedTask.notes = _taskSet._currentTask.Value.notes;
            clonedTask.id = _taskSet._currentTask.Value.id;
            clonedTask.TimeSpentInSeconds = _taskSet._currentTask.Value.TimeSpentInSeconds;
            clonedTask.Created = _taskSet._currentTask.Value.Created;
            clonedTask.Completed = _taskSet._currentTask.Value.Completed;

            _taskSet._tasksDone.AddLast(clonedTask);

            LinkedListNode<Task> newCurrentTask = null;

            if (_taskSet._currentTask.Next != null)
            {
                newCurrentTask = _taskSet._currentTask.Next;
                _taskSet._tasksNotDone.Remove(_taskSet._currentTask);
                _taskSet._currentTask = newCurrentTask;
            }
            else if (_taskSet._currentTask.Previous != null)
            {
                newCurrentTask = _taskSet._currentTask.Previous;
                _taskSet._tasksNotDone.Remove(_taskSet._currentTask);
                _taskSet._currentTask = newCurrentTask;
            }
            else
            {
                _taskSet._tasksNotDone.Remove(_taskSet._currentTask);

                ShowFinishedStatus();
            }

            LoadForm();
        }

        private void update_Click(object sender, EventArgs e)
        {
            _taskSet._currentTask.Value.description = description.Text;
            _taskSet._currentTask.Value.notes = notes.Text;
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
            if (_taskSet._currentTask != null)
            {
                _taskSet._currentTask.Value.TimeSpentInSeconds += (_stopwatch.ElapsedMilliseconds / 1000);
            }
            _stopwatch.Stop();
            _stopwatch.Reset();
        }
    }
}
