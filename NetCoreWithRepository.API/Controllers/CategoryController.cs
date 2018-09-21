using Microsoft.AspNetCore.Mvc;
using NetCoreWithRepository.Data.Model.Request;
using NetCoreWithRepository.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Threading.Tasks;

namespace NetCoreWithRepository.API.Controllers
{
    [Produces("application/json")]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No category found for requested filter.")]
        public async Task<IActionResult> Get()
        {
            var result = await categoryService.List(x => x.IsActive, 10);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Data == null)
            {
                return NotFound("No category found for requested filter.");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = "No category found for requested filter.")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await categoryService.Get(id);

            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else if (result.Data == null)
            {
                return NotFound("No category found for requested filter.");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Category successfully added.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Post([FromBody] CategoryRequestModel category)
        {
            var result = await categoryService.Create(category);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Category successfully added.");
            }
        }

        [HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Category successfully updated.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Put([FromBody] CategoryRequestModel category)
        {
            var result = await categoryService.Update(category);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Category successfully updated.");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(int), Description = "Category successfully deleted.")]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = "Request not accepted.")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await categoryService.Delete(id);
            if (result.HasError)
            {
                return BadRequest(result.Errors);
            }
            else
            {
                return Ok("Category successfully deleted.");
            }
        }
    }
}
