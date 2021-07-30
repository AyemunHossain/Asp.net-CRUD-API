using Base.Models;
using DataStore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Filters;

namespace WebApiCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class TicketsController : ControllerBase
    {
        private readonly BugsContext _db;
        public TicketsController(BugsContext db)
        {
            this._db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Tickets);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var Ticket = _db.Tickets.Find(id);
            if (Ticket == null)
                return NotFound();

            return Ok(Ticket);
        }

        [HttpPost]
        [Ticket_EnsureEnteredDate]      //action filter
        public IActionResult Post([FromBody] Ticket ticket)
        {
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetById),
                new { id = ticket.Id },
                ticket
                );
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Ticket ticket)
        {
            if(id != ticket.Id)
                return BadRequest();
            _db.Entry(ticket).State = EntityState.Modified;
            try
            {
                _db.SaveChanges();
            }
            catch
            {
                if (_db.Tickets.Find(id) == null)
                    return NotFound();
                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]        //overriding route
        public IActionResult Delete (int id)
        {
            var ticket = _db.Tickets.Find(id);
            if (ticket == null) return NotFound();

            _db.Tickets.Remove(ticket);
            _db.SaveChanges();

            return Ok(ticket);
        }
    }
}
