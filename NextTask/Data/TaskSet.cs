﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextTask.Data
{
    public class TaskSet
    {
        private static TaskSet _instance;

        public LinkedList<Task> _tasksDone { get; set; }
        public LinkedList<Task> _tasksNotDone { get; set; }

        public LinkedListNode<Task> _currentTask { get; set; }

        protected TaskSet()
        {
            _tasksDone = new LinkedList<Task>();
            _tasksNotDone = new LinkedList<Task>();
        }

        protected TaskSet(IEnumerable<Task> tasks)
        {
            _tasksDone = new LinkedList<Task>(tasks.Where(n => n.Completed != null));
            _tasksNotDone = new LinkedList<Task>(tasks.Where(n => n.Completed == null));
        }

        public static TaskSet Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new TaskSet(TaskRepository.LoadTasks());
            }

            return _instance;
        }
    }
}
