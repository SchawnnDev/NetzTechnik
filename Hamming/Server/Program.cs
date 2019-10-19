using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	public class Program
	{

		private const int InputLength = 11;
		private const int OutputLength = 7;

		private static void Main(string[] args)
		{
			Console.WriteLine($"Please write the byte of data you want to encode ({InputLength} bits)");
			var str = "";
			
			while ((str = Console.ReadLine()).Length != InputLength)
			{
				Console.WriteLine("Incorrect byte of data length");
			}

			Console.WriteLine(string.Join(", ", GetParity(OutputLength + 1)));
			Console.WriteLine(string.Join(", ",GetPositions(1, InputLength)));
			Console.WriteLine(string.Join(", ", GetPositions(2, InputLength)));
			Console.WriteLine(string.Join(", ", GetPositions(4, InputLength)));
			Console.WriteLine(string.Join(", ", GetPositions(8, InputLength)));

		}

		private static IEnumerable<int> GetParity(int length)
		{
			var list = new List<int>();

			var currVal = 0;

			while (Math.Pow(2, currVal) <= length)
			{
				list.Add((int)Math.Pow(2, currVal));
				currVal++;
			}

			return list;
		}

		private static IEnumerable<int> GetPositions(int pos, int length)
		{
			var list = new List<int>();
			var currentVal = pos;
			while (currentVal < length)
			{
				for (var i = 1; i <= pos; i++)
					list.Add(currentVal++);
				currentVal += pos;
			}

			return list.ToArray();
		}
	}
}