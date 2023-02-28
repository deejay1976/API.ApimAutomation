using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MHR.API.ApimAutomation.Models;

namespace MHR.API.ApimAutomation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public CustomersController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCustomer>>> GetTblCustomers()
        {
          if (_context.TblCustomers == null)
          {
              return NotFound();
          }
            return await _context.TblCustomers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblCustomer>> GetTblCustomer(int id)
        {
          if (_context.TblCustomers == null)
          {
              return NotFound();
          }
            var tblCustomer = await _context.TblCustomers.FindAsync(id);

            if (tblCustomer == null)
            {
                return NotFound();
            }

            return tblCustomer;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCustomer(int id, TblCustomer tblCustomer)
        {
            if (id != tblCustomer.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblCustomer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCustomerExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCustomer>> PostTblCustomer(TblCustomer tblCustomer)
        {
          if (_context.TblCustomers == null)
          {
              return Problem("Entity set 'CustomerDbContext.TblCustomers'  is null.");
          }
            _context.TblCustomers.Add(tblCustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblCustomerExists(tblCustomer.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblCustomer", new { id = tblCustomer.Id }, tblCustomer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCustomer(int id)
        {
            if (_context.TblCustomers == null)
            {
                return NotFound();
            }
            var tblCustomer = await _context.TblCustomers.FindAsync(id);
            if (tblCustomer == null)
            {
                return NotFound();
            }

            _context.TblCustomers.Remove(tblCustomer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblCustomerExists(int id)
        {
            return (_context.TblCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
