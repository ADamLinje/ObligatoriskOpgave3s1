using ObligatoriskOpgave3s1;
namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidateTitleTest()
        {
            Book book = new Book() { Id = 1, Title = "Hamlet", Price = 100 };
            book.ValidateTitle();
            Assert.AreEqual(book.Title, "Hamlet");
            Assert.AreNotEqual(book.Title, "Hamle");

            Book shortNameBook = new Book() { Id = 2, Title = "H", Price = 100 };
            Assert.ThrowsException<ArgumentException>(
                () => shortNameBook.ValidateTitle());

            Book nullNameBook = new Book() { Id = 3, Price= 100 };
            Assert.ThrowsException<ArgumentNullException>(
                () => nullNameBook.ValidateTitle());
        }
        [TestMethod]
        public void ValidatePriceTest()
        {
            Book book = new Book() { Id = 1, Title = "Hamlet", Price = 1200 };
            book.ValidatePrice();
            Assert.AreEqual(book.Price, 1200);
            Assert.AreNotEqual(book.Price, 150);

            Book noPriceBook = new Book() { Id = 2, Title = "Hamlet", Price = 0 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => noPriceBook.ValidatePrice());
        }
        [TestMethod]
        public void ValidateToString()
        {
            Book book = new Book() { Id = 1, Title = "Hamlet", Price = 100 };
            book.ToString();
        }
        [TestMethod]
        public void BookRepositoryAddTest()
        {
            Book book = new Book() { Id = 1, Title = "Hamlet", Price= 100 };
            BookRepository bookRepository = new BookRepository();
            bookRepository.Add(book);
            List<Book> bookList = bookRepository.Get();
            Assert.AreEqual(6, bookList.Count);
        }
        [TestMethod]
        public void BookRepositoryGetByIdTest()
        {
            BookRepository bookRepository = new BookRepository();
            Book? book = bookRepository.GetByID(1);
            Assert.IsNotNull(book);
            Assert.AreEqual(book.Id, 1);
            Assert.AreEqual(book.Title, "Harry Potter");
            Book? book1 = bookRepository.GetByID(15);
            Assert.IsNull(book1);
        }
        [TestMethod]
        public void BookRepositoryDeleteTest()
        {
            BookRepository bookRepository = new BookRepository();
            Book? book = bookRepository.Delete(5);
            Assert.IsNotNull(book);
            Book? book2 = bookRepository.Delete(15);
            Assert.IsNull(book2);           
        }
    }
}