using System;
using System.IO;
using Newtonsoft.Json;
namespace Solutions._59
{
    class TestCase
    {
        public int input { get; set; }
        public int[][] output { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var testCases = JsonConvert.DeserializeObject<TestCase[]>(File.ReadAllText("testcases.json"));
            foreach (var testCase in testCases)
            {
                var fiftyNine = new Solution();
                var result = fiftyNine.GenerateMatrix(testCase.input);
                var expected = testCase.output;
                if (result == null)
                {
                    throw new Exception("You returned null..");
                }
                if (testCase.input == 0 && result.Length != 0)
                {
                    throw new Exception("Empty array failed.");
                }
                for (int y = 0; y < expected.Length; y++)
                {
                    for (int x = 0; x < expected[0].Length; x++)
                    {
                        if (expected[y][x] != result[y][x])
                        {
                            throw new Exception($"Not valid! for {testCase.input}");
                        }
                    }
                }
                Console.WriteLine($"Case with input {testCase.input} was correct.");
            }
        }
    }
}
