using System.Collections.Generic;

namespace P5
{
    public class FakeProjectRepository : IProjectRepository
    {
        private static List<Project> projects;
        private static int counter = 1;

        public const string NO_ERROR = "";
        public const string MODIFIED_PROJECT_ID_ERROR = "Can not modify the project id.";
        public const string DUPLICATE_PROJECT_NAME_ERROR = "Project name already exists.";
        public const string NO_PROJECT_FOUND_ERROR = "No project found.";
        public const string EMPTY_PROJECT_NAME_ERROR = "Project name is empty or blank.";


        public FakeProjectRepository()
        {
            if (projects == null)
            {
                projects = new List<Project>();
                string[] ProjectNames = {
                    "Big Project 1",
                    "Big Project 2",
                    "Big Project 3"
                };

                foreach (string name in ProjectNames)
                {
                    Project tmp = new Project(GetNextId(), name);
                    projects.Add(tmp);
                }
            }
        }

        public string Add(Project project, out int Id)
        {
            Id = -1;
            if (string.IsNullOrEmpty(project.Name) || string.IsNullOrWhiteSpace(project.Name))
            {
                return EMPTY_PROJECT_NAME_ERROR;
            }
            else if (IsDuplicateName(project.Name))
            {
                return DUPLICATE_PROJECT_NAME_ERROR;
            }
            project.Id = GetNextId();
            projects.Add(project);
            Id = project.Id;
            return NO_ERROR;
        }

        public List<Project> GetAll()
        {
            return projects;
        }

        public bool IsDuplicateName(string projectName)
        {
            foreach (Project proj in projects)
            {
                if (proj.Name == projectName)
                    return true;
            }
            return false;
        }

        public string Modify(int projectId, Project project)
        {
            foreach (Project proj in projects)
            {
                if (proj.Id == projectId)
                {
                    if (string.IsNullOrEmpty(project.Name))
                        return EMPTY_PROJECT_NAME_ERROR;
                    else if (IsDuplicateName(project.Name))
                        return DUPLICATE_PROJECT_NAME_ERROR;
                    else if (project.Id != proj.Id)
                        return MODIFIED_PROJECT_ID_ERROR;

                    proj.Name = project.Name;
                    return NO_ERROR;
                }
            }
            return NO_PROJECT_FOUND_ERROR;
        }

        public string Remove(int projectId)
        {
            foreach(Project proj in projects)
            {
                if (proj.Id == projectId)
                {
                    projects.Remove(proj);
                    return NO_ERROR;
                }
            }
            return NO_PROJECT_FOUND_ERROR;
        }

        private static int GetNextId()
        {
            return counter++;
        }
    }
}