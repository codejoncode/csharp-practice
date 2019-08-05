using GradeBook;
using System;
using Xunit;

namespace TypeTests.cs
{
    public class UnitTest1
    {
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act 
            var book1Name = "Book 1";
            var book2Name = "Book 2";
            //assert 
            Assert.Equal(book1Name, book1.Name);
            Assert.Equal(book2Name, book2.Name);

        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));//same as Assert.Same
            //act 
            //assert 

        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            book1.UpdateName("New Name");
            //act 
            var expected = "New Name";
            //assert 
            Assert.Equal(expected, book1.Name);

        }

        private void SetName(Book book1, string name)
        {
            book1.UpdateName(name);
        }

        [Fact]
        public void Test1()
        {
            //arrange 
            //act 
            //assert 

        }
    }
}
