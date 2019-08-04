using GradeBook;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class BookstatTest
    {
        [Fact]
        public void ComputeAverageTest()
        {
            // arrange 
            Book book = new Book();
            //Act 
            book.AddGrade(5.6);
            book.AddGrade(6.2);
            book.AddGrade(7.5);

            var expected = 6.43;
            var actual = book.ComputeAverage();
            //Assert 
            Assert.Equal(expected, actual);
        }
    }
}
