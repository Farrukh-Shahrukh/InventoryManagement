using AutoMapper;
using investmentsManagement.Server.Data;
using investmentsManagement.Server.Data.Models;
using investmentsManagement.Server.Data.Models.ViewModels;

namespace investmentsManagement.Server.Services
{
    public class ProjectService : IProjectService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<ProjectsDTO> GetAllProjects()
        {
            var Projects = _context.Projects.Where(W => !W.IsDeleted).ToList();
            return _mapper.Map<List<ProjectsDTO>>(Projects);
        }
        public ProjectsDTO GetProjectsById(int id)
        {
            var Projects = _context.Projects.Find(id);
            if (Projects == null)
            {
                return null;
            }
            return _mapper.Map<ProjectsDTO>(Projects);
        }
        public ProjectsDTO CreateProjects(ProjectsDTO ProjectsDto)
        {
            var project = _mapper.Map<Projects>(ProjectsDto);
            project.CreatedDate = DateTime.Now;
            project.publicId = Guid.NewGuid();

            _context.Projects.Add(project);
            _context.SaveChanges();
            return _mapper.Map<ProjectsDTO>(project);
        }

        public ProjectsDTO UpdateProjects(int id, ProjectsDTO ProjectsDto)
        {
            var project = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (project == null)
            {
                throw new Exception("Projects not found");
            }

            _mapper.Map(ProjectsDto, project);
            project.UpdatedDate = DateTime.Now;

            _context.SaveChanges();
            return _mapper.Map<ProjectsDTO>(project);
        }

        public void DeleteProjects(int id)
        {
            var Projects = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (Projects == null)
            {
                throw new Exception("Projects not found");
            }
            Projects.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
