using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TVMCalc;
using TVMCalc.Operations.BasicOpps;
using static TVMCalc.Operations.BasicOpps.BasicOppsDels;

namespace TVMCalcUnitTest
{
    [TestClass]
    public class BasicOppsTest
    {
        // TWO INPUTS
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
            double x = -5;
            double y = -1;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, multiplyDel);
            //Assert
            Assert.AreEqual(5, result);
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

        [TestMethod]
        public void Exponent()
        {
            //Arrange, 
            double x = 5;
            double y = 2;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, y, powerDel);
            //Assert
            Assert.AreEqual(25, result);
        }

        //ONE INPUT
        [TestMethod]
        public void Percentage()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, percentDel);
            //Assert
            Assert.AreEqual(.25, result);
        }

        [TestMethod]
        public void SquareRoot()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, sqrtDel);
            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Square()
        {
            //Arrange, 
            double x = 5;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, squareDel);
            //Assert
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void OneOver()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateBasicOpps.Calculate(x, oneOverDel);
            //Assert
            Assert.AreEqual(0.04, result);
        }

        [TestMethod]
        public void NaturalLog()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = Math.Round(CalculateBasicOpps.Calculate(x, naturalLogDel),4);
            //Assert
            Assert.AreEqual(3.2189, result);
        }
    }
}
