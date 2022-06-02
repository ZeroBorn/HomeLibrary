using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary
{
    class Library
    {
        
        public Library(string bookName, string author, int yearPublished)
        {
            BookName = bookName;
            Author = author;
            YearPublished = yearPublished;
        }

        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
    }
}
