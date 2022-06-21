﻿using Microsoft.AspNetCore.Mvc;
using Smurfs.Business.Abstract;
using Smurfs.DataAccess.Abstract;
using Smurfs.Entities.Conrete;

namespace Smurfs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController:ControllerBase
    {
            
            private IProjectService _projectService;

            public ProjectController(IProjectService projectService)
            {
                _projectService = projectService;
            }

            // GET: api/<ProjectController>
            [HttpGet("GetAllp")]
            public async Task<IActionResult> GetAll()
            {
                var Project = await _projectService.GetAll();
                return Ok(Project);
            }

            // GET api/<ProjectController>/5
            [HttpGet("GetByIdp")]
            public async Task<IActionResult> GetById(int Id)
            {
                var p = await _projectService.GetById(Id);
                if (p == null)
                {
                    return NotFound();
                }

                return Ok(p);
            }

            // POST api/<ProjectController>/5
            [HttpPost("Savep")]
                public IActionResult SaveProject([FromBody] Project project)
                {
                    _projectService.Create(project);
                    return Ok(project);
                }

            // PUT api/<ProjectController>/5
            [HttpPut("Updatep")]
                public IActionResult Update([FromBody] Project project)
                {
                    _projectService.Update(project);
                    return Ok(project);
                }

            // DELETE api/<ProjectController>/5
            [HttpDelete("Deletep")]
                public IActionResult Delete([FromBody] Project project)
                {
                    _projectService.Delete(project);
                    return Ok("Silindi");
                }

            // CALCULATE api/<ProjectController>/5
            [HttpPost("Calculatep")]
                public IActionResult Calculate([FromBody] int projectId)
                {
                    _projectService.Calculate(projectId);
                    return Ok("Hesaplamalar doğru şekilde yapıldı");
                }

    }
}
