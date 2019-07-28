using System;
using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullnameTestValid()
        {
            // -- Arrange 
            //Customer customer = new Customer();
            //customer.FirstName = "Bilbo";
            //customer.LastName = "Baggins";
            //the below is same as above. 
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggins"
            };
            string expected = "Baggins, Bilbo";
            //-- Act 
            string actual = customer.FullName;
            //-- Assert 
            Assert.AreEqual(expected, actual);
        }
    }
}
