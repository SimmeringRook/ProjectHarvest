using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.RecipeMangement;
using Core.MeasurementConversions;

namespace CoreTestProject
{
    [TestClass]
    public class VolumeUnitConversionTests
    {
        [TestClass]
        public class Convert
        {
            
            [TestClass]
            public class TeaSpoon
            {
                [TestMethod]
                public void Convert_FromTeaSpoonToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon); //Correct Answer

                    float amountToConvert = 1 / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
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
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
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
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1 
                        / MeasurementConversionFactors.FluidOunceToCupRatio 
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio 
                        / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTeaSpoonToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                //TODO: Fix
                //[TestMethod]
                //public void Convert_FromTeaSpoonToMillileter_ReturnsCorrectAmount()
                //{
                //    //Arrange
                //    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.MilliLiter); //Correct Answer

                //    float amountToConvert = 1;

                //    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TeaSpoon);

                //    //Act
                //    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                //    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                //    //Assert
                //    Assert.AreEqual(expected.Amount, result.Amount);
                //}

                //[TestMethod]
                //public void Convert_FromTeaSpoonToMillileter_ReturnsIncorrectAmount()
                //{
                //    //Arrange
                //    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
                //    Ingredient unconverted = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);

                //    //Act
                //    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                //    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                //    //Assert
                //    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                //}
            }

            [TestClass]
            public class TableSpoon
            {
                [TestMethod]
                public void Convert_FromTableSpoonToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1 * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce);  //Correct Answer

                    float amountToConvert = 1 / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
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
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio
                        / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.TableSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromTableSpoonToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.TeaSpoon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }

            [TestClass]
            public class FluidOunce
            {
                [TestMethod]
                public void Convert_FromFluidOunceToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1 
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

                    float amountToConvert = 1 * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio
                        / MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromFluidOunceToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.FluidOunce);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }

            [TestClass]
            public class Cup
            {
                [TestMethod]
                public void Convert_FromCupToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToFluidOunce_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio
                        / MeasurementConversionFactors.PintToQuartRatio
                        / MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromCupToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Cup);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }

            [TestClass]
            public class Pint
            {
                [TestMethod]
                public void Convert_FromPintToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToFluidOunce_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.PintToQuartRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio
                        / MeasurementConversionFactors.PintToQuartRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromPintToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Pint);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }

            [TestClass]
            public class Quart
            {
                [TestMethod]
                public void Convert_FromQuartToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToFluidOunce_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.PintToQuartRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToGallon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Correct Answer

                    float amountToConvert = 1
                        / MeasurementConversionFactors.QuartToGallonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromQuartToGallon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Quart);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }

            [TestClass]
            public class Gallon
            {
                [TestMethod]
                public void Convert_FromGallonToTeaSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
                        * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToTeaSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToTableSpoon_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio
                        * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToTableSpoon_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToFluidOunce_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio
                        * MeasurementConversionFactors.FluidOunceToCupRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon); // 

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToFluidOunce_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToCup_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Cup); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio
                        * MeasurementConversionFactors.PintToQuartRatio
                        * MeasurementConversionFactors.CupToPintRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);
                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToCup_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Cup); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToPint_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Pint); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio
                        * MeasurementConversionFactors.PintToQuartRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToPint_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Pint); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToQuart_ReturnsCorrectAmount()
                {
                    //Arrange
                    Ingredient expected = new Ingredient(1.0f, MeasurementUnit.Quart); //Correct Answer

                    float amountToConvert = 1
                        * MeasurementConversionFactors.QuartToGallonRatio;

                    Ingredient unconverted = new Ingredient(amountToConvert, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, expected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreEqual(expected.Amount, result.Amount);
                }

                [TestMethod]
                public void Convert_FromGallonToQuart_ReturnsIncorrectAmount()
                {
                    //Arrange
                    Ingredient notExpected = new Ingredient(1.0f, MeasurementUnit.Quart); //Incorrect Answer
                    Ingredient unconverted = new Ingredient(3.0f, MeasurementUnit.Gallon);

                    //Act
                    Ingredient result = VolumeUnitConverter.Convert(unconverted, notExpected.Measurement);
                    Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.Measurement);

                    //Assert
                    Assert.AreNotEqual(notExpected.Amount, result.Amount);
                }
            }
        }
        
    }
}
