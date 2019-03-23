using System;
using System.Collections.Generic;

/******************************************************************
*	Kevin Lee	The Towers of Hanoi Puzzle - Create a peg Class   * 
*	Period 1	that will incorporate the functions needed to     *
*   2/8/18		play the game.	                                  *
* *****************************************************************/

namespace TowersOfHanoi_Console
{
	class Peg
	{
		private int height;
		public int Height
		{
			get { return height; }
		}

		public List<int> rings = new List<int>();

		public Peg(int height)
		{
			this.height = height;
		}

		public void AddRing(int width)
		{
			rings.Add(width);
		}

		public void RemoveRing()
		{
			rings.RemoveAt(rings.Count - 1);
		}

		public int TopRing()
		{
			return rings[rings.Count - 1];
		}

		public void ShowPeg(int x, int y)
		{
			string blankPegFigure = "|";
			for (int i = 1; i < height; i++)
			{
				if (rings.Count >= i)
				{
					Console.SetCursorPosition(x - rings[i - 1], y - i);
					switch (rings[i - 1])
					{
						case 1:
							Console.ForegroundColor = ConsoleColor.Red;
							break;
						case 2:
							Console.ForegroundColor = ConsoleColor.Yellow;
							break;
						case 3:
							Console.ForegroundColor = ConsoleColor.Green;
							break;
						case 4:
							Console.ForegroundColor = ConsoleColor.Blue;
							break;
						case 5:
							Console.ForegroundColor = ConsoleColor.Magenta;
							break;
						case 6:
							Console.ForegroundColor = ConsoleColor.DarkYellow;
							break;
						case 7:
							Console.ForegroundColor = ConsoleColor.Cyan;
							break;
						case 8:
							Console.ForegroundColor = ConsoleColor.DarkGray;
							break;
						case 9:
							Console.ForegroundColor = ConsoleColor.DarkGreen;
							break;
						case 10:
							Console.ForegroundColor = ConsoleColor.White;
							break;
						default:
							break;
					}
					Console.WriteLine(new string('x', rings[i - 1]) + "|" + new string('x', rings[i - 1]));
					Console.ResetColor();
				}
				else
				{
					Console.SetCursorPosition(x, y - i);
					Console.WriteLine(blankPegFigure);
				}
			}
		}
	}
}