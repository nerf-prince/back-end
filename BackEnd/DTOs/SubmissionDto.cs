using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.DTOs;

public class SubmissionDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string UserId { get; set; } = string.Empty;
    public string TestId { get; set; } = string.Empty;
    public SubmissionSub1Dto Sub1 { get; set; } = new();
    public SubmissionSub2Dto Sub2 { get; set; } = new();
    public SubmissionSub3Dto Sub3 { get; set; } = new();
}

// Sub1 - Multiple choice questions
public class SubmissionSub1Dto
{
    public List<SubmissionExDto> Ex { get; set; } = new();
}

public class SubmissionExDto
{
    public string Sentence { get; set; } = string.Empty;
    public int QuestionNumber { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

// Sub2 - Code and short answer questions
public class SubmissionSub2Dto
{
    public SubmissionEx1Dto Ex1 { get; set; } = new();
    public SubmissionEx2Dto Ex2 { get; set; } = new();
    public SubmissionEx3Dto Ex3 { get; set; } = new();
}

public class SubmissionEx1Dto
{
    public string Code { get; set; } = string.Empty;
    public string Sentence { get; set; } = string.Empty;
    public SubmissionSubQuestionDto a { get; set; } = new();
    public SubmissionSubQuestionDto b { get; set; } = new();
    public SubmissionSubQuestionDto c { get; set; } = new();
    public SubmissionSubQuestionDto d { get; set; } = new();
}

public class SubmissionSubQuestionDto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

public class SubmissionEx2Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

public class SubmissionEx3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

// Sub3 - Programming exercises
public class SubmissionSub3Dto
{
    public SubmissionEx1Sub3Dto Ex1 { get; set; } = new();
    public SubmissionEx2Sub3Dto Ex2 { get; set; } = new();
    public SubmissionEx3Sub3Dto Ex3 { get; set; } = new();
}

public class SubmissionEx1Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

public class SubmissionEx2Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

public class SubmissionEx3Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public string UserAnswer { get; set; } = string.Empty;
    public int Score { get; set; }
}

