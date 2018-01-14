using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TVMCalc.Operations.ObjctTemps;
using static TVMCalc.Operations.Methods.TVMCfMethods;
using static TVMCalc.Operations.Methods.PrimaryOppsMethods;
using static TVMCalc.Operations.Methods.TVMMethods;
using static TVMCalc.Operations.Methods.SecondaryOppsMethods;

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
                var result = AddCompt(x, y);
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
                var result = SubtractCompt(x, y);
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
                var result = MultiplyCompt(x, y);
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
                var result = DevideCompt(x, y);
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
                var result = PowerCompt(x, y);
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
                var result = PercentCompt(x);
                //Assert
                Assert.AreEqual(.25, result);
            }

            [TestMethod]
            public void SquareRoot()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = SqrtCompt(x);
                //Assert
                Assert.AreEqual(5, result);
            }

            [TestMethod]
            public void Square()
            {
                //Arrange, 
                double x = 5;
                //Act,
                var result = SquareCompt(x);
                //Assert
                Assert.AreEqual(25, result);
            }

            [TestMethod]
            public void OneOver()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = OneOverCompt(x);
                //Assert
                Assert.AreEqual(0.04, result);
            }

            [TestMethod]
            public void NaturalLog()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = Math.Round(NaturalLogCompt(x), 4);
                //Assert
                Assert.AreEqual(3.2189, result);
            }

            [TestMethod]
            public void ECompt()
            {
                //Arrange, 
                double x = 5;
                //Act,
                var result = Math.Round(ECompute(x), 4);
                //Assert
                Assert.AreEqual(148.4132, result);
            }
            #endregion

        #region TVM Methods regular annuity Methods

        [TestMethod]
        public void N_Compute()
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
                var result = Math.Round(NCompute(obj), 4);
                //Assert
                Assert.AreEqual(6.3487, result);
            }
        [TestMethod]
        public void N2_Compute()
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
                var result = Math.Round(NCompute(obj), 4);

                //Assert
                Assert.AreEqual(7.4516, result);
            }

        [TestMethod]
        public void I_Compute()
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
                var result = Math.Round(ICompute(obj), 4);

                //Assert
                Assert.AreEqual(21.7681, result);
            }
        [TestMethod]
        public void I2_Compute()
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
                var result = Math.Round(ICompute(obj), 4);

                //Assert
                Assert.AreEqual(4.3512, result);
            }
        [TestMethod]
        public void I3_Compute()
        {
            //Arrange,
            var obj = new TvmObject
            {
                N = 3,
                I = 0,
                Pv = -3,
                Pmt = 3,
                Fv = 3,
            };
            //Act,
            var result = Math.Round(ICompute(obj), 4);

            //Assert
            Assert.AreEqual(100.0000, result);
        }

        [TestMethod]
        public void PV_Compute()
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
                var result = Math.Round(PvCompute(obj), 4);

                //Assert
                Assert.AreEqual(-86.2764, result);
            }
        [TestMethod]
        public void PV2_Compute()
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
                var result = Math.Round(PvCompute(obj), 4);

                //Assert
                Assert.AreEqual(152.2652, result);
            }

        [TestMethod]
        public void PMT_Compute()
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
                var result = Math.Round(PmtCompute(obj), 4);

                //Assert
                Assert.AreEqual(-8.7157, result);
            }
        [TestMethod]
        public void PMT2_Compute()
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
                var result = Math.Round(PmtCompute(obj), 4);

                //Assert
                Assert.AreEqual(-8.6953, result);
            }

        [TestMethod]
        public void FV_Compute()
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
                var result = Math.Round(FvCompute(obj), 4);

                //Assert
                Assert.AreEqual(69.1036, result);
            }
        [TestMethod]
        public void FV2_Compute()
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
                var result = Math.Round(FvCompute(obj), 4);

                //Assert
                Assert.AreEqual(703.8109, result);
            }
        #endregion

        #region TVM Methods annuity due Methods
        [TestMethod]
        public void NAd_Compute()
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
                var result = Math.Round(NAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(11.1882, result);
            }
        [TestMethod]
        public void NAd2_Compute()
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
                var result = Math.Round(NAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(5.2394, result);
            }

        [TestMethod]
        public void IAd_Compute()
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
                var result = Math.Round(IAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(20.9629, result);
            }
        [TestMethod]
        public void IAd2_Compute()
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
                var result = Math.Round(IAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(0.9519, result);
            }

        [TestMethod]
        public void PVAd_Compute()
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
                var result = Math.Round(PvAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(-82.4856, result);
            }
        [TestMethod]
        public void PVAd2_Compute()
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
                var result = Math.Round(PvAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(175.6238, result);
            }

        [TestMethod]
        public void PMTAd_Compute()
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
                var result = Math.Round(PmtAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(-3.4849, result);
            }
        [TestMethod]
        public void PMTAd2_Compute()
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
                var result = Math.Round(PmtAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(11.3532, result);
            }

        [TestMethod]
        public void FVAd_Compute()
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
                var result = Math.Round(FvAdCompute(obj), 4);

                //Assert
                Assert.AreEqual(75.2087, result);
            }
        [TestMethod]
        public void FVAd2_Compute()
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
                var result = Math.Round(FvAdCompute(obj), 4);

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
                obj.CF0_Npv = -150;
                obj.I_Npv = 10;
                obj.CashFlows_Npv = new List<double>
                {
                    10,20,5,3,250
                };

                obj.Frequency_Npv = new List<double>
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
                obj.CF0_Npv = 150;
                obj.I_Npv = 8.04;
                obj.CashFlows_Npv = new List<double>
                {
                    10,15,-5,-33,50
                };

                obj.Frequency_Npv = new List<double>
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
                obj.CF0_Npv = 0;
                obj.I_Npv = 10;
                obj.CashFlows_Npv = new List<double>
                {
                    5,-10
                };

                obj.Frequency_Npv = new List<double>
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
                obj.CF0_Irr = 0;
                obj.CashFlows_Irr = new List<double>
                {
                5555,-1000
                };
                obj.Frequency_Irr = new List<double>
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
                obj.CF0_Irr = 0;
                obj.CashFlows_Irr = new List<double>
                {
                500,-100,-300
                };
                obj.Frequency_Irr = new List<double>
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
                obj.CF0_Irr = -155;
                obj.CashFlows_Irr = new List<double>
                {
                5,-10,5,1000
                };
                obj.Frequency_Irr = new List<double>
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
                obj.CF0_Irr = -3500;
                obj.CashFlows_Irr = new List<double>
                {
                5,-10,5,2000
                };
                obj.Frequency_Irr = new List<double>
                {
                10,2,3,1
                };

                //Act,
                var result = Math.Round(CfIRRMethod(obj), 4);
                //Assert
                Assert.AreEqual(-3.3412, result);
            }
        [TestMethod]
        public void IRR5Compute()
            {
                //Arrange, 
                var obj = new CfObject();
                obj.CF0_Irr = -5000;
                obj.CashFlows_Irr = new List<double>
                {
                    1000
                };
                obj.Frequency_Irr = new List<double>
                {
                    3
                };

                //Act,
                var result = Math.Round(CfIRRMethod(obj), 4);
                
                //Assert
                Assert.AreEqual(-21.7627, result);
            }
        [TestMethod]
        public void IRR6Compute()
            {
                //Arrange, 
                var obj = new CfObject();
                obj.CF0_Irr = -5000;
                obj.CF0_Npv = -5000;
                obj.I_Npv = 5;
                obj.CashFlows_Irr = new List<double>
                {
                    1000
                };
                obj.Frequency_Irr = new List<double>
                {
                    3
                };
                obj.CashFlows_Npv = new List<double>
                {
                    1000
                };
                obj.Frequency_Npv = new List<double>
                {
                    3
                };

                //Act,
                var result2 = CfNPVMethod(obj);
                var result = Math.Round(CfIRRMethod(obj), 4);
                
                //Assert
                Assert.AreEqual(-21.7627, result);
            }
        #endregion

        #region Secondary Functions
        #region Amort
            [TestMethod]
            public void Amort()
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = -40.6863;
                tObj.Fv = 0;
                var obj = new AmortObject();
                obj.P1 = 1;
                obj.P2 = 1;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(234.3137, Math.Round(result.EndBal, 4));
                Assert.AreEqual(-15.6863, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-25.0000, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort2()
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = -40.6863;
                tObj.Fv = 0;
                var obj = new AmortObject();
                obj.P1 = 3;
                obj.P2 = 5;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(154.2336, Math.Round(result.EndBal, 4));
                Assert.AreEqual(-62.8252, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-59.2337, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort3()
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = -40.6863;
                tObj.Fv = 0;
                var obj = new AmortObject();
                obj.P1 = 3;
                obj.P2 = 3;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(198.0783, Math.Round(result.EndBal, 4)); //calc returned 198.0784 which is strange. Because a double is used it is likely more accurate than the BA II Plus.
                Assert.AreEqual(-18.9804, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-21.7059, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort4() //With Balloon Payment
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = -40.0589;
                tObj.Fv = -10;
                var obj = new AmortObject();
                obj.P1 = 3;
                obj.P2 = 9;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(45.5080, Math.Round(result.EndBal, 4));
                Assert.AreEqual(-172.8683, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-107.5440, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort5() // With 0 payment and -FV
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = 0;
                tObj.Fv = -648.4356;
                var obj = new AmortObject();
                obj.P1 = 1;
                obj.P2 = 1;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(275.0000, Math.Round(result.EndBal, 4));
                Assert.AreEqual(25.0000, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-25.0000, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort6() // With + payment and -FV
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = 250;
                tObj.Pmt = 10;
                tObj.Fv = -907.8099;
                var obj = new AmortObject();
                obj.P1 = 1;
                obj.P2 = 1;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(285.0000, Math.Round(result.EndBal, 4));
                Assert.AreEqual(35.0000, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(-25.0000, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort7() // With - payment -PV +FV
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = -250;
                tObj.Pmt = -25;
                tObj.Fv = 1046.8712;
                var obj = new AmortObject();
                obj.P1 = 1;
                obj.P2 = 1;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(-300.0000, Math.Round(result.EndBal, 4));
                Assert.AreEqual(-50.0000, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(25.0000, Math.Round(result.IntPaid, 4));
            }
            [TestMethod]
            public void Amort8() // With + payment -PV -FV
            {
                //Arrange, 
                var tObj = new TvmObject();
                tObj.N = 10;
                tObj.I = 10;
                tObj.Pv = -250;
                tObj.Pmt = 103.4317;
                tObj.Fv = -1000;
                var obj = new AmortObject();
                obj.P1 = 1;
                obj.P2 = 1;

                //Act,
                var result = AmortCompute(tObj, obj);
                //Assert
                Assert.AreEqual(-171.5683, Math.Round(result.EndBal, 4));
                Assert.AreEqual(78.4317, Math.Round(result.PrnPaid, 4));
                Assert.AreEqual(25.0000, Math.Round(result.IntPaid, 4));
            }
            #endregion

        [TestMethod]
        public void Rand_Compute()
            {
                //Arrange, 
                double x = 0;
                double y = 0;
                //Act,
                x = RandCompute();
                y = RandCompute();
                //Assert
                Assert.AreNotEqual(x, y);
            }
        [TestMethod]
        public void Round_Compute()
            {
                //Arrange, 
                double x = 61.4732156216;
                int y = 2;
                //Act,
                var result = RoundCompute(x, y);
                //Assert
                Assert.AreEqual(61.47, Math.Round(result, 2));
            }
        [TestMethod]
        public void Factorial_Compute() //This is an extension method
            {
                //Arrange, 
                double x = 5;
                //Act,
                var result = x.Factorial_Recursion();
                //Assert
                Assert.AreEqual(120.0000, Math.Round(result, 4));
            }
        [TestMethod]
        public void PlusMinus_Compute() //This is an extension method
            {
                //Arrange, 
                double x = 5;
                //Act,
                var result = x.Plus_Minus();
                //Assert
                Assert.AreEqual(-5.0000, Math.Round(result, 4));
            }

        [TestMethod]
        public void Npr_Compute()
        {
            //Arrange, 
            double x = 5;
            double y = 5;
            //Act,
            var result = NprCompute(x, y);

            //Assert
            Assert.AreEqual(120.0000, result);
        }
        [TestMethod]
        public void Npr_Compute2()
        {
            //Arrange, 
            double x = -5;
            double y = -20;
            //Act,
            var result = NprCompute(x, y);

            //Assert
            Assert.AreEqual(0.0000, Math.Round(result,4));
        }
        [TestMethod]
        public void Cpr_Compute()
        {
            //Arrange, 
            double x = 5;
            double y = 3;
            //Act,
            var result = NcrCompute(x, y);

            //Assert
            Assert.AreEqual(10.0000, result);
        }
        [TestMethod]
        public void Cpr_Compute2()
        {
            //Arrange, 
            double x = -5;
            double y = -20;
            //Act,
            var result = NcrCompute(x, y);

            //Assert
            Assert.AreEqual(0.0000, Math.Round(result,4));
        }

        #region Sin Cos Tan
        [TestMethod]
            public void Sin_Compute()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = SinCompute(x);

                //Assert
                Assert.AreEqual(0.4226, Math.Round(result, 4));
            }
            [TestMethod]
            public void Cos_Compute()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = CosCompute(x);

                //Assert
                Assert.AreEqual(0.9063, Math.Round(result, 4));
            }
            [TestMethod]
            public void Tan_Compute()
            {
                //Arrange, 
                double x = 25;
                //Act,
                var result = TanCompute(x);

                //Assert
                Assert.AreEqual(0.4663, Math.Round(result, 4));
            }
            [TestMethod]
            public void Asin_Compute()
            {
                //Arrange, 
                double x = 0.3;
                //Act,
                var result = AsinCompute(x);

                //Assert
                Assert.AreEqual(17.4576, Math.Round(result, 4));
            }
            [TestMethod]
            public void Acos_Compute()
            {
                //Arrange, 
                double x = 0.3;
                //Act,
                var result = AcosCompute(x);

                //Assert
                Assert.AreEqual(72.5424, Math.Round(result, 4));
            }
            [TestMethod]
            public void Atan_Compute()
            {
                //Arrange, 
                double x = 0.3;
                //Act,
                var result = AtanCompute(x);

                //Assert
                Assert.AreEqual(16.6992, Math.Round(result, 4));
            }
            #endregion
        #endregion
    }
}
