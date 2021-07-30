using Base.Models;
using DataStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly BugsContext _db;
        public ProjectsController(BugsContext db)
        {
            this._db = db;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Projects);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var project = _db.Projects.Find(id);
            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpGet]
        [Route("/api/projects/{pid}/tickets")]
        public IActionResult GetProjectTicket(int pid)
        {
            var tickets = _db.Tickets.Where(t => t.ProjectId == pid).ToList();
            if (tickets == null || tickets.Count <= 0)
                return NotFound();
            return Ok(tickets);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                new { id = project.Id },
                project
                );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Project project)
        {
            if (id != project.Id)
                return BadRequest();
            _db.Entry(project).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Projects.Find(id) == null)
                    return NotFound();
                throw;
            }
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _db.Projects.Find(id);
            if (project == null) return NotFound();

            _db.Projects.Remove(project);
            _db.SaveChanges();

            return Ok(project);
        }

        
    }
}
