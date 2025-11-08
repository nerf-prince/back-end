
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using app.Models;
    
    namespace app.Controllers;
    
    [ApiController]
    [Route("api/[controller]")]
    public class TestsController : ControllerBase
    {
        private static readonly List<TestDto> _store = new()
        {
            new TestDto {  }
        };
    
        [HttpGet]
        public ActionResult<IEnumerable<TestDto>> Get() => Ok(_store);
    
        [HttpGet("{id:int}")]
        public ActionResult<TestDto> Get(int id)
        {
            var item = _store.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    
        [HttpPost]
        public ActionResult<TestDto> Post(TestDto dto)
        {
            dto.Id = _store.Any() ? _store.Max(t => t.Id) + 1 : 1;
            _store.Add(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }
    
        [HttpPut("{id:int}")]
        public IActionResult Put(int id, TestDto dto)
        {
            var item = _store.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            item.Name = dto.Name;
            item.Description = dto.Description;
            return NoContent();
        }
    
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _store.FirstOrDefault(t => t.Id == id);
            if (item == null) return NotFound();
            _store.Remove(item);
            return NoContent();
        }
    }
    
    
    
    
