using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextTask.Data
{
    public class TaskService
    {
        private static TaskService _instance;

        public LinkedList<Task> _tasksDone { get; set; }
        public LinkedList<Task> _tasksNotDone { get; set; }

        public LinkedListNode<Task> _currentTask { get; set; }

        public List<Project> _projects { get; set; }

        protected TaskService()
        {
            _tasksDone = new LinkedList<Task>();
            _tasksNotDone = new LinkedList<Task>();
            _projects = new List<Project>();
        }

        protected TaskService(IEnumerable<Task> tasks, IEnumerable<Project> projects)
        {
            _tasksDone = new LinkedList<Task>(tasks.Where(n => n.Completed != null));
            _tasksNotDone = new LinkedList<Task>(tasks.Where(n => n.Completed == null));
            _projects = projects.ToList<Project>();
        }

        public void SwitchProject(int projectId)
        {
            SkipTask(projectId);
        }

        public void SkipTask()
        {
            SkipTask(_currentTask.Value.projectId);
        }

        private void SkipTask(int projectId)
        {
            do
            {
                _currentTask = _currentTask.Next;

                if (_currentTask == null)
                {
                    _currentTask = _tasksNotDone.First;
                }
            } while (_currentTask.Value.projectId != projectId);

        }

        public static TaskService Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new TaskService(TaskRepository.LoadTasks(), ProjectRepository.LoadProjects());
            }

            return _instance;
        }
    }
}
