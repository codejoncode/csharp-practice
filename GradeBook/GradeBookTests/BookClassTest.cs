using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GradeBookTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddGradeTest()
        {
            var book = new Book();

            book.AddGrade(4.5);
            book.AddGrade(7.2);

            double expectedOne = 4.5;
            double expectedTwo = 7.2;

            double actualOne = book.AccessGrade(1);
            double actualTwo = book.AccessGrade(2);

            //Assert  
            Assert.AreEqual(expectedOne, actualOne);
            Assert.AreEqual(expectedTwo, expectedTwo);
        }
    }
}
