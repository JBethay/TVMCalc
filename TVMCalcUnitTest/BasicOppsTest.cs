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
        #region Two Input methods 
        [TestMethod]
        public void Add()
        {
            //Arrange, 
            double x = 4.55;
            double y = 4.5;
            //Act,
            var result = CalculateOpp.Calculate(x, y, addDel);
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
            var result = CalculateOpp.Calculate(x, y, subtractDel);
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
            var result = CalculateOpp.Calculate(x, y, multiplyDel);
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
            var result = CalculateOpp.Calculate(x, y, devideDel);
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
            var result = CalculateOpp.Calculate(x, y, powerDel);
            //Assert
            Assert.AreEqual(25, result);
        }
        #endregion

        #region One Input Methods  
        [TestMethod]
        public void Percentage()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateOpp.Calculate(x, percentDel);
            //Assert
            Assert.AreEqual(.25, result);
        }

        [TestMethod]
        public void SquareRoot()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateOpp.Calculate(x, sqrtDel);
            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Square()
        {
            //Arrange, 
            double x = 5;
            //Act,
            var result = CalculateOpp.Calculate(x, squareDel);
            //Assert
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void OneOver()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = CalculateOpp.Calculate(x, oneOverDel);
            //Assert
            Assert.AreEqual(0.04, result);
        }

        [TestMethod]
        public void NaturalLog()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(x, naturalLogDel),4);
            //Assert
            Assert.AreEqual(3.2189, result);
        }
        #endregion

        #region TVM Methods regular annuity

        [TestMethod]
        public void NCompute()
        {
            //Arrange, 
            double n = 0.00;
            double i = 10;
            double pv = -100;
            double pmt = -10;
            double fv = 200;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n,i,pv,pmt,fv, nDel),4);
            //Assert
            Assert.AreEqual(4.2542, result);
        }

         [TestMethod]
         public void ICompute()
         {
             //Arrange, 
             double n = 10;
             double i = 0;
             double pv = -100;
             double pmt = -10;
             double fv = 1000;
             //Act,
             var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, iDel), 4);
             //Assert
             Assert.AreEqual(21.7681, result);
         } 

        [TestMethod]
        public void PVCompute()
        {
            //Arrange, 
            double n = 5;
            double i = 10;
            double pv = 0;
            double pmt = -10;
            double fv = 200;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pvDel), 4);
            //Assert
            Assert.AreEqual(-86.2764, result);
        }

        [TestMethod]
        public void PMTCompute()
        {
            //Arrange, 
            double n = 10;
            double i = 10;
            double pv = 15;
            double pmt = 0;
            double fv = 100;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pmtDel), 4);
            //Assert
            Assert.AreEqual(-8.7157, result);
        }

        [TestMethod]
        public void FVCompute()
        {
            //Arrange, 
            double n = 5;
            double i = 10;
            double pv = -5;
            double pmt = -10;
            double fv = 0;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, fvDel), 4);
            //Assert
            Assert.AreEqual(69.1036, result);
        }
        #endregion

        #region TVM Methods annuity due
        [TestMethod] //X
        public void NAdCompute()
        {
            //Arrange, 
            double n = 0.00;
            double i = 10;
            double pv = -100;
            double pmt = -10;
            double fv = 500;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, nAdDel), 4);
            //Assert
            Assert.AreEqual(11.1882, result);
        }

        [TestMethod]
        public void IAdCompute()
        {
            //Arrange, 
            double n = 10;
            double i = 0;
            double pv = -100;
            double pmt = -10;
            double fv = 1000;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, iAdDel), 4);
            //Assert
            Assert.AreEqual(20.9629, result);
        }

        [TestMethod]
        public void PVAdCompute()
        {
            //Arrange, 
            double n = 5;
            double i = 10;
            double pv = 0;
            double pmt = -10;
            double fv = 200;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pvAdDel), 4);
            //Assert
            Assert.AreEqual(-82.4856, result);
        }

        [TestMethod] 
        public void PMTAdCompute()
        {
            //Arrange, 
            double n = 10;
            double i = 10;
            double pv = -15;
            double pmt = 0;
            double fv = 100;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pmtAdDel), 4);
            //Assert
            Assert.AreEqual(-3.4849, result);
        }

        [TestMethod]
        public void FVAdCompute()
        {
            //Arrange, 
            double n = 5;
            double i = 10;
            double pv = -5;
            double pmt = -10;
            double fv = 0;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, fvAdDel), 4);
            //Assert
            Assert.AreEqual(75.2087, result);
        }
        #endregion
    }
}
