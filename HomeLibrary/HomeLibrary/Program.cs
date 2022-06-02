using HomeLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            int active;
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Выбор действия:\n1:Добавление книги\n2:Просмотор книг\n3:Удаление книги\n4:Поиск книги\n5:Выход из программы");
                active = Convert.ToInt32(Console.ReadLine());
                switch (active)
                {
                    case 1:
                        {
                            DataBaseContext dataBaseContext = new DataBaseContext();
                            Console.Write("Ввод названия книги: ");
                            string bookName = Convert.ToString(Console.ReadLine());
                            Console.Write("Ввод автора книги: ");
                            string author = Convert.ToString(Console.ReadLine());
                            Console.Write("Ввод года публикации: ");
                            int yearPublished = Convert.ToInt32(Console.ReadLine());
                            var book = new Library(bookName.ToString(), author.ToString(), yearPublished);
                            dataBaseContext.Add(book);
                            dataBaseContext.SaveChanges();
                            break;
                        }
                    case 2:
                        {
                            DataBaseContext dataBaseContext = new DataBaseContext();
                            List<Library> sus;
                            using (DataBaseContext context = new DataBaseContext())
                            {
                                sus = context.Library.ToList();
                            }
                            foreach (Library item in sus)
                            {
                                Console.WriteLine(item.BookId + " " + item.BookName + " " + item.Author + " " + item.YearPublished);
                            }
                            break;
                        }
                    case 3:
                        {
                            DataBaseContext dataBaseContext = new DataBaseContext();
                            Console.Write("Введите ид книги, для её удаления: ");
                            int bookRemove = Convert.ToInt32(Console.ReadLine());
                                    var ordDetailQuery =
                                    from Library in dataBaseContext.Library
                                    where Library.BookId == bookRemove
                                    select Library;
                                foreach (var selectedDetail in ordDetailQuery)
                                {
                                    Console.WriteLine(selectedDetail.BookId);
                                    dataBaseContext.Library.Remove(selectedDetail);
                                }
                            dataBaseContext.SaveChanges();
                            break;
                        }
                    case 4:
                        {

                            DataBaseContext dataBaseContext = new DataBaseContext();
                            var bookFind = Console.ReadLine();
                            var ordDetailQuery =
                            from Library in dataBaseContext.Library
                            where Library.BookId ==  Convert.ToInt32(bookFind) || Library.Author== bookFind || Library.BookName == bookFind || Library.YearPublished ==Convert.ToInt32(bookFind)
                            select Library;
                            foreach (var item in ordDetailQuery)
                            {
                                Console.WriteLine(item.BookId + " " + item.BookName + " " + item.Author + " " + item.YearPublished);

                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Пок-Пок-Пока");
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                        }
                }
            }
        }

    }
}
