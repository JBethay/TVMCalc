using Microsoft.VisualStudio.TestTools.UnitTesting;
using TVMCalc;
using TVMCalc.Operations.BasicOpps;
using static TVMCalc.Operations.BasicOpps.BasicOppsDels;

namespace TVMCalcUnitTest
{
    [TestClass]
    public class BasicOppsTest
    {
        [TestMethod]
        public void Add()
        {
            //Arrange, 
            double x = 4.55;
            double y = 4.5;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, addDel);
            //Assert
            Assert.AreEqual(9.05, result);
        }

        [TestMethod]
        public void Subtract()
        {
            //Arrange, 
            double x = 5;
            double y = 4.5;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, subtractDel);
            //Assert
            Assert.AreEqual(0.5, result);
        }

        [TestMethod]
        public void Multiply()
        {
            //Arrange, 
            double x = 5;
            double y = 4;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, multiplyDel);
            //Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Devide()
        {
            //Arrange, 
            double x = 25;
            double y = 5;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, devideDel);
            //Assert
            Assert.AreEqual(5, result);
        }
    }
}
