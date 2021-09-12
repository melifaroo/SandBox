using Moq;
using NUnit.Framework;
using Sandbox.Library.Model;
using SandBox.Sandbox.Library.Controllers;
using SandBox.Sandbox.Library.Services;

namespace test
{
    public class LibraryControllerTest
    {
        LibraryController controller;
        Mock<ILibraryService> LibraryServiceMock;
        Mock<ILibraryDataService> LibraryDataServiceMock;
        Mock<Borrowing> borrowingMock;

        [SetUp]
        public void Setup()
        {
            borrowingMock = new Mock<Borrowing>();

            LibraryServiceMock = new Mock<ILibraryService>();
            LibraryDataServiceMock = new Mock<ILibraryDataService>();
            controller = new LibraryController(LibraryServiceMock.Object, LibraryDataServiceMock.Object);
        }

        [Test]
        public void SuccessfullyBorrowKnownReaderTest()
        {
            //// arrange
            LibraryServiceMock.Setup(p => p.CheckAvailable(It.IsAny<Book>())).Returns(true);
            LibraryDataServiceMock.Setup(p => p.HasReader(It.IsAny<Reader>())).Returns(true);
            //// act
            var result = controller.Borrow(borrowingMock.Object);
            //// assert
            LibraryDataServiceMock.Verify(p => p.AddReader(It.IsAny<Reader>()), Times.Never());
            LibraryDataServiceMock.Verify(p => p.AddBorrowing(borrowingMock.Object), Times.Once());
            Assert.AreEqual("succesfully borrowed", result);
        }
        [Test]
        public void SuccessfullyBorrowNewReaderTest()
        {
            //// arrange
            LibraryServiceMock.Setup(p => p.CheckAvailable(It.IsAny<Book>())).Returns(true);
            LibraryDataServiceMock.Setup(p => p.HasReader(It.IsAny<Reader>())).Returns(false);
            //// act
            var result = controller.Borrow(borrowingMock.Object);
            //// assert
            LibraryDataServiceMock.Verify(p => p.AddReader(It.IsAny<Reader>()), Times.Once());
            LibraryDataServiceMock.Verify(p => p.AddBorrowing(borrowingMock.Object), Times.Once());
            Assert.AreEqual("succesfully borrowed", result);
        }

        [Test]
        public void UnsuccessfullyBorrowAnyReaderTest()
        {
            //// arrange
            LibraryServiceMock.Setup(p => p.CheckAvailable(It.IsAny<Book>())).Returns(false);
            LibraryDataServiceMock.Setup(p => p.HasReader(It.IsAny<Reader>())).Returns(It.IsAny<bool>());
            //// act
            var result = controller.Borrow(borrowingMock.Object);
            //// assert
            LibraryDataServiceMock.Verify(p => p.AddReader(It.IsAny<Reader>()), Times.Never());
            LibraryDataServiceMock.Verify(p => p.AddBorrowing(borrowingMock.Object), Times.Never());
            Assert.AreEqual("not borrowed", result);
        }
    }
}