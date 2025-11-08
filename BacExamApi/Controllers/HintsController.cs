using BacExamApi.Models;
using BacExamApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacExamApi.Controllers;

/// <summary>
/// API Controller for managing hints and guidance
/// </summary>
[ApiController]
[Route("api/questions/{questionId}/[controller]")]
public class HintsController : ControllerBase
{
    private readonly ExamService _examService;
    private readonly ILogger<HintsController> _logger;
    
    public HintsController(ExamService examService, ILogger<HintsController> logger)
    {
        _examService = examService;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all hints for a specific question
    /// </summary>
    /// <param name="questionId">Question ID</param>
    /// <returns>List of hints for the question</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<Hint>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<List<Hint>> GetHints(int questionId)
    {
        _logger.LogInformation("Getting hints for question ID: {QuestionId}", questionId);
        
        var question = _examService.GetQuestionById(questionId);
        if (question == null)
        {
            _logger.LogWarning("Question with ID {QuestionId} not found", questionId);
            return NotFound(new { message = $"Question with ID {questionId} not found" });
        }
        
        var hints = _examService.GetHintsForQuestion(questionId);
        return Ok(hints);
    }
    
    /// <summary>
    /// Get a specific hint by order number
    /// </summary>
    /// <param name="questionId">Question ID</param>
    /// <param name="order">Hint order number</param>
    /// <returns>The requested hint</returns>
    [HttpGet("{order}")]
    [ProducesResponseType(typeof(Hint), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Hint> GetHintByOrder(int questionId, int order)
    {
        _logger.LogInformation("Getting hint {Order} for question ID: {QuestionId}", order, questionId);
        
        var question = _examService.GetQuestionById(questionId);
        if (question == null)
        {
            _logger.LogWarning("Question with ID {QuestionId} not found", questionId);
            return NotFound(new { message = $"Question with ID {questionId} not found" });
        }
        
        var hint = _examService.GetHintByOrder(questionId, order);
        if (hint == null)
        {
            _logger.LogWarning("Hint {Order} for question {QuestionId} not found", order, questionId);
            return NotFound(new { message = $"Hint {order} for question {questionId} not found" });
        }
        
        return Ok(hint);
    }
}
