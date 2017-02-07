using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.RecipeMangement;
using Core.MeasurementUnitConversions;

namespace CoreTestProject
{
    [TestClass]
    public class VolumeUnitConversionTests
    {
        [TestClass]
        public class Convert
        {
            /* TODO:
             * I want to have every teaspoon conversion checked inside this class.
             * tsp to cup, tsp to gallon, etc
             */
            [TestClass]
            public class TeaSpoon
            {
                #region TeaSpoon to Different Unit

                [TestMethod]
                public void Convert_FromTeaSpoonToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon); //Correct Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
                #endregion

                #region Different Unit to Teaspoon
                [TestMethod]
                public void Convert_FromTableSpoonToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Correct Answer
                    Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(2.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
                #endregion
            }
        }

        [TestClass]
        public class TableSpoon
        {
            #region TableSpoon to Different Unit
            [TestMethod]
            public void Convert_FromTableSpoonToTeaSpoon_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Correct Answer
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTableSpoonToTeaSpoon_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(2.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTableSpoonToFluidOunce_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer
                Ingredient unconverted = new Ingredient(2.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTableSpoonToFluidOunce_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }
            #endregion

            #region Different Unit To TableSpoon
            [TestMethod]
            public void Convert_FromTeaSpoonToTableSpoon_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon); //Correct Answer
                Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTeaSpoonToTableSpoon_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromFluidOunceToTableSpoon_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(2.0f, MeasurementUnit.TableSpoon);
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromFluidOunceToTableSpoon_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(5.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }
            #endregion
        }

        [TestClass]
        public class FluidOunce
        {
            #region Fluid Ounce To Different Unit       
            [TestMethod]
            public void Convert_FromFluidOunceToTeaSpoon_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(6.0f, MeasurementUnit.TeaSpoon); //1 floz = 2 tbs = 6 tsp
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromFluidOunceToTeaSpoon_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TeaSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromFluidOunceToTableSpoon_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(2.0f, MeasurementUnit.TableSpoon);
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromFluidOunceToTableSpoon_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(5.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.FluidOunce);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.TableSpoon);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }
            #endregion

            #region Different Unit To Fluid Ounce
            [TestMethod]
            public void Convert_FromTableSpoonToFluidOunce_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer
                Ingredient unconverted = new Ingredient(2.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTableSpoonToFluidOunce_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TableSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }
            [TestMethod]
            public void Convert_FromTeaSpoonToFluidOunce_ReturnsCorrectAmount()
            {
                //Arrange
                Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer
                Ingredient unconverted = new Ingredient(6.0f, MeasurementUnit.TeaSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreEqual(expected.Amount, result.Amount);
            }

            [TestMethod]
            public void Convert_FromTeaSpoonToFluidOunce_ReturnsIncorrectAmount()
            {
                //Arrange
                Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                //Act
                Ingredient result = VolumeUnitConverter.Convert(unconverted, MeasurementUnit.FluidOunce);
                Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                //Assert
                Assert.AreNotEqual(notExpected.Amount, result.Amount);
            }
            #endregion
        }
    }
}
