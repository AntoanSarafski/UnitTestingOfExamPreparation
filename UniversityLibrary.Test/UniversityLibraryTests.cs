namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private TextBook textBook;
        private string title = "1984";
        private string author = "George Orwell";
        private string category = "Disthopy";

        private UniversityLibrary library;

        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title, author, category);
            library = new UniversityLibrary();
        }

        [Test]
        public void TestTextbookConstructor_SetsValuesCorrectly()
        {
            Assert.AreEqual(textBook.Category, category);
            Assert.AreEqual(textBook.Author, author);
            Assert.AreEqual(textBook.Title, title);
        }

        [Test]
        public void UniLibraryIsEmptyWhenNew()
        {
            Assert.AreEqual(library.Catalogue.Count, 0);
        }


        [Test]
        public void ReturnAndLoanThrowErrorWhenTextBookNotFound()
        {
            Assert.Throws<System.NullReferenceException>(() =>
            {
                library.LoanTextBook(88, "Empty");

            });
            Assert.Throws<System.NullReferenceException>(() =>
            {
                library.ReturnTextBook(88);

            });

        }

        [Test]
        public void AddTextBookCounterWorksCorrectly()
        {
            for (int i = 0; i < 10; i++)
            {
                library.AddTextBookToLibrary(textBook);
            }
            string result = library.AddTextBookToLibrary(textBook);
            Assert.AreEqual(11, textBook.InventoryNumber);
        }


        [Test]
        public void AddTextBookWorksCorrectly()
        {
            string result = library.AddTextBookToLibrary(textBook);
            
            Assert.AreEqual(1, textBook.InventoryNumber);
            Assert.AreEqual(1, library.Catalogue.Count);
            Assert.AreEqual(title, library.Catalogue[0].Title);
            Assert.AreEqual(result, "Book: 1984 - 1\r\nCategory: Disthopy\r\nAuthor: George Orwell"); 
        }

        [Test]  
        public void LoanTextBookTests()
        {
            library.AddTextBookToLibrary(textBook);
            textBook.InventoryNumber = 1;
            string result = library.LoanTextBook(1, "Ady");

            Assert.AreEqual(textBook.Holder, "Ady");
            Assert.AreEqual(result, $"{textBook.Title} loaned to Ady.");

            result = library.LoanTextBook(1, "Ady");
            Assert.AreEqual(result, $"Ady still hasn't returned {textBook.Title}!");
        }

        [Test]  
        public void ReturnInventoryBookTests()
        {

            library.AddTextBookToLibrary(textBook);
            string result = library.LoanTextBook(1, "Ady");

            result = library.ReturnTextBook(1);
            

            Assert.AreEqual(textBook.Holder, string.Empty);
            Assert.AreEqual(result, $"{textBook.Title} is returned to the library.");
        }
    }
}