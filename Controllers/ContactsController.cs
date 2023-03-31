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
    public class ContactsController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public ContactsController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblContact>>> GetTblContacts()
        {
          if (_context.TblContacts == null)
          {
              return NotFound();
          }
            return await _context.TblContacts.ToListAsync();
        }

        // GET: api/Contacts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblContact>> GetTblContact(int id)
        {
          if (_context.TblContacts == null)
          {
              return NotFound();
          }
            var tblContact = await _context.TblContacts.FindAsync(id);

            if (tblContact == null)
            {
                return NotFound();
            }

            return tblContact;
        }

        // PUT: api/Contacts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Update the customer record
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblContact"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblContact(int id, TblContact tblContact)
        {
            if (id != tblContact.ContactId)
            {
                return BadRequest();
            }

            _context.Entry(tblContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblContactExists(id))
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

        // POST: api/Contacts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblContact>> PostTblContact(TblContact tblContact)
        {
          if (_context.TblContacts == null)
          {
              return Problem("Entity set 'CustomerDbContext.TblContacts'  is null.");
          }
            _context.TblContacts.Add(tblContact);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblContactExists(tblContact.ContactId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblContact", new { id = tblContact.ContactId }, tblContact);
        }

        // DELETE: api/Contacts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblContact(int id)
        {
            if (_context.TblContacts == null)
            {
                return NotFound();
            }
            var tblContact = await _context.TblContacts.FindAsync(id);
            if (tblContact == null)
            {
                return NotFound();
            }

            _context.TblContacts.Remove(tblContact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblContactExists(int id)
        {
            return (_context.TblContacts?.Any(e => e.ContactId == id)).GetValueOrDefault();
        }
    }
}
