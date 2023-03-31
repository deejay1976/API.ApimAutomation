using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MHR.API.ApimAutomation;

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
        /// <summary>
        /// Get the Customer Details based upon the customer id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Update the customer details 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblCustomer"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Add a customer
        /// </summary>
        /// <param name="tblCustomer"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Delete the customer details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Find out if a customer exists in record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool TblCustomerExists(int id)
        {
            return (_context.TblCustomers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
