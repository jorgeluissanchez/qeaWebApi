using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnswerController : ControllerBase
{
    IAnswerService answerService;
    public AnswerController(IAnswerService service)
    {
        answerService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(answerService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] Answer answer)
    {
        return Ok(answerService.Create(answer));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] Answer answer)
    {
        return Ok(answerService.Update(id, answer));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(answerService.Delete(id));
    }
}