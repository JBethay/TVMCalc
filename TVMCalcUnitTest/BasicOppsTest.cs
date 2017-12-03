using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TVMCalc.Operations.BasicOpps;
using static TVMCalc.Operations.OppsDelegates.BasicOppsDels;
using System.Collections.Generic;
using TVMCalc.Operations.ObjctTemps;
using static TVMCalc.Operations.OppsDelegates.TVMOppsDels;
using static TVMCalc.Operations.Methods.TVMCfMethods;
using static TVMCalc.Operations.Methods.PrimaryOppsMethods;
using static TVMCalc.Operations.Methods.TVMMethods;

namespace TVMCalcUnitTest
{
    [TestClass]
    public class OppsTest
    {
        #region Two Input methods 
        [TestMethod]
        public void Add()
        {
            //Arrange, 
            double x = 4.55;
            double y = 4.5;
            //Act,
            var result = addCompt(x, y);
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
            var result = subtractCompt(x, y);
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
            var result = multiplyCompt(x, y);
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
            var result = devideCompt(x, y);
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
            var result = powerCompt(x, y);
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
            var result = percentCompt(x);
            //Assert
            Assert.AreEqual(.25, result);
        }

        [TestMethod]
        public void SquareRoot()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = sqrtCompt(x);
            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Square()
        {
            //Arrange, 
            double x = 5;
            //Act,
            var result = squareCompt(x);
            //Assert
            Assert.AreEqual(25, result);
        }

        [TestMethod]
        public void OneOver()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = oneOverCompt(x);
            //Assert
            Assert.AreEqual(0.04, result);
        }

        [TestMethod]
        public void NaturalLog()
        {
            //Arrange, 
            double x = 25;
            //Act,
            var result = Math.Round(naturalLogCompt(x),4);
            //Assert
            Assert.AreEqual(3.2189, result);
        }
        #endregion

        #region TVM Methods regular annuity Methods

        [TestMethod]
        public void NCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 0.00,
                I = 15,
                Pv = -250,
                Pmt = -15,
                Fv = 750,
            };  
            //Act,
            var result = Math.Round(nCompute(obj), 4);
            //Assert
            Assert.AreEqual(6.3487, result);
        }
        [TestMethod]
        public void N2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 0.00,
                I = 15,
                Pv = 200,
                Pmt = 15,
                Fv = -750,
            };
            //Act,
            var result = Math.Round(nCompute(obj), 4);

            //Assert
            Assert.AreEqual(7.4516, result);
        }

        [TestMethod]
        public void ICompute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 10,
                I = 0,
                Pv = -100,
                Pmt = -10,
                Fv = 1000,
            };
            //Act,
            var result = Math.Round(iCompute(obj), 4);

            //Assert
            Assert.AreEqual(21.7681, result);
        }
        [TestMethod]
        public void I2Compute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 12,
                I = 0,
                Pv = 140,
                Pmt = 50,
                Fv = -1000,
            };
            //Act,
            var result = Math.Round(iCompute(obj), 4);

            //Assert
            Assert.AreEqual(4.3512, result);
        }

        [TestMethod]
        public void PVCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 5,
                I = 10,
                Pv = 0,
                Pmt = -10,
                Fv = 200,
            };
            //Act,
            var result = Math.Round(pvCompute(obj), 4);

            //Assert
            Assert.AreEqual(-86.2764, result);
        }
        [TestMethod]
        public void PV2Compute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 8,
                I = 12,
                Pv = 0,
                Pmt = 10,
                Fv = -500,
            };
            //Act,
            var result = Math.Round(pvCompute(obj), 4);

            //Assert
            Assert.AreEqual(152.2652, result);
        }

        [TestMethod]
        public void PMTCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 10,
                I = 10,
                Pv = 15,
                Pmt = 0,
                Fv = 100,
            };
            //Act,
            var result = Math.Round(pmtCompute(obj), 4);

            //Assert
            Assert.AreEqual(-8.7157, result);
        }
        [TestMethod]
        public void PMT2Compute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 15,
                I = 5,
                Pv = -30,
                Pmt = 0,
                Fv = 250,
            };
            //Act,
            var result = Math.Round(pmtCompute(obj), 4);

            //Assert
            Assert.AreEqual(-8.6953, result);
        }

        [TestMethod]
        public void FVCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 5,
                I = 10,
                Pv = -5,
                Pmt = -10,
                Fv = 0,
            };
            //Act,
            var result = Math.Round(fvCompute(obj), 4);

            //Assert
            Assert.AreEqual(69.1036, result);
        }
        [TestMethod]
        public void FV2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 10,
                I = 6,
                Pv = -25,
                Pmt = -50,
                Fv = 0,
            };
            //Act,
            var result = Math.Round(fvCompute(obj), 4);

            //Assert
            Assert.AreEqual(703.8109, result);
        }
        #endregion

        #region TVM Methods annuity due Methods
        [TestMethod]
        public void NAdCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 0.00,
                I = 10,
                Pv = -100,
                Pmt = -10,
                Fv = 500,
            };
            //Act,
            var result = Math.Round(nAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(11.1882, result);
        }
        [TestMethod]
        public void NAd2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 0.00,
                I = 12,
                Pv = 200,
                Pmt = 5,
                Fv = -400,
            };
            //Act,
            var result = Math.Round(nAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(5.2394, result);
        }

        [TestMethod]
        public void IAdCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 10,
                I = 0,
                Pv = -100,
                Pmt = -10,
                Fv = 1000,
            };
            //Act,
            var result = Math.Round(iAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(20.9629, result);
        }
        [TestMethod]
        public void IAd2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 15,
                I = 0,
                Pv = 100,
                Pmt = 50,
                Fv = -925,
            };
            //Act,
            var result = Math.Round(iAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(0.9519, result);
        }

        [TestMethod]
        public void PVAdCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 5,
                I = 10,
                Pv = 0,
                Pmt = -10,
                Fv = 200,
            };
            //Act,
            var result = Math.Round(pvAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(-82.4856, result);
        }
        [TestMethod]
        public void PVAd2Compute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 5,
                I = 10,
                Pv = 0,
                Pmt = 10,
                Fv = -350
            };
            //Act,
            var result = Math.Round(pvAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(175.6238, result);
        }

        [TestMethod]
        public void PMTAdCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 10,
                I = 10,
                Pv = -15,
                Pmt = 0,
                Fv = 100,
            };
            //Act,
            var result = Math.Round(pmtAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(-3.4849, result);
        }
        [TestMethod]
        public void PMTAd2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 10,
                I = 15,
                Pv = 20,
                Pmt = 0,
                Fv = -346,
            };
            //Act,
            var result = Math.Round(pmtAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(11.3532, result);
        }

        [TestMethod]
        public void FVAdCompute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 5,
                I = 10,
                Pv = -5,
                Pmt = -10,
                Fv = 0,
            };
            //Act,
            var result = Math.Round(fvAdCompute(obj), 4);

            //Assert
            Assert.AreEqual(75.2087, result);
        }
        [TestMethod]
        public void FVAd2Compute()
        {
            //Arrange, 
            var obj = new TvmObject
            {
                N = 65,
                I = 8,
                Pv = 1000,
                Pmt = 100,
                Fv = 0,
            };
            //Act,
            var result = Math.Round(fvAdCompute(obj), 4);

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
            var result = Math.Round(CfNPVMethod(obj), 4);
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
            var result = Math.Round(CfNPVMethod(obj), 4);
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
            var result = Math.Round(CfNPVMethod(obj), 4);
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
    }
}