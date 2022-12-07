using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;
namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseController : ControllerBase
{
    ICourseService courseService;
    public CourseController(ICourseService service)
    {
        courseService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(courseService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] Course course)
    {
        return Ok(courseService.Create(course));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] Course course)
    {
        return Ok(courseService.Update(id, course));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(courseService.Delete(id));
    }
}