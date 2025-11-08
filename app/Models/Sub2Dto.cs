namespace app.Models;

public class Sub2Dto
{
    public Sub2Ex1Dto Ex1 { get; set; } = new();

    // a, b, c, d objects with Sentence + Answer
    public OptionDto A { get; set; } = new();
    public OptionDto B { get; set; } = new();
    public OptionDto C { get; set; } = new();
    public OptionDto D { get; set; } = new();

    public OptionDto Ex2 { get; set; } = new();
    public OptionDto Ex3 { get; set; } = new();
}