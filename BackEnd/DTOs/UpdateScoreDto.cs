namespace BackEnd.DTOs;

// DTO pentru update de scoruri - structură flexibilă
public class UpdateScoreDto
{
    public string? SubmissionId { get; set; }
    public string Path { get; set; } = string.Empty; // ex: "sub2.ex2.score" sau "sub2.ex1.a.score"
    public int Score { get; set; }
}

