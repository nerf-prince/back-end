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
    public async Task<ActionResult<SubmissionDto>> Create([FromBody] CreateSubmissionDto createSubmission)
    {
        // Map CreateSubmissionDto to SubmissionDto (MongoDB will generate the Id)
        var submission = new SubmissionDto
        {
            UserId = createSubmission.UserId,
            TestId = createSubmission.TestId,
            Sub1 = createSubmission.Sub1,
            Sub2 = createSubmission.Sub2,
            Sub3 = createSubmission.Sub3
        };
        
        var createdSubmission = await submissionsCollection.Create(submission);
        await processingTopicClient.SendAsync(createdSubmission);
        return CreatedAtAction(nameof(GetById), new { id = createdSubmission.Id }, createdSubmission);
    }

    [HttpPatch("{id}/score")]
    public async Task<ActionResult> UpdateScore(string id, [FromBody] UpdateScoreDto updateScore)
    {
        // Verifică dacă submission-ul există
        var submission = await submissionsCollection.One(id);
        if (submission == null)
        {
            return NotFound(new { message = "Submission not found" });
        }

        // Update doar scorul la path-ul specificat
        var updated = await submissionsCollection.UpdateScore(id, updateScore.Path, updateScore.Score);
        
        if (!updated)
        {
            return StatusCode(500, new { message = "Failed to update score" });
        }

        return NoContent();
    }
}

