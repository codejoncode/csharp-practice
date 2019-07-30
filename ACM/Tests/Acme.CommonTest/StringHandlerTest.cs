using System;
using Acme.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacsTestValid()
        {
            // Arrange 
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";

            // Act 
            var actual = source.InsertSpaces();

            // Assert 
            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            //Arrange 
            var source = "Sonic Screwdriver";
            var expected = "Sonic Screwdriver";

            // Act 
            var actual = source.InsertSpaces();

            // Assert 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllUpperCaseLetters()
        {
            //naturally don't want to space out all upper case letters probably just want to keep it as is 
            //Arrange 
            var source = "SONICSCREWDRIVER";
            var expected = "SONICSCREWDRIVER";
            
            // Act 

            var actual = source.InsertSpaces();

            // Assert 

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AllUppserCaseLettersWithSpaces ()
        {
            //Arrange 
            var source = "SONIC SCREWDRIVER";
            var expected = "SONIC SCREWDRIVER";
            
            // Act 

            var actual = source.InsertSpaces();

            // Assert 

            Assert.AreEqual(expected, actual);
        }
    }

    
}
