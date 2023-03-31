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
        
    }
}