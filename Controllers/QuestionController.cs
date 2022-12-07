using Microsoft.AspNetCore.Mvc;
using qea_webapi.Services;
using qea_webapi.Models;

namespace qea_webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    IQuestionService questionService;
    public QuestionController(IQuestionService service)
    {
        questionService = service;
    }

    [HttpGet]
    public ActionResult Get()
    {
        return Ok(questionService.Get());
    }

    [HttpPost]
    public ActionResult Create([FromBody] Question question)
    {
        return Ok(questionService.Create(question));
    }

    [HttpPut("{id}")]
    public ActionResult Update(Guid id, [FromBody] Question question)
    {
        return Ok(questionService.Update(id, question));
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(Guid id)
    {
        return Ok(questionService.Delete(id));
    }
}