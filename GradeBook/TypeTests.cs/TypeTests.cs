using GradeBook;
using System;
using Xunit;

namespace TypeTests.cs
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
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
        public void Test2()
        {
            //arrange 
            //act 
            //assert 

        }
    }
}
