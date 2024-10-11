using investmentsManagement.Server.Data.Models.ViewModels;
using investmentsManagement.Server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace investmentsManagement.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _Projectservice;
        public ProjectController(IProjectService Projectservice)
        {
            _Projectservice = Projectservice;
        }
        [HttpGet(Name = "GetAllProjects")]
        public IActionResult Get()
        {
            return Ok(_Projectservice.GetAllProjects());
        }
        [HttpPost]
        public IActionResult Create([FromBody] ProjectsDTO ProjectsDto)
        {
            if (ProjectsDto == null)
            {
                return BadRequest("Projects data is null.");
            }

            var createdProjects = _Projectservice.CreateProjects(ProjectsDto);
            return CreatedAtRoute("GetProjectsById", new { id = createdProjects.Id }, createdProjects);
        }

        [HttpGet("{id}", Name = "GetProjectsById")]
        public IActionResult Get(int id)
        {
            var Projects = _Projectservice.GetProjectsById(id);
            if (Projects == null)
            {
                return NotFound();
            }

            return Ok(Projects);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ProjectsDTO ProjectsDto)
        {
            if (ProjectsDto == null || id != ProjectsDto.Id)
            {
                return BadRequest("Projects data is invalid.");
            }

            var updatedProjects = _Projectservice.UpdateProjects(id, ProjectsDto);
            if (updatedProjects == null)
            {
                return NotFound();
            }

            return Ok(updatedProjects);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Projects = _Projectservice.GetProjectsById(id);
            if (Projects == null)
            {
                return NotFound();
            }

            _Projectservice.DeleteProjects(id);
            return NoContent();
        }
    }
}
