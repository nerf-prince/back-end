namespace BackEnd.DTOs;

public class CreateSubmissionDto
{
    public string UserId { get; set; } = string.Empty;
    public string TestId { get; set; } = string.Empty;
    public SubmissionSub1Dto Sub1 { get; set; } = new();
    public SubmissionSub2Dto Sub2 { get; set; } = new();
    public SubmissionSub3Dto Sub3 { get; set; } = new();
}

