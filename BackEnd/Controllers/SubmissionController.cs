using BackEnd.DTOs;
using Microsoft.AspNetCore.Mvc;
using BackEnd.Collections;
using BackEnd.Services;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubmissionController(
        SubmissionsCollection submissionsCollection,
        ITopicProducer processingTopicClient) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<SubmissionDto>>> GetAll()
    {
        var submissions = await submissionsCollection.All();
        return Ok(submissions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubmissionDto>> GetById(string id)
    {
        var submission = await submissionsCollection.One(id);
        if (submission == null)
        {
            return NotFound();
        }
        return Ok(submission);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<List<SubmissionDto>>> GetByUserId(string userId)
    {
        var submissions = await submissionsCollection.ByUserId(userId);
        return Ok(submissions);
    }

    [HttpGet("test/{testId}")]
    public async Task<ActionResult<List<SubmissionDto>>> GetByTestId(string testId)
    {
        var submissions = await submissionsCollection.ByTestId(testId);
        return Ok(submissions);
    }

    [HttpPost]
    public async Task<ActionResult<SubmissionDto>> Create([FromBody] SubmissionDto submission)
    {
        var createdSubmission = await submissionsCollection.Create(submission);
        await processingTopicClient.SendAsync(createdSubmission);
        return CreatedAtAction(nameof(GetById), new { id = createdSubmission.Id }, createdSubmission);
    }
}

