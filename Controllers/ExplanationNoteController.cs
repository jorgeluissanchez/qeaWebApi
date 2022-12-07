using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExplanationNoteController : ControllerBase
{
    IExplanationNoteService explanationNoteService;
    public ExplanationNoteController(IExplanationNoteService service)
    {
        explanationNoteService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(explanationNoteService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] ExplanationNote explanationNote)
    {
        return Ok(explanationNoteService.Create(explanationNote));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] ExplanationNote explanationNote)
    {
        return Ok(explanationNoteService.Update(id, explanationNote));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(explanationNoteService.Delete(id));
    }
}