using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExplanationVideoController : ControllerBase
{
    IExplanationVideoService explanationVideoService;
    public ExplanationVideoController(IExplanationVideoService service)
    {
        explanationVideoService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(explanationVideoService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] ExplanationVideo explanationVideo)
    {
        return Ok(explanationVideoService.Create(explanationVideo));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] ExplanationVideo explanationVideo)
    {
        return Ok(explanationVideoService.Update(id, explanationVideo));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(explanationVideoService.Delete(id));
    }
}