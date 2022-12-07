using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService categoryService;
    public CategoryController(ICategoryService service)
    {
        categoryService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(categoryService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] Category category)
    {
        return Ok(categoryService.Create(category));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] Category category)
    {
        return Ok(categoryService.Update(id, category));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(categoryService.Delete(id));
    }
}