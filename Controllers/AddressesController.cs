﻿using System;
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
    public class AddressesController : ControllerBase
    {
        private readonly CustomerDbContext _context;

        public AddressesController(CustomerDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAddress>>> GetTblAddresses()
        {
          if (_context.TblAddresses == null)
          {
              return NotFound();
          }
            return await _context.TblAddresses.ToListAsync();
        }

        // GET: api/Addresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblAddress>> GetTblAddress(int id)
        {
          if (_context.TblAddresses == null)
          {
              return NotFound();
          }
            var tblAddress = await _context.TblAddresses.FindAsync(id);

            if (tblAddress == null)
            {
                return NotFound();
            }

            return tblAddress;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAddress(int id, TblAddress tblAddress)
        {
            if (id != tblAddress.AddressId)
            {
                return BadRequest();
            }

            _context.Entry(tblAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAddress>> PostTblAddress(TblAddress tblAddress)
        {
          if (_context.TblAddresses == null)
          {
              return Problem("Entity set 'CustomerDbContext.TblAddresses'  is null.");
          }
            _context.TblAddresses.Add(tblAddress);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TblAddressExists(tblAddress.AddressId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTblAddress", new { id = tblAddress.AddressId }, tblAddress);
        }

        // DELETE: api/Addresses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAddress(int id)
        {
            if (_context.TblAddresses == null)
            {
                return NotFound();
            }
            var tblAddress = await _context.TblAddresses.FindAsync(id);
            if (tblAddress == null)
            {
                return NotFound();
            }

            _context.TblAddresses.Remove(tblAddress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblAddressExists(int id)
        {
            return (_context.TblAddresses?.Any(e => e.AddressId == id)).GetValueOrDefault();
        }
    }
}
