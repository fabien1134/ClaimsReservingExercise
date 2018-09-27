using ClaimsReservingExercise.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsReservingExercise.Entities
{
    //This class will be responsible for validating input, and parsing it into a data structure 
    //that will be optimized for efficient processing
    public class InputContentProcessor : ITextInputValidatingParser
    {
        public Dictionary<string, Dictionary<int, (int DevelopmentYear, double TriangleValue)>> ParseTextInput(string inputTextContents)
        {   //Ensure there are contents present to be processed
            if (string.IsNullOrEmpty(inputTextContents))
                throw new Exception("Ensure Input File Has Been Loaded And Contains Input");





            return new Dictionary<string, Dictionary<int, (int DevelopmentYear, double TriangleValue)>>();
        }
    }
}
