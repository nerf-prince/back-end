using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using app.Models;

namespace app.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestsController : ControllerBase
{
    // simple in-memory store using string ids (like MongoDB ObjectId)
    // start empty; POST will assign an id when needed
    private static readonly List<TestDto> _store = new();

    [HttpGet]
    public ActionResult<IEnumerable<TestDto>> Get() => Ok(_store);

    [HttpGet("{id}")]
    public ActionResult<TestDto> Get(string id)
    {
        var item = _store.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult<TestDto> Post(TestDto dto)
    {
        if (dto == null) return BadRequest();

        dto.Id = string.IsNullOrWhiteSpace(dto.Id) ? System.Guid.NewGuid().ToString("N") : dto.Id;
        _store.Add(dto);
        return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(string id, TestDto dto)
    {
        if (dto == null) return BadRequest();

        var item = _store.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();

        // update fields (replace nested objects as provided)
        item.Sub1 = dto.Sub1 ?? new Sub1Dto();
        item.Sub2 = dto.Sub2 ?? new Sub2Dto();
        item.Sub3 = dto.Sub3 ?? new Sub3Dto();
        item.AnScolar = dto.AnScolar ?? string.Empty;
        item.Sesiune = dto.Sesiune ?? string.Empty;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var item = _store.FirstOrDefault(t => t.Id == id);
        if (item == null) return NotFound();
        _store.Remove(item);
        return NoContent();
    }
}
