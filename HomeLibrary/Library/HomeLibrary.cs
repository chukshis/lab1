using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HomeLibrary.Library
{
    class HomeLibrary : IHomeLibrary
    {
        private List<Book> Books;

        public HomeLibrary()
        {
            this.Books = new List<Book>();
        }
        public void addBook(Book book) //Добавляем книгу
        {
            this.Books.Add(book);
        }

        public List<Book> getBooks()
        {
            return this.Books;
        }

        public void deleteBook(int index) // Удаляем книгу
        {
            this.Books.RemoveAt(index);
        }

        public List<Book> find(string query, Book.BookProperty property) // Поиск книги (1ый параметр - строка, второй - по какому признаку вып. поиск)
        {
            List<Book> result = new List<Book>();
            foreach (var book in this.Books)
            {
                switch (property)
                {
                    case Book.BookProperty.AUTHOR://Ищем по автору
                        if (book.Author.Name == query | book.Author.Surname == query) result.Add(book); //Добавляем в результат книгу, идём дальше
                        break;

                    case Book.BookProperty.TITLE: //Ищем по заголовку
                        if (book.Title == query) result.Add(book);
                        break;

                    case Book.BookProperty.YEAR: //Ищем по году
                        if (book.Year == query) result.Add(book);
                        break;
                }
                
            }
            return result;
        }

        public List<Book> sort(Book.BookProperty property)
        {
            switch (property)
            {
                case Book.BookProperty.AUTHOR:
                    this.Books = (List<Book>)(from b in Books // Сортировка с использованием LINQ
                                 orderby b.Author.Surname + " " + b.Author.Name
                                 select b).ToList<Book>();
                    break;

                case Book.BookProperty.TITLE:
                    this.Books = (from b in Books
                                orderby b.Title
                                select b).ToList<Book>();
                    break;

                case Book.BookProperty.YEAR:
                    this.Books = (List<Book>)(from b in Books
                                orderby b.Year
                                select b).ToList<Book>();
                    break;
            }
            return this.Books;
        }
    }
}
