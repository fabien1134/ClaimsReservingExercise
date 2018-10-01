using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ClaimsReservingExercise.Interfaces
{   //This will be the interface used by all input validating parsers
    public interface ITextInputValidatingParser
    {   //Will return a data structure that can be efficiently processed
        ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int DevelopmentYear, double TriangleValue)>>> ParseTextInput(string input);
    }
}
