namespace app.Models;

public class Test
{
    // maps MongoDB `_id`
    public string Id { get; set; } = string.Empty;

    public Sub1 Sub1 { get; set; } = new();
    public Sub2 Sub2 { get; set; } = new();
    public Sub3 Sub3 { get; set; } = new();

    public string AnScolar { get; set; } = string.Empty;
    public string Sesiune { get; set; } = string.Empty;
}

public class Sub1
{
    public Sub1Ex Ex { get; set; } = new();
}

public class Sub1Ex
{
    public string Sentence { get; set; } = string.Empty;
    public int QuestionNumber { get; set; }
    public string Answer { get; set; } = string.Empty;
    public string Options { get; set; } = string.Empty;
}

public class Sub2
{
    public Sub2Ex1 Ex1 { get; set; } = new();

    // a, b, c, d objects with Sentence + Answer
    public Option A { get; set; } = new();
    public Option B { get; set; } = new();
    public Option C { get; set; } = new();
    public Option D { get; set; } = new();

    public Option Ex2 { get; set; } = new();
    public Option Ex3 { get; set; } = new();
}

public class Sub2Ex1
{
    public string Code { get; set; } = string.Empty;
    public string Sentence { get; set; } = string.Empty;
}

public class Sub3
{
    public Option Ex1 { get; set; } = new();
    public Option Ex2 { get; set; } = new();
    public Option Ex3 { get; set; } = new();
}

public class Option
{
    public string Sentence { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
}