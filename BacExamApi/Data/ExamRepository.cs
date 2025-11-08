using BacExamApi.Models;

namespace BacExamApi.Data;

/// <summary>
/// In-memory repository for exam questions
/// This simulates a database for demonstration purposes
/// </summary>
public class ExamRepository
{
    private static readonly List<ExamQuestion> _questions = new();
    
    static ExamRepository()
    {
        // Seed with sample Romanian BACALAUREAT programming questions
        SeedData();
    }
    
    public List<ExamQuestion> GetAll()
    {
        return _questions;
    }
    
    public ExamQuestion? GetById(int id)
    {
        return _questions.FirstOrDefault(q => q.Id == id);
    }
    
    public List<ExamQuestion> GetByDifficulty(string difficulty)
    {
        return _questions.Where(q => q.Difficulty.Equals(difficulty, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public List<ExamQuestion> GetBySubject(string subject)
    {
        return _questions.Where(q => q.Subject.Equals(subject, StringComparison.OrdinalIgnoreCase)).ToList();
    }
    
    public List<ExamQuestion> GetByYear(int year)
    {
        return _questions.Where(q => q.Year == year).ToList();
    }
    
    public void Add(ExamQuestion question)
    {
        question.Id = _questions.Any() ? _questions.Max(q => q.Id) + 1 : 1;
        _questions.Add(question);
    }
    
    private static void SeedData()
    {
        _questions.AddRange(new[]
        {
            new ExamQuestion
            {
                Id = 1,
                Title = "Suma elementelor pare dintr-un vector",
                Description = "Scrieți un program care citește n numere întregi dintr-un vector și calculează suma elementelor pare.",
                Difficulty = "Easy",
                Subject = "Arrays",
                Year = 2023,
                ExampleInput = "5\n2 3 4 5 6",
                ExampleOutput = "12",
                Constraints = "1 ≤ n ≤ 1000, -1000 ≤ elementi ≤ 1000",
                Hints = new List<Hint>
                {
                    new Hint { Id = 1, Content = "Iterați prin toate elementele vectorului", Order = 1, Type = "Approach", ExamQuestionId = 1 },
                    new Hint { Id = 2, Content = "Verificați dacă un element este par folosind operatorul modulo: element % 2 == 0", Order = 2, Type = "Implementation", ExamQuestionId = 1 },
                    new Hint { Id = 3, Content = "Folosiți o variabilă pentru a acumula suma", Order = 3, Type = "Implementation", ExamQuestionId = 1 }
                }
            },
            new ExamQuestion
            {
                Id = 2,
                Title = "Număr prim",
                Description = "Scrieți un program care verifică dacă un număr n este prim. Un număr prim este un număr natural mai mare ca 1 care nu are alți divizori decât 1 și el însuși.",
                Difficulty = "Medium",
                Subject = "Algorithms",
                Year = 2023,
                ExampleInput = "17",
                ExampleOutput = "DA",
                Constraints = "2 ≤ n ≤ 1,000,000",
                Hints = new List<Hint>
                {
                    new Hint { Id = 4, Content = "Un număr este prim dacă nu are divizori între 2 și √n", Order = 1, Type = "Algorithm", ExamQuestionId = 2 },
                    new Hint { Id = 5, Content = "Puteți optimiza verificând doar până la rădăcina pătrată a numărului", Order = 2, Type = "Optimization", ExamQuestionId = 2 },
                    new Hint { Id = 6, Content = "Tratați cazurile speciale: 2 este prim, numerele pare (mai mari ca 2) nu sunt prime", Order = 3, Type = "Implementation", ExamQuestionId = 2 }
                }
            },
            new ExamQuestion
            {
                Id = 3,
                Title = "Sortare vector",
                Description = "Scrieți un program care sortează un vector de n numere întregi în ordine crescătoare.",
                Difficulty = "Medium",
                Subject = "Sorting",
                Year = 2022,
                ExampleInput = "5\n5 2 8 1 9",
                ExampleOutput = "1 2 5 8 9",
                Constraints = "1 ≤ n ≤ 10,000",
                Hints = new List<Hint>
                {
                    new Hint { Id = 7, Content = "Puteți folosi algoritmul Bubble Sort pentru o soluție simplă", Order = 1, Type = "Algorithm", ExamQuestionId = 3 },
                    new Hint { Id = 8, Content = "Sau puteți folosi funcția sort() din biblioteca standard", Order = 2, Type = "Implementation", ExamQuestionId = 3 },
                    new Hint { Id = 9, Content = "Pentru Bubble Sort: comparați perechi consecutive și faceți swap dacă sunt în ordine greșită", Order = 3, Type = "Implementation", ExamQuestionId = 3 }
                }
            },
            new ExamQuestion
            {
                Id = 4,
                Title = "Inversarea unui număr",
                Description = "Scrieți un program care citește un număr întreg pozitiv n și afișează inversul său (cifrele în ordine inversă).",
                Difficulty = "Easy",
                Subject = "Numbers",
                Year = 2024,
                ExampleInput = "12345",
                ExampleOutput = "54321",
                Constraints = "0 ≤ n ≤ 1,000,000,000",
                Hints = new List<Hint>
                {
                    new Hint { Id = 10, Content = "Extrageți cifrele numărului una câte una folosind operatorul modulo (n % 10)", Order = 1, Type = "Approach", ExamQuestionId = 4 },
                    new Hint { Id = 11, Content = "Construiți numărul inversat înmulțind cu 10 și adăugând fiecare cifră", Order = 2, Type = "Implementation", ExamQuestionId = 4 },
                    new Hint { Id = 12, Content = "Împărțiți numărul original la 10 pentru a elimina ultima cifră", Order = 3, Type = "Implementation", ExamQuestionId = 4 }
                }
            }
        });
    }
}
