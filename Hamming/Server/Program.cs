using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
	public class Program
	{
		/*
		 *
		 *def get_positions(pos, length)
	positions = []
	curr_val = pos
	
	until curr_val > length
	
		for a in 1..pos do
			positions << curr_val
			curr_val += 1
		end
		
		curr_val += pos

	end
	
	return positions

end
		 *
		 *
		 */


		private static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			Console.WriteLine(string.Join(", ",GetPositions(1, 16)));
			Console.WriteLine(string.Join(", ", GetPositions(2, 16)));
			Console.WriteLine(string.Join(", ", GetPositions(4, 16)));
			Console.WriteLine(string.Join(", ", GetPositions(8, 16)));
		}

		private static int[] GetPositions(int pos, int length)
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