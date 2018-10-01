using ClaimsReservingExercise.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsReservingExercise.Entities
{   //This class will be responsible for accumulating the triangles
    //and presenting the data in a formatted manner
    public class TriangleAccumalator : IAccumulator
    {
        public string PresentAccumulatedData(ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int DevelopmentYear, double TriangleValue)>>> processedInput)
        {
            StringBuilder accumalatedResults = new StringBuilder();
            //Store the oldest origin and the total development years
            int oldestOrigin = CalculateOldestYearAndTotalDevelopmentYears(out int totalDevelopmentYears, processedInput);
            accumalatedResults.AppendLine($"{oldestOrigin}, {totalDevelopmentYears} ");

            //Create a new structure containing accumulated triangle values
            var processedTriangleCollection = new ConcurrentDictionary<string, ConcurrentDictionary<int, List<AlterableKVPair>>>();

            //Calculate accumulated triangles for each product
            Parallel.ForEach(processedInput, (processedInputItem) =>
            {
                Parallel.ForEach(processedInputItem.Value, (keyValue) =>
                {
                    List<(int DevelopmentYear, double TriangleValue)> orderedTriangleList = keyValue.Value.OrderBy(kv => kv.DevelopmentYear).ToList();
                    string productName = processedInputItem.Key;
                    int originYear = keyValue.Key;
                    double previousValue = 0;

                    //Copy to a mutable data structure, temp
                    var orderedTriangleListKV = orderedTriangleList.ConvertAll((oldKV) => new AlterableKVPair()
                    {
                        DevelopmentYear = oldKV.DevelopmentYear,
                        TriangleValue = oldKV.TriangleValue
                    });

                    //Calculate and store accumulating values
                    for (int i = 0; i < orderedTriangleList.Count; i++)
                    {
                        orderedTriangleListKV[i].TriangleValue += previousValue;
                        previousValue = orderedTriangleListKV[i].TriangleValue;
                    }


                    //Store values in new data structure
                    var dataItems = new ConcurrentDictionary<int, List<AlterableKVPair>>();
                    dataItems.TryAdd(originYear, orderedTriangleListKV);
                    if (!processedTriangleCollection.TryAdd(productName, dataItems))
                        processedTriangleCollection[productName].TryAdd(originYear, orderedTriangleListKV);

                });
            });



            //Output and format the results
            foreach (var processedTriangleItem in processedTriangleCollection)
            {
                //Store the product name
                accumalatedResults.Append($"{processedTriangleItem.Key}, ");
                //Used to keep track of cycling position
                int originYearChecker = oldestOrigin;
                int totalDevelopmentYearsChecker = totalDevelopmentYears;

                double previousTriangleItem = 0;

                for (int i = 0; i < processedTriangleItem.Value.Count; i++)
                {
                    if (processedTriangleItem.Value.ContainsKey(originYearChecker))
                    {
                        int key = processedTriangleItem.Value.Keys.ElementAt(i);

                        //Add each triangle to the list
                        for (int j = 0; j < processedTriangleItem.Value[key].Count; j++)
                        {
                            double triangleItem = processedTriangleItem.Value[key][j].TriangleValue;

                            if(triangleItem==)

                            previousTriangleItem = triangleItem;
                        }

                        var check = processedTriangleItem.Value[key];
                    }
                    else
                    {//Add zero
                        AddMissingData(accumalatedResults, totalDevelopmentYearsChecker);
                    }

                    //Cycle through all missing days
                    originYearChecker++;
                    //Keep track how many development years left
                    totalDevelopmentYearsChecker--;
                }





                accumalatedResults.AppendLine();
            }



            return accumalatedResults.ToString();
        }


        //Add missing valid data
        private void AddMissingData(StringBuilder accumalatedResults, int missingAmount)
        {
            for (int i = 0; i < missingAmount; i++)
            {
                accumalatedResults.Append($"0, ");
            }
        }


        public class AlterableKVPair
        {
            public int DevelopmentYear { get; set; }
            public double TriangleValue { get; set; }
            public AlterableKVPair() { }
        }

        private int CalculateOldestYearAndTotalDevelopmentYears(out int totalDevelopmentYears, ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int DevelopmentYear, double TriangleValue)>>> processedInput)
        {
            //Will store the oldest and youngest date to calculate the 
            int oldestOrigin = 9999;
            int youngestOrigin = 0;
            const int offset = 1;

            //Calculate the oldest origin year and development years
            foreach (var item in processedInput)
            {
                var keys = item.Value.Keys.GetEnumerator();
                while (keys.MoveNext())
                {
                    oldestOrigin = (keys.Current < oldestOrigin) ? keys.Current : oldestOrigin;
                    youngestOrigin = (keys.Current > youngestOrigin) ? keys.Current : youngestOrigin;
                }
            }

            //Calculate the total development years
            totalDevelopmentYears = (youngestOrigin - oldestOrigin) + offset;

            return oldestOrigin;
        }
    }
}
