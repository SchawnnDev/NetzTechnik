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
			var input = args.Length == 0 ? "00011110000" : args[0];

			if(string.IsNullOrWhiteSpace(input)) { 
				Console.WriteLine("Incorrect byte of data length");
				return;
			}

			var array = input.ToCharArray();
			var output = (from parity in GetParity(OutputLength + 1) let pos = GetPositions(parity, InputLength) let a = Mod(array, pos) select a * parity).Sum();

			if (output != 0)
			{
				var fixChar = FixChar(input[output - 1]);

				Console.WriteLine($"Byte at position {output} from {DeleteParity(array)} is incorrect. Fixed from { FixChar(fixChar) } to { fixChar } ");

				array[output - 1] = fixChar;

				Console.WriteLine($"Corrected 11-Hamming-Code: {string.Join("", array)}");
				Console.WriteLine();
			}

			Console.WriteLine($"Decoded Hamming-Code: {DeleteParity(array)}");

		}

		private static int Mod(char[] array, int[] where) => @where.Where(i => i <= array.Length).Aggregate(0, (current, i) => current + array[i - 1]) % 2;

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

		private static int[] GetPositions(int pos, int length)
		{
			var list = new List<int>();
			var currentVal = pos;
			while (currentVal <= length)
			{
				for (var i = 1; i <= pos; i++)
					list.Add(currentVal++);

				currentVal += pos;

			}

			return list.ToArray();
		}
	}
}