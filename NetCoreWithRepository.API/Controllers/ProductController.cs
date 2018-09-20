using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreWithRepository.Data.Model.Request;
using NetCoreWithRepository.Service;
using Swashbuckle.AspNetCore.Annotations;

namespace NetCoreWithRepository.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;
        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No Product found for requested filter.")]
        public async Task<IActionResult> Get()
        {
            var result = await ProductService.List(x => x.IsActive, 10);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Data == null)
            {
                return NotFound("No Product found for requested filter.");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}", Name = "Get")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No Product found for requested filter.")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await ProductService.Get(id);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Data == null)
            {
                return NotFound("No Product found for requested filter.");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Product successfully added.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Post([FromBody] ProductRequestModel Product)
        {
            var result = await ProductService.Create(Product);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Product successfully added.");
            }
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Product successfully updated.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Put([FromBody] ProductRequestModel Product)
        {
            var result = await ProductService.Update(Product);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Product successfully updated.");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Product successfully deleted.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await ProductService.Delete(id);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Product successfully deleted.");
            }
        }
    }
}
