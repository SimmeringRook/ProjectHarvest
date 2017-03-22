using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTestProject
{
    [TestClass]
    public class VolumeUnitConversionTests
    {
        //private const float AcceptableConversionDelta = 0.0001f;
        //[TestClass]
        //public class Convert
        //{
            
        //    [TestClass]
        //    public class TeaSpoon
        //    {
        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon); //Correct Answer

        //            float amountToConvert = 1 / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1 
        //                / MeasurementConversionFactors.FluidOunceToCupRatio 
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio 
        //                / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTeaSpoonToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class TableSpoon
        //    {
        //        [TestMethod]
        //        public void Convert_FromTableSpoonToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1 * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce);  //Correct Answer

        //            float amountToConvert = 1 / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.TableSpoonToFluidOunceRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.TableSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromTableSpoonToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.TeaSpoon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class FluidOunce
        //    {
        //        [TestMethod]
        //        public void Convert_FromFluidOunceToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1 
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

        //            float amountToConvert = 1 * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromFluidOunceToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.FluidOunce);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class Cup
        //    {
        //        [TestMethod]
        //        public void Convert_FromCupToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromCupToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Cup);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class Pint
        //    {
        //        [TestMethod]
        //        public void Convert_FromPintToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.PintToQuartRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.PintToQuartRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromPintToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Pint);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class Quart
        //    {
        //        [TestMethod]
        //        public void Convert_FromQuartToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.PintToQuartRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToGallon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Gallon); //Correct Answer

        //            float amountToConvert = 1
        //                / MeasurementConversionFactors.QuartToGallonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToGallon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Gallon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromQuartToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Quart);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }

        //    [TestClass]
        //    public class Gallon
        //    {
        //        [TestMethod]
        //        public void Convert_FromGallonToTeaSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TeaSpoon);  //Correct Answer
        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio
        //                * MeasurementConversionFactors.TeaSpoonToTableSpoonRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToTeaSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TeaSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToTableSpoon_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.TableSpoon);  //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio
        //                * MeasurementConversionFactors.TableSpoonToFluidOunceRatio;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToTableSpoon_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(3.0f, MeasurementUnit.TableSpoon); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToFluidOunce_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio
        //                * MeasurementConversionFactors.FluidOunceToCupRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon); // 

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToFluidOunce_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.FluidOunce); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToCup_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Cup); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio
        //                * MeasurementConversionFactors.PintToQuartRatio
        //                * MeasurementConversionFactors.CupToPintRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());
        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToCup_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Cup); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToPint_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Pint); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio
        //                * MeasurementConversionFactors.PintToQuartRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToPint_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Pint); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToQuart_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            Inventory expected = new Inventory(1.0f, MeasurementUnit.Quart); //Correct Answer

        //            float amountToConvert = 1
        //                * MeasurementConversionFactors.QuartToGallonRatio;

        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToQuart_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Quart); //Incorrect Answer
        //            Inventory unconverted = new Inventory(3.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToMilliliter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio();
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.MilliLiter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToMilliliter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.MilliLiter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToLiter_ReturnsCorrectAmount()
        //        {
        //            //Arrange
        //            float expectedAmount = 1.0f
        //                / MeasurementConversionFactors.FluidOunceToCupRatio
        //                / MeasurementConversionFactors.CupToPintRatio
        //                / MeasurementConversionFactors.PintToQuartRatio
        //                / MeasurementConversionFactors.QuartToGallonRatio
        //                / MeasurementConversionFactors.GetMilliliterToFluidOunceRatio()
        //                * MeasurementConversionFactors.MillilitersToLiters;
        //            Inventory expected = new Inventory(expectedAmount, MeasurementUnit.Liter); //Correct Answer

        //            float amountToConvert = 1.0f;
        //            Inventory unconverted = new Inventory(amountToConvert, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, expected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreEqual(expected.Amount, result.Amount, AcceptableConversionDelta);
        //        }

        //        [TestMethod]
        //        public void Convert_FromGallonToLiter_ReturnsIncorrectAmount()
        //        {
        //            //Arrange
        //            Inventory notExpected = new Inventory(1.0f, MeasurementUnit.Liter); //Incorrect Answer
        //            Inventory unconverted = new Inventory(1.0f, MeasurementUnit.Gallon);

        //            //Act
        //            Inventory result = VolumeUnitConversion.Convert(unconverted, notExpected.GetMeasurementUnit());
        //            Debug.Print("Amount: {0}, Unit: {1}", result.Amount, result.GetMeasurementUnit());

        //            //Assert
        //            Assert.AreNotEqual(notExpected.Amount, result.Amount);
        //        }
        //    }
        //}
        
    }
}
