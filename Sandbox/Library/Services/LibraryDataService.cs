using Microsoft.Data.SqlClient;
using Sandbox.Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Sandbox.Library.Services
{
    public class LibraryDataService : ILibraryDataService
    {
        readonly string connectionString = Startup._SandBoxDBConnectionString;

        public Author AddAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public Book AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public Borrowing AddBorrowing(Borrowing borrowing)
        {
            string sqlStatement = "INSERT INTO dbo.borrowings   ( BookId,  ReaderId,  BorrowingDate,  Term) " +
                                                        "VALUES (@BookId, @ReaderId, @BorrowingDate, @Term); " +
                "SELECT SCOPE_IDENTITY()";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                command.Parameters.Add("@BookId", SqlDbType.Int).Value = borrowing.Book.BookId;
                command.Parameters.Add("@ReaderId", SqlDbType.Int).Value = borrowing.Reader.ReaderId;
                command.Parameters.Add("@BorrowingDate", SqlDbType.DateTime).Value = borrowing.BorrowingDate;
                command.Parameters.Add("@Term", SqlDbType.Int).Value = borrowing.Term;
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    borrowing.BorrowingId = (int)datareader[0];
                    return borrowing;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return borrowing;
        }

        public Reader AddReader(Reader reader)
        {
            string sqlStatement = "INSERT INTO dbo.readers (FullName) VALUES (@FullName); SELECT SCOPE_IDENTITY()";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                command.Parameters.Add("@FullName", SqlDbType.Int).Value = reader.FullName;
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    reader.ReaderId = (int)datareader[0];
                    return reader;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return reader;
        }

        public List<Author> Authors()
        {
            List<Author> authors = new List<Author>();
            string sqlStatement = "SELECT AuthorId, FullName FROM dbo.authors";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand(sqlStatement, connection);
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    int i = 0;
                    authors.Add(new Author
                    {
                        AuthorId = (int)datareader[i++],
                        FullName = (string)datareader[i++],
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return authors;
        }

        public List<Book> Books()
        {
            List<Book> books = new List<Book>();
            string sqlStatement =
                "SELECT " +
                    "dbo.books.BookId As BookId" +
                    ", Title" +
                    ", TotalAmount As Total" +
                    ", dbo.authors.AuthorId as AuthorId" +
                    ", dbo.authors.FullName as Author" +
                "FROM dbo.books " +
                "LEFT JOIN dbo.authors ON dbo.books.AuthorId = dbo.authors.AuthorId ";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    int i = 0;
                    books.Add(new Book
                    {
                        BookId = (int)datareader[i++],
                        Title = (string)datareader[i++],
                        TotalAmount = (int)datareader[i++],
                        Author = new Author
                        {
                            AuthorId = (int)datareader[i++],
                            FullName = (string)datareader[i++],
                        }
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return books;
        }

        public List<Borrowing> Borrowings()
        {
            List<Borrowing> borrowings = new List<Borrowing>();
            string sqlStatement =
                "SELECT " +
                "BorrowingId" +
                ", BorrowingDate" +
                ", ReturnDate" +
                ", Term" +
                ", Closed" +
                ", dbo.borrowings.BookId as BookId" +
                ", dbo.books.Title as BookTitle" +
                ", dbo.books.TotalAmount as TotalAmount" +
                ", dbo.books.AuthorId as AuthorId" +
                ", dbo.authors.FullName as AuthorName" +
                ", dbo.borrowings.ReaderId as ReaderId" +
                ", dbo.readers.FullName as ReaderName " +
                "FROM dbo.borrowings " +
                "LEFT JOIN dbo.books ON dbo.borrowings.BookId = dbo.books.BookId" +
                "LEFT JOIN dbo.authors ON dbo.books.AuthorId = dbo.authors.AuthorId" +
                "LEFT JOIN dbo.readers ON dbo.borrowings.ReaderId = dbo.readers.ReaderId";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    int i = 0;
                    borrowings.Add(new Borrowing
                    {
                        BorrowingId = (int)datareader[i++],
                        BorrowingDate = (DateTime)datareader[i++],
                        ReturnDate = (Nullable<DateTime>)datareader[i++],
                        Term = (int)datareader[i++],
                        Closed = (bool)datareader[i++],
                        Book = new Book
                        {
                            BookId = (int)datareader[i++],
                            Title = (string)datareader[i++],
                            TotalAmount = (int)datareader[i++],
                            Author = new Author 
                            { 
                                AuthorId = (int)datareader[i++],
                                FullName = (string)datareader[i++],                                
                            }
                        },
                        Reader = new Reader
                        {
                            ReaderId = (int)datareader[i++],
                            FullName = (string)datareader[i++],    
                        },
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return borrowings;
        }

        public Author GetAuthor(int Id)
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int Id)
        {
            throw new NotImplementedException();
        }

        public Borrowing GetBorrowing(int Id)
        {
            throw new NotImplementedException();
        }

        public Reader GetReader(int Id)
        {
            throw new NotImplementedException();
        }

        public bool HasAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public bool HasBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool HasBorrowing(Borrowing borrowing)
        {
            throw new NotImplementedException();
        }

        public bool HasReader(Reader reader)
        {
            string sqlStatement = "SELECT COUNT(1) FROM dbo.readers WHERE ReaderId = @Id";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = reader.ReaderId;
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    return (int)datareader[0] > 0;
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return false;
        }

        public List<Reader> Readers()
        {
            List<Reader> readers = new List<Reader>();
            string sqlStatement = "SELECT ReaderId, FullName FROM dbo.readers";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new SqlCommand(sqlStatement, connection);
                using SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    int i = 0;
                    readers.Add(new Reader
                    {
                        ReaderId = (int)datareader[i++],
                        FullName = (string)datareader[i++],
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return readers;
        }

        public void Seed()
        {
            throw new NotImplementedException();
        }
    }
}
