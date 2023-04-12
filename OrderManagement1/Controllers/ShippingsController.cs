 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement1.Dto;
using OrderManagement1.Models;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;

        public ShippingsController(OrderManagement81363Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Shippings
        [HttpGet]
        public async Task<IActionResult> GetShipping()
        {
            //GET data from database-Domain models
            var shipping = await _context.Shipping.Include("Order").ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<GetShippingDto>>(shipping));
        }

        // GET: api/Shippings/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShipping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipping = await _context.Shipping.FindAsync(id);

            if (shipping == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ShippingDto>(shipping));
        }

        // PUT: api/Shippings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipping([FromRoute] int id, [FromBody] ShippingDto shippingDto)
        {
            var shipping = mapper.Map<Shipping>(shippingDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shipping.ShippingId)
            {
                return BadRequest();
            }

            _context.Entry(shipping).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShippingExists(id))
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

        // POST: api/Shippings
        [HttpPost]
        public async Task<IActionResult> PostShipping([FromBody] ShippingDto shippingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipping = mapper.Map<Shipping>(shippingDto);
            await _context.Shipping.AddAsync(shipping);
            var shippingDto1 = mapper.Map<ShippingDto>(shipping);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipping", new { id = shipping.ShippingId }, shipping);
        }

        // DELETE: api/Shippings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipping([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var shipping = await _context.Shipping.FindAsync(id);
            if (shipping == null)
            {
                return NotFound();
            }

            _context.Shipping.Remove(shipping);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<ShippingDto>(shipping));
        }

        private bool ShippingExists(int id)
        {
            return _context.Shipping.Any(e => e.ShippingId == id);
        }
    }
}