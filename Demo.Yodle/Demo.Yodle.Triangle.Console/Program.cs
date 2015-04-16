using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Yodle.Triangle.Console
{
	public class Program
	{
		private static int NUM_ROWS = 100;
		private static string INPUT_FILE = @".\triangle.txt";

		public static void Main(string[] args)
		{
			var array = GetInputArray();
		}

		public static int[][] GetInputArray()
		{
			int[][] result = new int[NUM_ROWS][];
			int row = 0;
			foreach (var line in File.ReadLines(INPUT_FILE))
			{
				var separator = new[] { ' ' };
				var numbers = line.Split(separator, StringSplitOptions.RemoveEmptyEntries);
				result[row] = new int[numbers.Length];

				int col = 0;
				foreach (string numberText in numbers)
				{
					int number;
					bool isParsed = int.TryParse(numberText, out number);
					if (!isParsed) throw new Exception("Input file is not correct!");

					result[row][col] = number;
					col++;
				}
				col = 0;

				row++;
			}

			return result;
		}
	}
}
