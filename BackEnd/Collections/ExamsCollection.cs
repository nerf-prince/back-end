using BackEnd.DTOs;
using MongoDB.Driver;

namespace BackEnd.Collections;

public class ExamsCollection(IMongoClient mongoClient,
                             string databaseName,
                             string collectionName)
{
    private readonly IMongoCollection<ExamDto> _examCollection = mongoClient
        .GetDatabase(databaseName)
        .GetCollection<ExamDto>(collectionName);


    public async Task<List<ExamDto>> All()
    {
        var exams = await _examCollection.Find(Builders<ExamDto>.Filter.Empty).ToListAsync();
        return exams;
    }

    public async Task<ExamDto?> One(string id)
    {
        var exam = await _examCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        return exam;
    }
}

