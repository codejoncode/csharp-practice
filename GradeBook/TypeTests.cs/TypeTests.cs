using GradeBook;
using System;
using Xunit;

namespace TypeTests.cs
{
   
    public class TypeTests
    {

        public delegate string WriteLogDelegate(string logMessage);
        /// <summary>
        /// This will work with delegates
        /// </summary>
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            //arrange
            WriteLogDelegate log;

            log = new WriteLogDelegate(ReturnMessage);

            //act
            var result = log("Hello!");
            //assert
            Assert.Equal("Hello!", result);
        }

        string ReturnMessage(string message)
        {
            return message; 
        }

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
        public void CSharpIsPassByValue()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            //act 
            GetBookSetName(book1, "New Name");// passing by value
            //assert 
            Assert.NotEqual("New Name", book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }
        private void GetBookSetName(ref Book book, string name)
        {
            book = new Book(name);
        }
        private void GetBookSetName(out Object book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void  CSharpCanPassByReference()
        {
            //arrange 
            var book1 = GetBook("Book 1");
            //act 
            GetBookSetName(ref book1, "New Name");
            //GetBookSetName(out book1, "New Name");
            //assert 
            Assert.Equal("New Name", book1.Name);

        }
        [Fact]
        public void CSharpCanPassByValue()
        {
            //arrange 
            var x = GetInt();
            //act 
            //assert 
            Assert.Equal(3, x);
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            //arrange 
            var x = GetInt();
            //act 
            SetInt(x);
            //assert 
            Assert.NotEqual(42, x);
            Assert.Equal(3, x);
            SetInt(ref x);
            Assert.Equal(42, x);

        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }
       

        [Fact]
        public void StringsBehaveLikeValuetypes()
        {
            //arrange 
            string name = "Scott";
            //act 
            string upper = MakeUppercase(name);
            //assert 
            Assert.NotEqual("SCOTT", name);
            Assert.Equal("SCOTT", upper);
            MakeUppercase(ref name);
            Assert.Equal("SCOTT", name);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        private void MakeUppercase(ref string parameter)
        {
            parameter = parameter.ToUpper();
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
