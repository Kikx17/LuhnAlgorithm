using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuhnAlgorithm
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("v for validate and q for quit.)");
			var UserInput = Console.ReadLine();

			while (UserInput != "q")
			{
				if (UserInput == "v")
				{
					Console.BackgroundColor = ConsoleColor.White;			//Console background color = white
					Console.ForegroundColor = ConsoleColor.Black;			//Console foreground color = black
					Console.WriteLine("Enter the credit card number:");
					Console.ResetColor();									// Reset console colors
					var cc = Console.ReadLine();

					if (Luhn(cc))											//send cc info to luhn algo and if true
					{                                                       //do this
						Console.BackgroundColor = ConsoleColor.Green;		//Console background color = green
						Console.ForegroundColor = ConsoleColor.White;		//Console foreground color = white
						Console.WriteLine("Syöte on kelvollinen numerosarja.");
						Console.ResetColor();                               // Reset console colors
						//Console.Write(kelvsarj);
					}
					else													//otherwise
					{                                                       //do this
						var pahasarj = 0;									//variable for the sum of bad card numbers
						pahasarj++;
						Console.BackgroundColor = ConsoleColor.DarkRed;       //Console background color = green
						Console.ForegroundColor = ConsoleColor.Black;       //Console foreground color = white
						Console.WriteLine("Syöte ei ole kelvollinen numerosarja.");
						Console.ResetColor();                               // Reset console colors
						Console.Write("Virheellisiä numerosarjoja: "+ (pahasarj)+"\n\n");
					}
				}

				Console.WriteLine("v for validate and q for quit.)");
				UserInput = Console.ReadLine();
			}
		}

		static bool Luhn(string cn)
		{
			var isValid = false;

			int t = 0;
			if (int.TryParse(cn,out t))
			{
				return false;
			}

			//1. starting at the check digit (right most), move left doubling the value of every second digit
			//note: if any turn into a double digit, we want to add the single digits OR x - 9
			var listCN = cn.ToList();
			listCN.Reverse();

			var list2 = new List<int>();

			var dblQ = 1;

			foreach (var c in listCN)
			{
				var tmp = int.Parse(c.ToString());
				if (dblQ % 2 == 0)
				{
					tmp = tmp * 2;	//double the value

					if (tmp > 9)
					{					//Make sure it's not above 9 after doubling
										//Make the value the sum of the two digits
						tmp = tmp - 9;
					}
				}

				list2.Add(tmp);
				dblQ++;
			}

			//2. Take sum of all digits
			var sumOfDigits = list2.Sum();
			Console.WriteLine("Sum of Digits: " + sumOfDigits.ToString());
			//3. Take the modulo (%) of the sum and if that == 0, It's valid

			//public var kelvsarj = 0;                                   //variable for the sum of good card numbers

			isValid = (sumOfDigits % 10) == 0;

			//kelvsarj++;
			return isValid;
		}
	}
}
