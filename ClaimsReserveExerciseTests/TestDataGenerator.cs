using System.Text;

namespace ClaimsReserveExerciseTests
{   //This class will be responsible for generating data
    public class TestDataGenerator
    {
        //Ensure parsed data is returned as a string
        public static string GenerateTestData(params string[] inputData)
        {
            string testData = string.Empty;

            StringBuilder testDataBuilder = new StringBuilder();
            foreach (string data in inputData)
            {
                testDataBuilder.AppendLine(data);
            }

            return testDataBuilder.ToString();
        }
    }
}
