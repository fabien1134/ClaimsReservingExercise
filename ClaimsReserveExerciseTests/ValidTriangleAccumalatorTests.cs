﻿using System;
using System.Text;
using ClaimsReservingExercise.Entities;
using ClaimsReservingExercise.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsReserveExerciseTests
{
    [TestClass]
    public class ValidTriangleAccumalatorTests
    {
        //Will see if the expected output is displayed
        [TestMethod]
        public void ValidInputTest()
        {
            bool exceptionDeteted = false;
            try
            {
                //Arrange
                string input = TestDataGenerator.GenerateTestData(
                "Product, Origin Year, Development Year, Incremental Value",
                "Comp, 1992, 1992, 110.0",
                "Comp, 1992, 1993, 170.0",
                "Comp, 1993, 1993, 200.0",
                "Non - Comp, 1990, 1990, 45.2",
                "Non - Comp, 1990, 1991, 64.8",
                "Non - Comp, 1990, 1993, 37.0",
                "Non - Comp, 1991, 1991, 50.0",
                "Non - Comp, 1991, 1992, 75.0",
                "Non - Comp, 1991, 1993, 25.0",
                "Non - Comp, 1992, 1992, 55.0",
                "Non - Comp, 1992, 1993, 85.0",
                "Non - Comp, 1993, 1993, 100.0"
                                    );

                ITextInputValidatingParser inputContentProcessor = new InputContentProcessor();
                var parsedInput = inputContentProcessor.ParseTextInput(input);

                //Act
                IAccumulator triangleAccumulator = new TriangleAccumalator();
                string result = triangleAccumulator.PresentAccumulatedData(parsedInput);
            }
            catch (Exception)
            {
                exceptionDeteted = true;
            }

            //Assert
            Assert.AreEqual(false, exceptionDeteted);
        }
    }
}
