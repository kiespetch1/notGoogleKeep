using Notes.Models;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Services
{
    public static class NoteService
    {
        static List<Note> Notes { get; }
        static int nextId = 3;
        static NoteService()
        {
            Notes = new List<Note>
            {
                new Note { Id = 1, Content = "First note"},
                new Note { Id = 2, Content = "Second note"}
            };
        }

        public static List<Note> GetAll() => Notes;

        public static Note Get(int id) => Notes.FirstOrDefault(p => p.Id == id);

        public static void Add(Note note)
        {
            note.Id = nextId++;
            Notes.Add(note);
        }

        public static void Delete(int id)
        {
            var note = Get(id);
            if(note is null)
                return;

            Notes.Remove(note);
        }

        public static void Update(Note note)
        {
            var index = Notes.FindIndex(p => p.Id == note.Id);
            if(index == -1)
                return;

            Notes[index] = note;
        }
    }
}