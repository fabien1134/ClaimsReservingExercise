using ClaimsReservingExercise.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace ClaimsReservingExercise.Entities
{
    //This class will be responsible for validating input, and parsing it into a data structure 
    //that will be optimized for efficient processing
    //Will not validate if origin days development years are distinct here as it will be more
    //efficient to use it in a class that will be using the TPL library
    public class InputContentProcessor : ITextInputValidatingParser
    {
        private const string m_invalidNumericalValueDetected = "Ensure All Numerical Values Are Valid";
        public ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int DevelopmentYear, double TriangleValue)>>> ParseTextInput(string inputTextContents)
        {   //Ensure there are contents present to be processed
            if (string.IsNullOrEmpty(inputTextContents))
                throw new Exception("Ensure Input File Has Been Loaded And Contains Input");

            //Split each data entry of the of the input text
            string[] cumulativeClaimsDataCollection = inputTextContents.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //We expect a minimum of two items i.e the headings and a data entry
            if (cumulativeClaimsDataCollection.Length < 2)
                throw new Exception("Ensure The Labels And At Least One Data Entry Is Present");

            //The data structure will allow optimized processing to be performed on the input data
            var productOriginYearEntryMapping = new ConcurrentDictionary<string, ConcurrentDictionary<int, List<(int, double)>>>();

            //Process the input in parallel, ensure the first entry is skipped
            for (int i = 1; i < cumulativeClaimsDataCollection.Length; i++)
            {
                //split the data entry, empty data entries will be removed
                string[] cumulativeClaimsDataItems = cumulativeClaimsDataCollection[i].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                //Ensure there is a valid number of items for the cumulativeClaimsData entry
                if (cumulativeClaimsDataItems.Length != 4)
                    throw new Exception("Ensure The Right Amount Of Data Is Present In All Data Entries");

                //Ensure the user has not input any empty entries
                if (cumulativeClaimsDataItems.Any((cumulativeClaimsDataItem) => string.IsNullOrEmpty(cumulativeClaimsDataItem)))
                    throw new Exception("Ensure No Empty Entries Are Present In Data Entries");

                //Parse string collection to an int collection, value must have four characters
                int[] parsedCumulativeClaimsDataItems = StringToIntArray(minYearBoundary: 1000, maxYearBoundary: 9999, cumulativeClaimsDataItems[1], cumulativeClaimsDataItems[2]);
                int parsedOriginYear = parsedCumulativeClaimsDataItems[0];
                int parsedDevelopmentYear = parsedCumulativeClaimsDataItems[1];

                //Ensure the development year is greater or equal to the originalYear
                if (parsedOriginYear > parsedDevelopmentYear)
                    throw new Exception("Ensure The Origin Year Is Not Greater Then The Development Year");

                //Assign variables
                string productName = cumulativeClaimsDataItems[0];
                string triangleValue = cumulativeClaimsDataItems[3];

                //The parsed triangle value must not be less then 0
                if (!double.TryParse(triangleValue, out double parsedTriangleValue) || parsedTriangleValue < 0)
                    throw new Exception(m_invalidNumericalValueDetected);

                //If the product is not in the collection, add it
                if (productOriginYearEntryMapping.ContainsKey(productName))
                {   //If the origin years have already been added, add its data items
                    if (productOriginYearEntryMapping[productName].ContainsKey(parsedOriginYear))
                    {
                        productOriginYearEntryMapping[productName][parsedOriginYear].Add((parsedDevelopmentYear, parsedTriangleValue));
                    }
                    else
                    {   //If the origin year has not been stored, add it as a key including its mapped data items
                        productOriginYearEntryMapping[productName].TryAdd(parsedOriginYear, new List<(int, double)>() {
                             (parsedDevelopmentYear, parsedTriangleValue)
                         });
                    }
                }
                else
                {   //Add the origin year and its data items to the selected product
                    var originYearDataMapping = new ConcurrentDictionary<int, List<(int, double)>>();
                    originYearDataMapping.TryAdd(parsedOriginYear, new List<(int, double)>() {
                         (parsedDevelopmentYear, parsedTriangleValue)
                     });
                    productOriginYearEntryMapping.TryAdd(productName, originYearDataMapping);
                }
            }

            return productOriginYearEntryMapping;
        }

        //Parses the years ensuring they have a min and max boundary
        private int[] StringToIntArray(int minYearBoundary, int maxYearBoundary, params string[] stringArray)
        {
            int[] intCollection = new int[stringArray.Length];

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (!int.TryParse(stringArray[i], out int parsedStringItem) || parsedStringItem < minYearBoundary || parsedStringItem > maxYearBoundary)
                    throw new Exception(m_invalidNumericalValueDetected);
                intCollection[i] = parsedStringItem;
            }

            return intCollection;
        }
    }
}
