using BackEnd.DTOs;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BackEnd.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExamController : ControllerBase
{
    private readonly IMongoCollection<ExamDto> _examCollection;
    private readonly IMongoCollection<BsonDocument> _rawCollection;

    public ExamController(IMongoClient mongoClient, IConfiguration configuration)
    {
        var database = mongoClient.GetDatabase("db");
        _examCollection = database.GetCollection<ExamDto>("tests");
        _rawCollection = database.GetCollection<BsonDocument>("tests");
    }
    

    
    [HttpGet("debug/collections")]
    public async Task<ActionResult> GetCollections()
    {
        var database = _rawCollection.Database;
        var collections = await database.ListCollectionNamesAsync();
        var collectionList = await collections.ToListAsync();
        return Ok(new { database = "SmartHack2025", collections = collectionList });
    }
    
    [HttpGet]
    public async Task<ActionResult<List<ExamDto>>> GetAll()
    {
        var exams = await _examCollection.Find(_ => true).ToListAsync();
        return Ok(exams);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ExamDto>> GetById(string id)
    {
        var exam = await _examCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        if (exam == null)
        {
            return NotFound();
        }
        return Ok(exam);
    }
}

