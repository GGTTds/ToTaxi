using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToTaxi;

namespace ToTaxiTest
{
    [TestClass]

     public class TestSaveAndCreateAndUpdateUser
    {
        public static User UserTest;
        [ClassInitialize]
        public static void CreateAssert(TestContext testContext)
        {
            User NewUser = new User
            {
                Name = "Name",
                Fam = "Fam",
                Otc = "Otc",
                Email = "Email",
                LogininVx = "log",
                PasswordInVx = "pas",
                DateBird0 = DateTime.Now,
                Tel = "Tel"
            };
            UserTest = NewUser;
        }
        [TestMethod]
        public void SaveProfReturnTrue()
        {
            //Act
            SaveAndCreateAndUpdateUser _TestClass = new SaveAndCreateAndUpdateUser();
            bool IsTrueAddnewUser = _TestClass.AddNewPol(UserTest);
            //Assert
            Assert.IsTrue(IsTrueAddnewUser);
        }
        [TestMethod]
        public void UpdateThisPol()
        {
            //Arrange
            UserTest.Name = "NewName";
            //Act
            SaveAndCreateAndUpdateUser _TestClass = new SaveAndCreateAndUpdateUser();
            bool IsTrueUpdUser = _TestClass.UpdThisProf(UserTest);
            // Assert
            Assert.IsTrue(IsTrueUpdUser);
            
        }
        [ClassCleanup]
        public static void ThisDATADEl()
        {
            using ( TaxiInDronContext v = new TaxiInDronContext())
            {
                v.Users.Remove(UserTest);
                v.SaveChanges();
            }
        }
        

        
    }
}
