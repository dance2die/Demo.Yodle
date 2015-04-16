using System;
using System.IO;
using System.Linq;

namespace Demo.Yodle.Triangle.Console
{
	public class Program
	{
		private static string INPUT_FILE = @".\triangle.txt";
		private static string TEST_INPUT_FILE = @".\triangle - test.txt";

		public static void Main(string[] args)
		{
			var array = GetInputArray(INPUT_FILE);
			//var array = GetInputArray(TEST_INPUT_FILE);
			int result = FindMaxiumTotal(array);
			System.Console.WriteLine("Result: {0}", result);
		}


		private static int FindMaxiumTotal(int[][] input)
		{
			int result = 0;
			int middleIndex = 0;
			for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
			{
				int leftValue = GetInputValue(input, rowIndex, middleIndex - 1);
				int middleValue = GetInputValue(input, rowIndex, middleIndex);
				int rightValue = GetInputValue(input, rowIndex, middleIndex + 1);
				MaxValueInfo maxValueInfo = GetMaxValueInfo(middleIndex, new []{leftValue, middleValue, rightValue});
				result += maxValueInfo.MaxValue;
				middleIndex = maxValueInfo.Index;
			}

			return result;
		}

		private static MaxValueInfo GetMaxValueInfo(int middleIndex, int[] values)
		{
			var maxValue = values.Max();
			int maxIndex = values.ToList().IndexOf(maxValue);
			return new MaxValueInfo(middleIndex + maxIndex, maxValue);
		}


		private static int GetInputValue(int[][] input, int rowIndex, int columnIndex)
		{
			if (input.Length <= rowIndex || rowIndex < 0) return 0;
			if (input[rowIndex].Length <= columnIndex || columnIndex < 0) return 0;

			return input[rowIndex][columnIndex];
		}

		public static int[][] GetInputArray(string inputFile)
		{
			int rowIndex = 0;
			var lines = File.ReadLines(inputFile).ToList();
			int[][] result = new int[lines.Count][];
			foreach (var line in lines)
			{
				var separator = new[] { ' ' };
				var numbers = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				result[rowIndex] = new int[numbers.Length];

				int col = 0;
				foreach (string numberText in numbers)
				{
					int number;
					bool isParsed = int.TryParse(numberText, out number);
					if (!isParsed) throw new Exception("Input file is not correct!");

					result[rowIndex][col] = number;
					col++;
				}
				col = 0;

				rowIndex++;
			}

			return result;
		}
	}

	public class MaxValueInfo
	{
		public int Index { get; set; }
		public int MaxValue { get; set; }

		public MaxValueInfo(int index, int maxValue)
		{
			Index = index;
			MaxValue = maxValue;
		}
	}
}
