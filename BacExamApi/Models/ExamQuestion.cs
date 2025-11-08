namespace BacExamApi.Models;

/// <summary>
/// Represents a programming question from the Romanian BACALAUREAT exam
/// </summary>
public class ExamQuestion
{
    public int Id { get; set; }
    
    /// <summary>
    /// The title of the question
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// The complete text/description of the problem
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Difficulty level (e.g., "Easy", "Medium", "Hard")
    /// </summary>
    public string Difficulty { get; set; } = string.Empty;
    
    /// <summary>
    /// The subject area (e.g., "Algorithms", "Data Structures", "Arrays", "Sorting")
    /// </summary>
    public string Subject { get; set; } = string.Empty;
    
    /// <summary>
    /// Year of the exam
    /// </summary>
    public int Year { get; set; }
    
    /// <summary>
    /// Example input for the problem
    /// </summary>
    public string? ExampleInput { get; set; }
    
    /// <summary>
    /// Example output for the problem
    /// </summary>
    public string? ExampleOutput { get; set; }
    
    /// <summary>
    /// Constraints and requirements
    /// </summary>
    public string? Constraints { get; set; }
    
    /// <summary>
    /// Collection of hints/guidance for solving this question
    /// </summary>
    public List<Hint> Hints { get; set; } = new();
}
