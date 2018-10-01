using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ClaimsReservingExercise.Interfaces
{   //This class will serve as the interface that accumulators will implement
    public interface IAccumulator
    {
        string PresentAccumulatedData(ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int DevelopmentYear, double TriangleValue)>>> processedInput);
    }
}
