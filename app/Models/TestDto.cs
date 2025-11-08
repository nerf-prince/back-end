namespace app.Models;

public class TestDto
{
    // maps MongoDB `_id`
    public string Id { get; set; } = string.Empty;

    public Sub1Dto Sub1 { get; set; } = new();
    public Sub2Dto Sub2 { get; set; } = new();
    public Sub3Dto Sub3 { get; set; } = new();

    public string AnScolar { get; set; } = string.Empty;
    public string Sesiune { get; set; } = string.Empty;
}