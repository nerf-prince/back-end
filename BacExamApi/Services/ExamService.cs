using BacExamApi.Data;
using BacExamApi.Models;

namespace BacExamApi.Services;

/// <summary>
/// Service for managing exam questions and providing guidance
/// </summary>
public class ExamService
{
    private readonly ExamRepository _repository;
    
    public ExamService(ExamRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    /// Get all exam questions
    /// </summary>
    public List<ExamQuestion> GetAllQuestions()
    {
        return _repository.GetAll();
    }
    
    /// <summary>
    /// Get a specific question by ID
    /// </summary>
    public ExamQuestion? GetQuestionById(int id)
    {
        return _repository.GetById(id);
    }
    
    /// <summary>
    /// Get questions filtered by difficulty
    /// </summary>
    public List<ExamQuestion> GetQuestionsByDifficulty(string difficulty)
    {
        return _repository.GetByDifficulty(difficulty);
    }
    
    /// <summary>
    /// Get questions filtered by subject
    /// </summary>
    public List<ExamQuestion> GetQuestionsBySubject(string subject)
    {
        return _repository.GetBySubject(subject);
    }
    
    /// <summary>
    /// Get questions filtered by year
    /// </summary>
    public List<ExamQuestion> GetQuestionsByYear(int year)
    {
        return _repository.GetByYear(year);
    }
    
    /// <summary>
    /// Get hints for a specific question
    /// </summary>
    public List<Hint> GetHintsForQuestion(int questionId)
    {
        var question = _repository.GetById(questionId);
        return question?.Hints ?? new List<Hint>();
    }
    
    /// <summary>
    /// Get a specific hint by order number for a question
    /// </summary>
    public Hint? GetHintByOrder(int questionId, int order)
    {
        var question = _repository.GetById(questionId);
        return question?.Hints.FirstOrDefault(h => h.Order == order);
    }
    
    /// <summary>
    /// Add a new exam question
    /// </summary>
    public void AddQuestion(ExamQuestion question)
    {
        _repository.Add(question);
    }
}
