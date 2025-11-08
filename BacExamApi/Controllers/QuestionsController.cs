using BacExamApi.Models;
using BacExamApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BacExamApi.Controllers;

/// <summary>
/// API Controller for managing exam questions
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class QuestionsController : ControllerBase
{
    private readonly ExamService _examService;
    private readonly ILogger<QuestionsController> _logger;
    
    public QuestionsController(ExamService examService, ILogger<QuestionsController> logger)
    {
        _examService = examService;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all exam questions
    /// </summary>
    /// <returns>List of all exam questions</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ExamQuestion>), StatusCodes.Status200OK)]
    public ActionResult<List<ExamQuestion>> GetAll()
    {
        _logger.LogInformation("Getting all exam questions");
        var questions = _examService.GetAllQuestions();
        return Ok(questions);
    }
    
    /// <summary>
    /// Get a specific exam question by ID
    /// </summary>
    /// <param name="id">Question ID</param>
    /// <returns>The exam question</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExamQuestion), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ExamQuestion> GetById(int id)
    {
        _logger.LogInformation("Getting exam question with ID: {Id}", id);
        var question = _examService.GetQuestionById(id);
        
        if (question == null)
        {
            _logger.LogWarning("Question with ID {Id} not found", id);
            return NotFound(new { message = $"Question with ID {id} not found" });
        }
        
        return Ok(question);
    }
    
    /// <summary>
    /// Get questions filtered by difficulty
    /// </summary>
    /// <param name="difficulty">Difficulty level (Easy, Medium, Hard)</param>
    /// <returns>List of questions with specified difficulty</returns>
    [HttpGet("difficulty/{difficulty}")]
    [ProducesResponseType(typeof(List<ExamQuestion>), StatusCodes.Status200OK)]
    public ActionResult<List<ExamQuestion>> GetByDifficulty(string difficulty)
    {
        _logger.LogInformation("Getting questions with difficulty: {Difficulty}", difficulty);
        var questions = _examService.GetQuestionsByDifficulty(difficulty);
        return Ok(questions);
    }
    
    /// <summary>
    /// Get questions filtered by subject
    /// </summary>
    /// <param name="subject">Subject area</param>
    /// <returns>List of questions in the specified subject</returns>
    [HttpGet("subject/{subject}")]
    [ProducesResponseType(typeof(List<ExamQuestion>), StatusCodes.Status200OK)]
    public ActionResult<List<ExamQuestion>> GetBySubject(string subject)
    {
        _logger.LogInformation("Getting questions with subject: {Subject}", subject);
        var questions = _examService.GetQuestionsBySubject(subject);
        return Ok(questions);
    }
    
    /// <summary>
    /// Get questions filtered by year
    /// </summary>
    /// <param name="year">Exam year</param>
    /// <returns>List of questions from the specified year</returns>
    [HttpGet("year/{year}")]
    [ProducesResponseType(typeof(List<ExamQuestion>), StatusCodes.Status200OK)]
    public ActionResult<List<ExamQuestion>> GetByYear(int year)
    {
        _logger.LogInformation("Getting questions from year: {Year}", year);
        var questions = _examService.GetQuestionsByYear(year);
        return Ok(questions);
    }
    
    /// <summary>
    /// Add a new exam question
    /// </summary>
    /// <param name="question">The question to add</param>
    /// <returns>The created question</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ExamQuestion), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ExamQuestion> Create([FromBody] ExamQuestion question)
    {
        _logger.LogInformation("Creating new exam question: {Title}", question.Title);
        
        if (string.IsNullOrWhiteSpace(question.Title) || string.IsNullOrWhiteSpace(question.Description))
        {
            return BadRequest(new { message = "Title and Description are required" });
        }
        
        _examService.AddQuestion(question);
        return CreatedAtAction(nameof(GetById), new { id = question.Id }, question);
    }
}
