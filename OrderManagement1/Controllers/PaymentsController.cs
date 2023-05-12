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
    public class PaymentsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;

        public PaymentsController(OrderManagement81363Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<IActionResult> GetPayment()
        {
            //GET data from database-Domain models
            var payment = await _context.Payment.Include("Order").ToListAsync();

            //Map and Return Dtos
            return Ok(mapper.Map<List<GetPaymentDto>>(payment));
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = await _context.Payment.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<PaymentDto>(payment));
        }

        // PUT: api/Payments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment([FromRoute] int id, [FromBody] PaymentDto paymentDto)
        {
            var payment = mapper.Map<Payment>(paymentDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // POST: api/Payments
        [HttpPost]
        public async Task<IActionResult> PostPayment([FromBody] PaymentDto paymentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = mapper.Map<Payment>(paymentDto);
            await _context.Payment.AddAsync(payment);
            var paymentDto1 = mapper.Map<PaymentDto>(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.PaymentId }, payment);
        }

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var payment = await _context.Payment.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payment.Remove(payment);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<PaymentDto>(payment));
        }

        private bool PaymentExists(int id)
        {
            return _context.Payment.Any(e => e.PaymentId == id);
        }
    }
}