using System;
using System.Collections.Generic;
using System.Text;

namespace HomeLibrary.Library
{
    interface IHomeLibrary //Интерфейс для библеотеки
    {
        void addBook(Book book);
        void deleteBook(int index);
        List<Book> find(string query, Book.BookProperty property);
        List<Book> sort(Book.BookProperty property);
        List<Book> getBooks();
    }
}
