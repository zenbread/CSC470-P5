using System.Collections.Generic;

namespace P5
{
    interface IProjectRepository
    {
        string Add(Project project, out int Id);
        string Remove(int projectId);
        string Modify(int projectId, Project project);
        List<Project> GetAll();
        bool IsDuplicateName(string projectName);

    }
}
