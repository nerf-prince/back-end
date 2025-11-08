using BackEnd.DTOs;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Collections;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamsController(ExamsCollection examsCollection) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ExamDto>>> GetAll()
    {
        var exams = await examsCollection.All();
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExamDto>> GetById(string id)
    {
        var exam = await examsCollection.One(id);

        if (exam == null)
        {
            return NotFound();
        }

        return Ok(exam);
    }
}

