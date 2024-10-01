using AutoMapper;
using InventoryManagement.Server.Data.Models.ViewModels;
using InventoryManagement.Server.Data;
using InventoryManagement.Server.Data.Models;

namespace InventoryManagement.Server.Services
{
    public class Projectervice : IProjectService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public Projectervice(ApplicationDbContext context, IMapper mapper)
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
            var Project = _mapper.Map<Projects>(ProjectsDto);
            _context.Projects.Add(Project);
            _context.SaveChanges();
            return _mapper.Map<ProjectsDTO>(Project);
        }

        public ProjectsDTO UpdateProjects(int id, ProjectsDTO ProjectsDto)
        {
            var Projects = _context.Projects.FirstOrDefault(p => p.Id == id);
            if (Projects == null)
            {
                throw new Exception("Projects not found");
            }

            _mapper.Map(ProjectsDto, Projects);
            _context.SaveChanges();
            return _mapper.Map<ProjectsDTO>(Projects);
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
