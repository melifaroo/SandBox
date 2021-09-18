using Microsoft.Data.SqlClient;
using Sandbox.Library.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Sandbox.Library.Services
{
    public class LibraryService : ILibraryService
    {
        readonly string connectionString = Startup._SandBoxDBConnectionString;

        private Func<IDbConnection> ConnectionFactory { get;  }

        public LibraryService()
        {
            ConnectionFactory = new Func<SqlConnection>(() => new SqlConnection(connectionString));
        }


        public LibraryService(Func<IDbConnection> factory)
        {
            ConnectionFactory = factory;
        }

        public int DefaultBorrowingTerm => 14;

        public List<object> BookList()
        {
            List<object> books = new List<object>();
            string sqlStatement =
                "SELECT " +
                    "dbo.books.BookId As BookId" +
                    ", Title" +
                    ", dbo.authors.FullName as Author " +
                "FROM dbo.books " +
                "LEFT JOIN dbo.authors ON dbo.books.AuthorId = dbo.authors.AuthorId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                books.Add(new
                                {
                                    BookId = (int)reader[i++],
                                    Title = (string)reader[i++],
                                    Author = (string)reader[i++],
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return books;
        }

        public List<object> Storage()
        {
            List<object> books = new List<object>();
            string sqlStatement =
                "SELECT " +
                    "dbo.books.BookId As BookId" +
                    ", Title" +
                    ", TotalAmount As Total" +
                    ", (select count(*) from dbo.borrowings where dbo.borrowings.BookId = dbo.books.BookId) As LendedAmount" +
                    ", dbo.authors.AuthorId as AuthorId " +
                    ", dbo.authors.FullName as Author " +
                "FROM dbo.books " +
                "LEFT JOIN dbo.authors ON dbo.books.AuthorId = dbo.authors.AuthorId ";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlStatement, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int i = 0;
                                books.Add(new
                                {
                                    BookId = (int)reader[i++],
                                    Title = (string)reader[i++],
                                    TotalAmount = (int)reader[i++],
                                    LendedAmount = (int)reader[i++],
                                    AuthorId = (int)reader[i++],
                                    Author = (string)reader[i++],
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return books;
        }

        public List<object> Register()
        {
            List<object> borrowings = new List<object>();
            string sqlStatement =
                "SELECT " +
                "BorrowingId" +
                ", BorrowingDate" +
                ", Term" +
                ", dbo.books.BookId as BookId" +
                ", dbo.books.Title as Book" +
                ", dbo.readers.ReaderId as ReaderId " +
                ", dbo.readers.FullName as Reader " +
                ", Closed" +
                ", ReturnDate" +
                " FROM dbo.borrowings " +
                "LEFT JOIN dbo.books ON dbo.borrowings.BookId = dbo.books.BookId " +
                "LEFT JOIN dbo.readers ON dbo.borrowings.ReaderId = dbo.readers.ReaderId";
            try
            {
                using IDbConnection connection  = ConnectionFactory.Invoke();   connection.Open();
                using IDbCommand command        = connection.CreateCommand();   command.CommandText = sqlStatement;
                using IDataReader datareader    = command.ExecuteReader();
                while (datareader.Read())
                {
                    borrowings.Add(new
                    {
                        BorrowingId =   datareader.GetInt32(    datareader.GetOrdinal("BorrowingId")    ),
                        Date =          datareader.GetDateTime( datareader.GetOrdinal("BorrowingDate")  ),
                        Term =          datareader.GetInt32(    datareader.GetOrdinal("Term")           ),
                        BookId =        datareader.GetInt32(    datareader.GetOrdinal("BookId")         ),
                        Book =          datareader.GetString(   datareader.GetOrdinal("Book")           ),
                        ReaderId =      datareader.GetInt32(    datareader.GetOrdinal("ReaderId")       ),
                        Reader =        datareader.GetString(   datareader.GetOrdinal("Reader")         ),
                        Closed =        datareader.GetBoolean(  datareader.GetOrdinal("Closed")         ),
                        ReturnDate =   (datareader.GetValue(    datareader.GetOrdinal("ReturnDate")     ) == DBNull.Value)
                                       ?(DateTime?)null
                                       :datareader.GetDateTime( datareader.GetOrdinal("ReturnDate")     ),
                    });
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            return borrowings;
        }

        public List<object> Active()
        {
            throw new NotImplementedException();
        }

        public List<object> Overdue()
        {
            throw new NotImplementedException();
        }

        public bool CheckAvailable(Book book)
        {
            string sqlStatement = "SELECT TotalAmount-(select count(*) from dbo.borrowings where dbo.borrowings.BookId = dbo.books.BookId) FROM dbo.books WHERE dbo.books.BookId = @Id";
            try
            {
                using SqlConnection connection = new(connectionString);
                connection.Open();
                using SqlCommand command = new(sqlStatement, connection);
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = book.BookId;
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

        public bool Borrow(Book book)
        {
            throw new NotImplementedException();
        }
        public bool Replenish(Book book)
        {
            throw new NotImplementedException();
        }

    }
}
