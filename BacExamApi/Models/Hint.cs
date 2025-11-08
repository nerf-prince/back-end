namespace BacExamApi.Models;

/// <summary>
/// Represents a hint or guidance for solving a programming question
/// </summary>
public class Hint
{
    public int Id { get; set; }
    
    /// <summary>
    /// The hint text/content
    /// </summary>
    public string Content { get; set; } = string.Empty;
    
    /// <summary>
    /// The order/level of the hint (1 = first hint, 2 = second hint, etc.)
    /// </summary>
    public int Order { get; set; }
    
    /// <summary>
    /// The type of hint (e.g., "Approach", "Algorithm", "Implementation", "Optimization")
    /// </summary>
    public string Type { get; set; } = string.Empty;
    
    /// <summary>
    /// Reference to the parent question
    /// </summary>
    public int ExamQuestionId { get; set; }
}
