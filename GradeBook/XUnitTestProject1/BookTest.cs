using GradeBook;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class BookTest
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
            // act 
            var expected = 6.43;
            var actual = book.ComputeAverage();
            //Assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ComputeAverageTestAgainstZeroLengthListTest()
        {
            //arrange 
            Book book = new Book();
            //act
            var expected = 0.0;
            var actual = book.ComputeAverage();
            //Assert 
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShowStaticsTest()
        {
            // arrange 
            Book book = new Book();
            //Act 
            book.AddGrade(5.6);
            book.AddGrade(6.2);
            book.AddGrade(7.5);

            var expected = new double[] { 5.6, 7.5, 6.43 };
            var actual = book.ShowStatistics();
            //var minimum = actual[0];
            //var maximum = actual[1];
            //var average = actual[2];
            //Assert 
            //Assert.Equal(expected, actual);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShowStaticsAgainstZeroLengthListTest()
        {
            //arrange 
            Book book = new Book();
            //act
            var expected = new double[] { 0, 0,0};
            var actual = book.ShowStatistics();
            //Assert 
            Assert.Equal(expected, actual);
        }
    }
}
