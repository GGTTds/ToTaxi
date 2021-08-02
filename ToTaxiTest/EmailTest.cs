using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using ToTaxi;

namespace ToTaxiTest
{
    [TestClass]
     public class EmailTest
    {
        [TestMethod]
        public void String_eml_returnTrue()
        {
            // Arrange 
            string TestEmal = "Email@gmail.com";
            //Act
            bool IsEmlTry = ToEml.IsValidEmail(TestEmal);
            //Assert
            Assert.IsTrue(IsEmlTry);
        }
    }
}
