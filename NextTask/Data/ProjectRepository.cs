using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NextTask.Data
{
    public static class ProjectRepository
    {
        public static IEnumerable<Project> LoadProjects()
        {
            //[FIX] this is just a stub that needs to be implemented.
            List<Project> p = new List<Project>();
            p.Add(new Project() { name = "Main", projectId = 1 });
            return p;
        }
    }
}
