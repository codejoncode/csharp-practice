using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBookTests
{
    [TestClass]
    public class BookTests
    {
        [TestMethod]
        public void AddGradeTest()
        {
            // Arrange 
            //Book book = new Book();

            // Act 
            //book.AddGrade(4.5);
            //book.AddGrade(7.2);

            //double expectedOne = 4.5;
            //double expectedTwo = 7.2;

            //double actualOne = book.AccessGrade(1);
            //double actualTwo = book.AccessGrade(2);

            //Assert  
            //Assert.AreEqual(expectedOne, actualOne);
            //Assert.AreEqual(expectedTwo, expectedTwo);
        }

        [TestMethod]
        public void ComputeAverageWithGradesTest()
        {
            // Arrange 

            //Book book = new Book();
            //var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1, 56.1 };
            //foreach (var grade in grades)
            //{
            //    book.AddGrade(grade);
            //}
            //// Act 
            //double actual = book.ComputeAverage();
            //double expected = 17.9;

            ////assert 

            //Assert.AreEqual(actual, expected);

        }

        [TestMethod]
        public void ComputeAverageZeroGradesTest()
        {
            // Arrange 
            //Book book = new Book();
            //Act 

            //double actual = book.ComputeAverage();
            //double expected = 0.0;

            ////Assert 
            //Assert.AreEqual(actual, expected);
        }
    }
}
