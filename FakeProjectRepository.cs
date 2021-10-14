using System.Collections.Generic;

namespace P5
{
    public class FakeProjectRepository : IProjectRepository
    {
        private static List<Project> projects;
        private static int counter = 0;

        public const string NO_ERROR = "OK";
        public const string MODIFIED_PROJECT_ID_ERROR = "IDError";
        public const string DUPLICATE_PROJECT_NAME_ERROR = "NameError";
        public const string NO_PROJECT_FOUND_ERROR = "ProjError";
        public const string EMPTY_PROJECT_NAME_ERROR = "Empty";


        public FakeProjectRepository()
        {
            if (projects == null)
            {
                string[] ProjectNames = {
                    "Big Project 1",
                    "Big Project 2",
                    "Big Project 3"
                };

                foreach (string name in ProjectNames)
                {
                    projects.Add(new Project(GetNextId(), name));
                }
            }
        }

        string IProjectRepository.Add(Project project, out int Id)
        {
            Id = -1;
            if (string.IsNullOrEmpty(project.Name))
            {
                return EMPTY_PROJECT_NAME_ERROR;
            }
            else if (((IProjectRepository)this).IsDuplicateName(project.Name))
            {
                return DUPLICATE_PROJECT_NAME_ERROR;
            }
            project.Id = GetNextId();
            projects.Add(project);
            Id = project.Id;
            return NO_ERROR;
        }

        List<Project> IProjectRepository.GetAll()
        {
            return projects;
        }

        bool IProjectRepository.IsDuplicateName(string projectName)
        {
            foreach (Project proj in projects)
            {
                if (proj.Name == projectName)
                    return true;
            }
            return false;
        }

        string IProjectRepository.Modify(int projectId, Project project)
        {
            foreach (Project proj in projects)
            {
                if (proj.Id == projectId)
                {
                    if (string.IsNullOrEmpty(project.Name))
                        return EMPTY_PROJECT_NAME_ERROR;
                    else if (((IProjectRepository)this).IsDuplicateName(project.Name))
                        return DUPLICATE_PROJECT_NAME_ERROR;
                    else if (project.Id != proj.Id)
                        return MODIFIED_PROJECT_ID_ERROR;

                    proj.Name = project.Name;
                    return NO_ERROR;
                }
            }
            return NO_PROJECT_FOUND_ERROR;
        }

        string IProjectRepository.Remove(int projectId)
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