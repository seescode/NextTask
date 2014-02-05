using System;
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

        public List<Project> _projects { get; set; }

        protected TaskSet()
        {
            _tasksDone = new LinkedList<Task>();
            _tasksNotDone = new LinkedList<Task>();
            _projects = new List<Project>();
        }

        protected TaskSet(IEnumerable<Task> tasks, IEnumerable<Project> projects)
        {
            _tasksDone = new LinkedList<Task>(tasks.Where(n => n.Completed != null));
            _tasksNotDone = new LinkedList<Task>(tasks.Where(n => n.Completed == null));
            _projects = projects.ToList<Project>();
        }

        public static TaskSet Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new TaskSet(TaskRepository.LoadTasks(), ProjectRepository.LoadProjects());
            }

            return _instance;
        }
    }
}
