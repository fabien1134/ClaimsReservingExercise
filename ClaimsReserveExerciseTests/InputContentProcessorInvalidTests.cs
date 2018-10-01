using System;
using ClaimsReservingExercise.Entities;
using ClaimsReservingExercise.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsReserveExerciseTests
{
    [TestClass]
    public class InputContentProcessorInvalidTests
    {
        //Case where a file read is empty
        [TestMethod]
        public void EmptyDataInput()
        {
            //Arrange
            string input = string.Empty;
            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure Input File Has Been Loaded And Contains Input", errorMessage);
        }

        //We expect 4 items to be present in data entry
        [TestMethod]
        public void MoreValuesInDataEntryThenExpected()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                 "Product, Origin Year, Development Year, Incremental Value",
                "Comp, 1992, 1992, 110.0,77"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure The Right Amount Of Data Is Present In All Data Entries", errorMessage);
        }


        //Expect a minimum of two entries in the datafile i.e label and data entry
        [TestMethod]
        public void DataEntryWithoutTheLabel()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                "Comp, 1992, 1992, 110.0,77"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure The Labels And At Least One Data Entry Is Present", errorMessage);
        }




        //The triangle value cannot be negative
        [TestMethod]
        public void InvalidTriangleValue()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                "Product, Origin Year, Development Year, Incremental Value",
                "Comp, 1992, 1992, -1"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure All Numerical Values Are Valid", errorMessage);
        }

        //The origin year cannot be negative
        [TestMethod]
        public void InvalidOriginYear()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                "Product, Origin Year, Development Year, Incremental Value",
                "Comp, -1,1992 , 10.22"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure All Numerical Values Are Valid", errorMessage);
        }


        //The development year value cannot be negative
        [TestMethod]
        public void InvalidDevelopmentYear()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                "Product, Origin Year, Development Year, Incremental Value",
                "Comp, 1992, -1, 10.22"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure All Numerical Values Are Valid", errorMessage);
        }

        //The origin year cannot be greater then the development year
        [TestMethod]
        public void OriginYearGreaterThenDevelopmentYear()
        {
            //Arrange
            string input = TestDataGenerator.GenerateTestData(
                "Product, Origin Year, Development Year, Incremental Value",
                "Comp, 1992, 1991, 10.22"
                );

            string errorMessage = string.Empty;

            try
            {
                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                //Act
                var parsedInput = inputContentProcessor.ParseTextInput(input);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }

            //Assert
            Assert.AreEqual("Ensure The Origin Year Is Not Greater Then The Development Year", errorMessage);
        }
    }
}
