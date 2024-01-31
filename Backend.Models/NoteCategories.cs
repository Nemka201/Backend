using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class NoteCategory
    {
        public int Id { get; set; }
        public int NoteId { get; set; } 
        public int CategoryId { get; set; } 
        public Note Note { get; set; } 
        public Category Category { get; set; } 
    }

}
