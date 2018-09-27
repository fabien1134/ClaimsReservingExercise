using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsReservingExercise.Interfaces
{   //This will be the interface used by all input validating parsers
    interface ITextInputValidatingParser
    {   //Will return a data structure that can be efficiently processed
        Dictionary<string, Dictionary<int, (int DevelopmentYear, double TriangleValue)>> ParseTextInput(string input);
    }
}
