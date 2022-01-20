using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Notes.Models;
using Notes.Services;

namespace Notes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        public NoteController()
        {
        }

        [HttpGet]
        public ActionResult<List<Note>> GetAll() =>
            NoteService.GetAll();

        [HttpGet("{id}")]
public ActionResult<Note> Get(int id)
{
    var note = NoteService.Get(id);

    if(note == null)
        return NotFound();

    return note;
}

        [HttpPost]
public IActionResult Create(Note note)
{            
    NoteService.Add(note);
    return CreatedAtAction(nameof(Create), new { id = note.Id }, note);
}

        [HttpPut("{id}")]
public IActionResult Update(int id, Note note)
{
    if (id != note.Id)
        return BadRequest();

    var existingNote = NoteService.Get(id);
    if(existingNote is null)
        return NotFound();

    NoteService.Update(note);           

    return NoContent();
}

        [HttpDelete("{id}")]
public IActionResult Delete(int id)
{
    var note = NoteService.Get(id);

    if (note is null)
        return NotFound();

    NoteService.Delete(id);

    return NoContent();
}
    }
}