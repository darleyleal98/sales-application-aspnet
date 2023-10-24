﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesApplication.Data;
using SalesApplication.Models.Entities;

namespace SalesApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : ControllerBase
    {
        private readonly SalesApplicationContext _context;

        public DepartamentsController(SalesApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Departaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departament>>> GetDepartament()
        {
          if (_context.Departament == null)
          {
              return NotFound();
          }
            return await _context.Departament.ToListAsync();
        }

        // GET: api/Departaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departament>> GetDepartament(int id)
        {
          if (_context.Departament == null)
          {
              return NotFound();
          }
            var departament = await _context.Departament.FindAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return departament;
        }

        // PUT: api/Departaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartament(int id, Departament departament)
        {
            if (id != departament.Id)
            {
                return BadRequest();
            }

            _context.Entry(departament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Departaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departament>> PostDepartament(Departament departament)
        {
          if (_context.Departament == null)
          {
              return Problem("Entity set 'SalesApplicationContext.Departament'  is null.");
          }
            _context.Departament.Add(departament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartament", new { id = departament.Id }, departament);
        }

        // DELETE: api/Departaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartament(int id)
        {
            if (_context.Departament == null)
            {
                return NotFound();
            }
            var departament = await _context.Departament.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }

            _context.Departament.Remove(departament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentExists(int id)
        {
            return (_context.Departament?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
