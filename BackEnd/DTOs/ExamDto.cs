using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BackEnd.DTOs;

public class ExamDto
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public Sub1Dto Sub1 { get; set; } = new();
    public Sub2Dto Sub2 { get; set; } = new();
    public Sub3Dto Sub3 { get; set; } = new();
    public string AnScolar { get; set; } = string.Empty;
    public string Sesiune { get; set; } = string.Empty;
}

public class Sub1Dto
{
    public List<ExDto> Ex { get; set; } = new();
}

public class ExDto
{
    public string Sentence { get; set; } = string.Empty;
    public int QuestionNumber { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
}

public class Sub2Dto
{
    public Ex1Dto Ex1 { get; set; } = new();
    public Ex2Dto Ex2 { get; set; } = new();
    public Ex3Dto Ex3 { get; set; } = new();
}

public class Ex1Dto
{
    public string Code { get; set; } = string.Empty;
    public string Sentence { get; set; } = string.Empty;
    public SubQuestionDto a { get; set; } = new();
    public SubQuestionDto b { get; set; } = new();
    public SubQuestionDto c { get; set; } = new();
    public SubQuestionDto d { get; set; } = new();
}

public class SubQuestionDto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class Ex2Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class Ex3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class Sub3Dto
{
    public Ex1Sub3Dto Ex1 { get; set; } = new();
    public Ex2Sub3Dto Ex2 { get; set; } = new();
    public Ex3Sub3Dto Ex3 { get; set; } = new();
}

public class Ex1Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class Ex2Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

public class Ex3Sub3Dto
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}

