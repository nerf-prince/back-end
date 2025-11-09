using BackEnd.DTOs;
using MongoDB.Driver;

namespace BackEnd.Collections;

public class SubmissionsCollection(IMongoClient mongoClient,
                                    string databaseName,
                                    string collectionName)
{
    private readonly IMongoCollection<SubmissionDto> _submissionCollection = mongoClient
        .GetDatabase(databaseName)
        .GetCollection<SubmissionDto>(collectionName);


    public async Task<List<SubmissionDto>> All()
    {
        var submissions = await _submissionCollection.Find(Builders<SubmissionDto>.Filter.Empty).ToListAsync();
        return submissions;
    }

    public async Task<SubmissionDto?> One(string id)
    {
        var submission = await _submissionCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        return submission;
    }

    public async Task<List<SubmissionDto>> ByUserId(string userId)
    {
        var submissions = await _submissionCollection.Find(x => x.UserId == userId).ToListAsync();
        return submissions;
    }

    public async Task<List<SubmissionDto>> ByTestId(string testId)
    {
        var submissions = await _submissionCollection.Find(x => x.TestId == testId).ToListAsync();
        return submissions;
    }

    public async Task<SubmissionDto> Create(SubmissionDto submission)
    {
        await _submissionCollection.InsertOneAsync(submission);
        return submission;
    }

    public async Task<bool> UpdateScore(string submissionId, string fieldPath, int score)
    {
        // Convertește path-ul de la format cu / la format cu . pentru MongoDB
        // ex: "Sub2/Ex2/Score" -> "Sub2.Ex2.Score" sau "Sub2/Ex1/a/Score" -> "Sub2.Ex1.a.Score"
        var mongoPath = fieldPath.Replace("/", ".");
        
        var filter = Builders<SubmissionDto>.Filter.Eq(x => x.Id, submissionId);
        var update = Builders<SubmissionDto>.Update.Set(mongoPath, score);
        
        var result = await _submissionCollection.UpdateOneAsync(filter, update);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }
}

