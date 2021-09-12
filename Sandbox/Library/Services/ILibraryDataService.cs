using Sandbox.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Sandbox.Library.Services
{
    public interface ILibraryDataService
    {
        //Developing, randomly seed data
        void Seed();

        List<Book> Books();
        List<Reader> Readers();
        List<Author> Authors();
        List<Borrowing> Borrowings();

        Book AddBook(Book book);
        Reader AddReader(Reader reader);
        Author AddAuthor(Author author);
        Borrowing AddBorrowing(Borrowing borrowing);

        bool HasBook(Book book);
        bool HasReader(Reader reader);
        bool HasAuthor(Author author);
        bool HasBorrowing(Borrowing borrowing);

        Book GetBook(int Id);
        Reader GetReader(int Id);
        Author GetAuthor(int Id);
        Borrowing GetBorrowing(int Id);

    }
}
