using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public interface IProjectService
    {

        public List<ProjectsDTO> GetAllProjects();
        public ProjectsDTO GetProjectsById(int id);
        public ProjectsDTO CreateProjects(ProjectsDTO ProjectsDto);
        public ProjectsDTO UpdateProjects(int id, ProjectsDTO ProjectsDto);
        public void DeleteProjects(int id);
    }
}
