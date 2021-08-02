using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToTaxi;
using System.Text;
namespace ToTaxiTest
{
    [TestClass]
    public class ProfTest
    {
        [TestMethod]
        public void In_6CharAndlowerAndupped_TrueReturn()
        {
            // Arrange
            string ValidPasw = "SDFF16xs";
            int exp = 0;
            // Act
            StringBuilder fd = PasEnb.PasTry(ValidPasw);
            // Assert
            Assert.AreEqual(exp,fd.Length);
        }
    }
}
