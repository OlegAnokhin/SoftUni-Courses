namespace Book.Tests
{
    using System;

    using NUnit.Framework;
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ConstructorTestShouldWorkCorrect()
        {
            var book = new Book("bookName", "bookAuthor");
            Assert.IsNotNull(book);
            Assert.AreEqual(book.BookName, "bookName");
            Assert.AreEqual(book.Author, "bookAuthor");
        }
        [TestCase(null)]
        [TestCase("")]
        public void BookNameShouldThrouException(string bookName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book(bookName, "bookAuthor");
            }, $"Invalid {bookName}!");
        }
        [TestCase(null)]
        [TestCase("")]
        public void AuthorNameShouldThrouException(string authorName)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var book = new Book("bookName", authorName);
            }, $"Invalid {authorName}!");
        }
        [Test]
        public void TestFoofnoteCount()
        {
            var book = new Book("bookName", "bookAuthor");
            book.AddFootnote(5, "texttt");
            book.AddFootnote(10, "textttttt");
            Assert.AreEqual(2, book.FootnoteCount);
        }
        [Test]
        public void AddFootnoteMethodShouldThrowExceptionIfDublicate()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var book = new Book("bookName", "bookAuthor");
                book.AddFootnote(5, "texttt");
                book.AddFootnote(5, "texttt");
            }, "Footnote already exists!");
        }
        [Test]
        public void FindFootnoteMethodSholdReturnCorrect()
        {
            var book = new Book("bookName", "bookAuthor");
            book.AddFootnote(5, "texttt");
            var expected = "Footnote #5: texttt";
            var actual = book.FindFootnote(5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void FindFootnoteMethodShouldThrowExceptionIfNonExist()
        {
            var book = new Book("bookName", "bookAuthor");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.FindFootnote(2);
            }, "Footnote doesn't exists!");
        }
        [Test]
        public void AlterFootnoteMethodSholdReturnCorrect()
        {
            var book = new Book("bookName", "bookAuthor");
            book.AddFootnote(5, "texttt");
            book.AlterFootnote(5, "NewTexttt");
            var expected = "Footnote #5: NewTexttt";
            var actual = book.FindFootnote(5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AlterFootnoteMethodShouldThrowExceptionIfNonExist()
        {
            var book = new Book("bookName", "bookAuthor");
            Assert.Throws<InvalidOperationException>(() =>
            {
                book.AlterFootnote(2, "newtext");
            }, "Footnote does not exists!");
        }

    }
}