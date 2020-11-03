using System;
using System.Collections.Generic;
using System.Text;

namespace HomeLibrary.Library
{
    
    class Book
    {
        public enum BookProperty
        {
            TITLE,
            AUTHOR,
            YEAR
        }
        public string Title { get; set; } //Название книги
        public Author Author { get; set; } //Автор
        public string Year { get; set; } //Дата выхода
    }
}
