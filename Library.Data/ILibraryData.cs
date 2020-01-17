using System;
using System.Collections.Generic;
using System.Text;
using Library.Core;
namespace Library.Data
{
    public interface ILibraryData
    {
        IEnumerable<Book> GetBooks(string name = null);
        Book GetBookById(int bookId);
        Book Add(Book book);
        Book Create(Book book);
        Book Update(Book book);
        int Commit();
    }
}
