using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
	public class Program
	{

		private const int InputLength = 11;
		private const int OutputLength = 7;

		private static void Main(string[] args)
		{
			Console.WriteLine($"Please write the byte of data you want to encode ({InputLength} bits)");
			string input;

			while ((input = Console.ReadLine())?.Length != InputLength)
			{
				Console.WriteLine("Incorrect byte of data length");
			}

			var array = input.ToCharArray();
			var output = 0;
			foreach (var parity in GetParity(OutputLength + 1))
			{
				int sum = 0;
				foreach (var position in GetPositions(parity, InputLength)) sum += int.Parse(array[position - 1].ToString());

				output += sum * parity;
			}

			if (output != 0)
			{
				var fixChar = FixChar(input[output - 1]);

				Console.WriteLine($"Byte at position {output} is incorrect. Fixed from { FixChar(fixChar) } to { fixChar } ");

				array[output - 1] = fixChar;

			}

			Console.WriteLine($"Decoded Hamming-Code: {DeleteParity(array)}");

		}

		private static string DeleteParity(char[] array)
		{
			var output = "";
			var parity = GetParity(OutputLength + 1);


			for (var i = 1; i <= array.Length; i++)
			{
				if (parity.Contains(i)) continue;
				output += array[i - 1];
			}

			return output;

		}


		private static char FixChar(char input) => input == '0' ? '1' : '0';

		private static int[] GetParity(int length)
		{
			var list = new List<int>();
			var currVal = 0;

			while (Math.Pow(2, currVal) <= length)
			{
				list.Add((int)Math.Pow(2, currVal));
				currVal++;
			}

			return list.ToArray();
		}

		private static IEnumerable<int> GetPositions(int pos, int length)
		{
			var list = new List<int>();
			var currentVal = pos;
			while (currentVal < length)
			{
				for (var i = 1; i <= pos; i++)
					currentVal = Math.Min(currentVal + 1, length);

				currentVal = Math.Min(currentVal + pos, length);

			}

			return list.ToArray();
		}
	}
}