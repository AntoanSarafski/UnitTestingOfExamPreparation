namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    public class Tests
    {
        private TextBook textBook;
        private string title = "1984";
        private string author = "George Orwell";
        private string category = "Disthopy";


        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(title, author, category);
        }

        [Test]
        public void TestTextbookConstructor_SetsValuesCorrectly()
        {
            Assert.AreEqual(textBook.Category, category);
            Assert.AreEqual(textBook.Author, author);
            Assert.AreEqual(textBook.Title, title);
        }
    }
}