using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagement1.Dto;
using OrderManagement1.Models;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderItemsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;

        public OrderItemsController(OrderManagement81363Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/OrderItems
        [HttpGet]
        public async Task<IActionResult> GetOrderItems()
        {
            //GET data from database-Domain models
            var orderItems = await _context.OrderItems.Include("Order").Include("Product").ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<GetOrderItemsDto>>(orderItems));
        }

        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);

            if (orderItems == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OrderItemsDto>(orderItems));
        }

        // PUT: api/OrderItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItems([FromRoute] int id, [FromBody] OrderItemsDto orderItemsDto)
        {
            var orderItems = mapper.Map<OrderItems>(orderItemsDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != orderItems.OrderItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemsExists(id))
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

        // POST: api/OrderItems
        [HttpPost]
        public async Task<IActionResult> PostOrderItems([FromBody] OrderItemsDto orderItemsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = mapper.Map<OrderItems>(orderItemsDto);
            await _context.OrderItems.AddAsync(orderItems);
            var orderItemsDto1 = mapper.Map<OrderItemsDto>(orderItems);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItems", new { id = orderItems.OrderItemId }, orderItems);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItems([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var orderItems = await _context.OrderItems.FindAsync(id);
            if (orderItems == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItems);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<OrderItemsDto>(orderItems));
        }

        private bool OrderItemsExists(int id)
        {
            return _context.OrderItems.Any(e => e.OrderItemId == id);
        }
    }
}