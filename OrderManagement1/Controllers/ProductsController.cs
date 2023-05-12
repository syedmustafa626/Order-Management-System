using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
using OrderManagement1.Dto;
using OrderManagement1.Models;

namespace OrderManagement1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly OrderManagement81363Context _context;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ProductsController(OrderManagement81363Context context, IMapper mapper, ILogger<ProductsController> logger)
        {
            _context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        // GET: api/Products
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetProducts()
        {

            logger.LogInformation("Get: api/Products");

            //GET data from database-Domain models
            var products = await _context.Products.Include("Category").ToListAsync();

            //Map Domain Model to Dto
            //var productsDto = mapper.Map<List<ProductsDto>>(products);

            //Return Dtos
            return Ok(mapper.Map<List<GetProductsDto>>(products));
        }

        //public IEnumerable<Products> GetProducts1()
        //{
        //    return _context.Products; 
        //}

        // GET: api/Products/5
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);

            if (products == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductsDto>(products));
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts([FromRoute] int id, [FromBody] ProductsDto productsDto)
        {
            var products = mapper.Map<Products>(productsDto);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != products.ProductId)
            {
                return BadRequest();
            }            

            _context.Entry(products).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductsExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProducts([FromBody]  ProductsDto productsDto)
        {
            if (ModelState.IsValid)
            {
                var products = mapper.Map<Products>(productsDto);

                await _context.Products.AddAsync(products);

                var productsDto1 = mapper.Map<ProductsDto>(products);


                await _context.SaveChangesAsync();

                return CreatedAtAction("GetProducts", new { id = products.ProductId }, products);
            }
            return BadRequest(ModelState);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();

            return Ok(mapper.Map<ProductsDto>(products));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}