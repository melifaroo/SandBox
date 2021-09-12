using Sandbox.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SandBox.Sandbox.Library.Services
{
    public interface ILibraryService
    {
        int DefaultBorrowingTerm { get; }

        List<object> BookList();
        List<object> Storage();

        List<object> Register();

        List<object> Active();

        List<object> Overdue();

        bool CheckAvailable(Book book);

        bool Borrow(Book book);

        bool Replenish(Book book);
    }
}
