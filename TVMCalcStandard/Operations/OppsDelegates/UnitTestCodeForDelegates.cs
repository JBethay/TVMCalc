using System;
using System.Collections.Generic;
using System.Text;

namespace TVMCalc.Operations.OppsDelegates
{
    /*public class UnitTestCodeForDelegates
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
            var result = Math.Round(CalculateOpp.Calculate(x, naturalLogDel), 4);
            //Assert
            Assert.AreEqual(3.2189, result);
        }
        #endregion

        #region TVM Methods regular annuity Methods

        [TestMethod]
        public void NCompute()
        {
            //Arrange, 
            double n = 0.00;
            double i = 15;
            double pv = -250;
            double pmt = -15;
            double fv = 750;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, nDel), 4);
            //Assert
            Assert.AreEqual(6.3487, result);
        }
        [TestMethod]
        public void N2Compute()
        {
            //Arrange, 
            double n = 0.00;
            double i = 15;
            double pv = 200;
            double pmt = 15;
            double fv = -750;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, nDel), 4);
            //Assert
            Assert.AreEqual(7.4516, result);
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
        public void I2Compute()
        {
            //Arrange, 
            double n = 12;
            double i = 0;
            double pv = 140;
            double pmt = 50;
            double fv = -1000;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, iDel), 4);
            //Assert
            Assert.AreEqual(4.3512, result);
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
        public void PV2Compute()
        {
            //Arrange, 
            double n = 8;
            double i = 12;
            double pv = 0;
            double pmt = 10;
            double fv = -500;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pvDel), 4);
            //Assert
            Assert.AreEqual(152.2652, result);
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
        public void PMT2Compute()
        {
            //Arrange, 
            double n = 15;
            double i = 5;
            double pv = -30;
            double pmt = 0;
            double fv = 250;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pmtDel), 4);
            //Assert
            Assert.AreEqual(-8.6953, result);
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
        [TestMethod]
        public void FV2Compute()
        {
            //Arrange, 
            double n = 10;
            double i = 6;
            double pv = -25;
            double pmt = -50;
            double fv = 0;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, fvDel), 4);
            //Assert
            Assert.AreEqual(703.8109, result);
        }
        #endregion

        #region TVM Methods annuity due Methods
        [TestMethod]
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
        public void NAd2Compute()
        {
            //Arrange, 
            double n = 0.00;
            double i = 12;
            double pv = 200;
            double pmt = 5;
            double fv = -400;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, nAdDel), 4);
            //Assert
            Assert.AreEqual(5.2394, result);
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
        public void IAd2Compute()
        {
            //Arrange, 
            double n = 15;
            double i = 0;
            double pv = 100;
            double pmt = 50;
            double fv = -925;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, iAdDel), 4);
            //Assert
            Assert.AreEqual(0.9519, result);
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
        public void PVAd2Compute()
        {
            //Arrange, 
            double n = 5;
            double i = 10;
            double pv = 0;
            double pmt = 10;
            double fv = -350;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pvAdDel), 4);
            //Assert
            Assert.AreEqual(175.6238, result);
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
        public void PMTAd2Compute()
        {
            //Arrange, 
            double n = 10;
            double i = 15;
            double pv = 20;
            double pmt = 0;
            double fv = -346;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, pmtAdDel), 4);
            //Assert
            Assert.AreEqual(11.3532, result);
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
        [TestMethod]
        public void FVAd2Compute()
        {
            //Arrange, 
            double n = 65;
            double i = 8;
            double pv = 1000;
            double pmt = 100;
            double fv = 0;
            //Act,
            var result = Math.Round(CalculateOpp.Calculate(n, i, pv, pmt, fv, fvAdDel), 4);
            //Assert
            Assert.AreEqual(-348282.6396, result);
        }
        #endregion

        #region CF Methods 
        [TestMethod]
        public void CFNPVCompute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = -150;
            obj.I = 10;
            obj.CashFlows = new List<double>
            {
                10,20,5,3,250
            };

            obj.Frequency = new List<double>
            {
                5,2,3,5,1
            };

            //Act,
            var result = Math.Round(CalculateOpp.Calculate(obj, npvDel), 4);
            //Assert
            Assert.AreEqual(-25.3669, result);
        }
        [TestMethod]
        public void CFNPV2Compute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = 150;
            obj.I = 8.04;
            obj.CashFlows = new List<double>
            {
                10,15,-5,-33,50
            };

            obj.Frequency = new List<double>
            {
                5,2,3,5,1
            };

            //Act,
            var result = Math.Round(CalculateOpp.Calculate(obj, npvDel), 4);
            //Assert
            Assert.AreEqual(154.3204, result);
        }
        [TestMethod]
        public void CFNPV3Compute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = 0;
            obj.I = 10;
            obj.CashFlows = new List<double>
            {
                5,-10
            };

            obj.Frequency = new List<double>
            {
                1,1
            };

            //Act,
            var result = Math.Round(CalculateOpp.Calculate(obj, npvDel), 4);
            //Assert
            Assert.AreEqual(-3.7190, result);
        }

        [TestMethod]
        public void IRRCompute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = 0;
            obj.I = 10;
            obj.CashFlows = new List<double>
            {
                5555,-1000
            };
            obj.Frequency = new List<double>
            {
                2,15
            };

            //Act,
            var result = Math.Round(CfIRRMethod(obj), 4);
            //Assert
            Assert.AreEqual(3.7465, result);
        }
        [TestMethod]
        public void IRR2Compute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = 0;
            obj.CashFlows = new List<double>
            {
                500,-100,-300
            };
            obj.Frequency = new List<double>
            {
                3,2,1
            };

            //Act,
            var result = Math.Round(CfIRRMethod(obj), 4);
            //Assert
            Assert.AreEqual(-27.6896, result);
        }
        [TestMethod]
        public void IRR3Compute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = -155;
            obj.CashFlows = new List<double>
            {
                5,-10,5,1000
            };
            obj.Frequency = new List<double>
            {
                10,2,3,1
            };

            //Act,
            var result = Math.Round(CfIRRMethod(obj), 4);
            //Assert
            Assert.AreEqual(13.5688, result);
        }
        [TestMethod]
        public void IRR4Compute()
        {
            //Arrange, 
            var obj = new CfObject();
            obj.CF0 = -3500;
            obj.CashFlows = new List<double>
            {
                5,-10,5,2000
            };
            obj.Frequency = new List<double>
            {
                10,2,3,1
            };

            //Act,
            var result = Math.Round(CfIRRMethod(obj), 4);
            //Assert
            Assert.AreEqual(-3.3412, result);
        }
        #endregion
    } */
}
