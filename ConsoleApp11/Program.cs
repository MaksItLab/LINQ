using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{

    class TrolleybusRoute
    {
        public string StartStop { get; set; }
        public string EndStop { get; set; }
        public int TrolleybusesCount { get; set; }
        public int TravelTime { get; set; }
        public List<int> TrolleybusesNumbers { get; set; }

    }



    /// <summary>
    /// Книга
    /// </summary>
    class Book
    {
        /// <summary>
        /// Уникальный идентификатор
        /// </summary>
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishDate { get; set; }
        public string Publisher { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> listBook = new List<Book> 
            {
                new Book { Id = 1, Title = "Book1", Author = "Author1", Price = 111.34m, PublishDate = new DateTime(2024, 4, 9), Publisher="Publisher1"},
                new Book { Id = 2, Title = "Book2", Author = "Author2", Price = 983.16m, PublishDate = new DateTime(2023, 10, 24), Publisher="Publisher1"},
                new Book { Id = 3, Title = "Book3", Author = "Author3", Price = 544.16m, PublishDate = new DateTime(2022, 2, 15), Publisher="Publisher2"},
                new Book { Id = 4, Title = "Book4", Author = "Author1", Price = 544.17m, PublishDate = new DateTime(2020, 1, 6), Publisher="Publisher2"},
            };

            List<TrolleybusRoute> routes = new List<TrolleybusRoute>
            { 
                new TrolleybusRoute {StartStop = "Stop1", EndStop="Stop20",TrolleybusesCount = 5, TravelTime = 30, TrolleybusesNumbers = new List<int>{1,3,5,7,8} },
                new TrolleybusRoute {StartStop = "Stop2", EndStop="Stop10",TrolleybusesCount = 3, TravelTime = 25, TrolleybusesNumbers = new List<int>{2,4,6} },
            };

            //вывод всей информации
            Console.WriteLine("All books: ");
            foreach (var item in listBook)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.Author}, Publish date: {item.PublishDate}, Publisher: {item.Publisher}");
            }


            //вывод записей по автору
            string authorFilter = "Author1";
            var authorBook = listBook.Where(b => b.Author == authorFilter).ToList();
            Console.WriteLine($"Выборка данных по запросу {authorFilter}:");
            foreach (var item in authorBook)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.Author}, Publish date: {item.PublishDate}, Publisher: {item.Publisher}");
            }


            Console.WriteLine("Данные отсортированные по цене: ");
            var sortedBook = listBook.OrderByDescending(b => b.Price).ToList();
            foreach (var item in sortedBook)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.Author}, Price: {item.Price}, Publish date: {item.PublishDate}, Publisher: {item.Publisher}");
            }

            Console.WriteLine("Группировка по издательству: ");
            var groupedBook = listBook.GroupBy(item => item.Publisher)
                                      .Select(b => new { Publisher = b.Key, Books = b.ToList() });

            foreach (var item in groupedBook)
            {
                Console.WriteLine($"Publisher: {item.Publisher}");
                foreach (var book in item.Books)
                {
                    Console.WriteLine(book.Title);
                }
            }

            Console.WriteLine("Проекция на название и автора");

            var bookNames = listBook.Select(b => new { b.Title, b.Author }).ToList();

            foreach (var item in bookNames)
            {
                Console.WriteLine($"Title: {item.Title}, Author: {item.Author}");
            }

            Console.WriteLine("--------------------------------------------------------------");

            var filteredRoutes = routes.Where(item => item.TrolleybusesCount >= 3).OrderBy(b => b.TrolleybusesCount);

            foreach (var item in filteredRoutes)
            {
                Console.WriteLine(item.TrolleybusesCount);
            }
               
        }
    }
}
