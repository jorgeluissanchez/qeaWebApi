using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    ISubjectService subjectService;
    public SubjectController(ISubjectService service)
    {
        subjectService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(subjectService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] Subject subject)
    {
        return Ok(subjectService.Create(subject));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] Subject subject)
    {
        return Ok(subjectService.Update(id, subject));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(subjectService.Delete(id));
    }
}