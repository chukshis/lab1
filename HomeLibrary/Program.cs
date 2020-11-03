using HomeLibrary.Library;
using HomeLibrary;
using System;
using System.Collections.Generic;

namespace HomeLibrary
{
    class Program
    {
        private static Library.HomeLibrary library;
        static void Main(string[] args)
        {
            library = new Library.HomeLibrary();
            Console.WriteLine("Привет! Это домашняя библеотека. Выберите, пожалуйста пункт меню");
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("====================================");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Вывести список книг");
                Console.WriteLine("4. Отсортировать книги");
                Console.WriteLine("5. Найти книгу");
                Console.WriteLine("====================================");
                Console.WriteLine("");
                var key = Console.ReadLine();
                Console.Clear();
                dispatchKey(key);
            }
        }

        private static void dispatchKey(string key)
        {
            try
            {
                switch (Convert.ToInt32(key))
                {
                    case 1:
                        addBook();
                        break;
                    case 2:
                        deleteBook();
                        break;
                    case 3:
                        listBooks();
                        break;
                    case 4:
                        sortBooks();
                        break;
                    case 5:
                        findBook();
                        break;
                }
            } catch (FormatException)
            {
                Console.WriteLine("Неправильный формат ввода. Введите число");
            }
        }

        private static void findBook()
        {
            Console.Write("Строка для поиска: ");
            var query = Console.ReadLine();

            Console.WriteLine("1. Поиск по названию");
            Console.WriteLine("2. Поиск по автору");
            Console.WriteLine("3. Поиск по году");
            Console.Write("Введите число: ");
            var key = Console.ReadLine();
            List<Book> result = null;
            try
            {
                switch (Convert.ToInt32(key))
                {
                    case 1:
                        result = library.find(query, Book.BookProperty.TITLE);
                        break;
                    case 2:
                        result = library.find(query, Book.BookProperty.AUTHOR);
                        break;
                    case 3:
                        result = library.find(query, Book.BookProperty.YEAR);
                        break;
                }
                if (result.Count > 0)
                {
                    var counter = 0;
                    foreach (var b in result)
                    {
                        Console.WriteLine(counter + ". " + b.Title + " | " + b.Author.Surname + " " + b.Author.Name + " | " + b.Year);
                        counter++;
                    }
                } else
                {
                    Console.WriteLine("Ничего не найдено");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный формат ввода. Введите число");
            }
        }

        private static void sortBooks()
        {
            Console.WriteLine("1. Сортировка по названию");
            Console.WriteLine("2. Сортировка по автору");
            Console.WriteLine("3. Сортировка по году");
            Console.Write("Введите число: ");
            var key = Console.ReadLine();
            try
            {
                switch (Convert.ToInt32(key))
                {
                    case 1:
                        library.sort(Book.BookProperty.TITLE);
                        break;
                    case 2:
                        library.sort(Book.BookProperty.AUTHOR);
                        break;
                    case 3:
                        library.sort(Book.BookProperty.YEAR);
                        break;
                }
                listBooks();
            } catch (FormatException)
            {
                Console.WriteLine("Неправильный формат ввода. Введите число");
            }
        }
        private static void deleteBook()
        {
            listBooks();
            Console.WriteLine("");
            Console.Write("Введите номер книги для удаления: ");
            var key = Console.ReadLine();
            try
            {
                library.deleteBook(Convert.ToInt32(key));
                Console.WriteLine("Книга успешно удалена");
            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный формат ввода! Введите число");
            }
        }

        private static void listBooks()
        {
            Console.WriteLine("Список книг: ");
            var counter = 0;
            foreach (var b in library.getBooks())
            {
                Console.WriteLine(counter + ". "+b.Title + " | "+b.Author.Surname+" "+ b.Author.Name +" | "+b.Year);
                counter++;
            }
        }

        private static void addBook()
        {
            Console.Write("Название книги: ");
            var title = Console.ReadLine();
            Console.Write("Год выпуска: ");
            var year = Console.ReadLine();
            Console.Write("Фамилия автора: ");
            var surname = Console.ReadLine();
            Console.Write("Имя автора: ");
            var name = Console.ReadLine();

            var author = new Author() {
                Name = name,
                Surname = surname
            };
            var book = new Book()
            {
                Author = author,
                Title = title,
                Year = year
            };

            library.addBook(book);
            Console.Write("Книга успешно добавлена!");
        }
    }
}
