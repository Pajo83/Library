using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library.Core;

namespace Library.Data
{
    public class LibraryDataInMemory:ILibraryData
    {
        private List<Book> books;
        public LibraryDataInMemory()
        {

           books = new List<Book>
           {
                new Book
                {
                    Id=1,
                    AuthorName="Olivera Nikolova",
                    BookName = "Zoki Poki",
                    Categories = Categories.None

                },
                 new Book
                 {
                    Id=2,
                    AuthorName="",
                    BookName = "",
                    Categories = Categories.Comedy

                 },
                  new Book
                  {
                    Id=3,
                    AuthorName="Shekspir",
                    BookName = "Magbeth",
                    Categories = Categories.Drama

                  },
                  new Book
                  {
                    Id=4,
                    AuthorName="Tolkin",
                    BookName = "Hobbith",
                    Categories = Categories.Fantasy

                  },
            };
        }

        public int Commit()
        {
            return 0;
        }
        public IEnumerable<Book> GetBooks(string name = null)
        {
            return books.Where(b => string.IsNullOrEmpty(name) || b.AuthorName.ToLower().StartsWith(name.ToLower())).OrderBy(b => b.AuthorName);
        }

        public Book Add(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return book;

        }

        public Book Create(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return book; 
        }

        public Book Update(Book book)
        {
            var tempBooks = books.SingleOrDefault(b => b.Id == book.Id);
            if (tempBooks != null)
            {
                tempBooks.AuthorName = book.AuthorName;
                tempBooks.BookName = book.BookName;
                tempBooks.Categories = book.Categories;
            }
            return tempBooks;
        }

        public Book GetBookById(int bookId)
        {
            return books.SingleOrDefault(b => b.Id == bookId);
        }
    }
}
