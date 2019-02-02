using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TowersOfHanoi_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Towers of Hanoi";
			bool keepRunning = false;
			do
			{
				Console.WriteLine();
				Console.WriteLine("The goal of this game is to move all the rings to the second peg... Good Luck!");
				Game();
				Console.Write("Do you want to play again(y/n):");
				string input = Console.ReadLine();
				if (input.Contains('y'))
				{
					keepRunning = true;
					Console.Clear();
				}
			} while (keepRunning == true);
			Console.WriteLine("Press any key to end...");
			Console.ReadKey();
		}

		static void Game()
		{
			Console.Write("How many rings do you want: ");
			int startRings = 0;
			try
			{
				startRings = Convert.ToInt16(Console.ReadLine());
			}
			catch
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Not a valid input...");
				Console.ResetColor();
				Console.Write("How many rings do you want: ");
				startRings = Convert.ToInt16(Console.ReadLine());
			}

			int pegHeight = startRings + 5;
			Peg peg1 = new Peg(pegHeight);
			Peg peg2 = new Peg(pegHeight);
			Peg peg3 = new Peg(pegHeight);
			BeginGame(startRings, peg1, peg2, peg3);

			int movesMade = 0;
			bool gameOver = false;
			while (gameOver == false)
			{
				Console.Write("Move from which peg to which peg (Ex: 1,3):");
				Peg from = new Peg(pegHeight);
				Peg to = new Peg(pegHeight);
				string[] moveInput = Console.ReadLine().Split(',');
				switch (moveInput[0])
				{
					case "1":
						from = peg1;
						break;
					case "2":
						from = peg2;
						break;
					case "3":
						from = peg3;
						break;
				}

				switch (moveInput[1])
				{
					case "1":
						to = peg1;
						break;
					case "2":
						to = peg2;
						break;
					case "3":
						to = peg3;
						break;
				}

				if (from.rings.Count() != 0)
				{
					if (to.rings.Count != 0 && from.TopRing() > to.TopRing())
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine($"The ring on Peg {moveInput[0]} is larger then the ring on Peg {moveInput[1]}...");
						Console.ResetColor();
					}
					else
					{
						ChangeRing(from, to);
						movesMade++;
						Console.Clear();
						ShowUpdatedBoard(peg1, peg2, peg3, movesMade);
						gameOver = GameOver(peg2, startRings);
					}
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine($"Did you see a ring on Peg {moveInput[0]}???");
					Console.ResetColor();
				}
			}
			int x = Console.CursorTop;
			Console.WriteLine("You have won!");
			Console.WriteLine("You used a total of " + movesMade + " moves.");

		}

		static void BeginGame(int rings, Peg peg1, Peg peg2, Peg peg3)
		{
			for (int i = rings; i > 0; i--)
			{
				peg1.AddRing(i);
			}
			int baseLine = 15;
			peg1.ShowPeg(40, baseLine);
			peg2.ShowPeg(60, baseLine);
			peg3.ShowPeg(80, baseLine);
			Console.SetCursorPosition(25, baseLine);
			Console.WriteLine("--------------------------------------------------------------------");
		}

		static void ShowUpdatedBoard(Peg peg1, Peg peg2, Peg peg3, int movesMade)
		{
			Console.Clear();
			int baseLine = 15;
			peg1.ShowPeg(40, baseLine);
			peg2.ShowPeg(60, baseLine);
			peg3.ShowPeg(80, baseLine);
			Console.SetCursorPosition(25, baseLine);
			Console.WriteLine("--------------------------------------------------------------------");
			Console.SetCursorPosition(80, baseLine + 2);
			Console.WriteLine("Moves: " + movesMade);
		}

		static void ChangeRing(Peg peg1, Peg peg2)
		{
			int ringWidth = peg1.TopRing();
			peg1.RemoveRing();
			peg2.AddRing(ringWidth);
		}

		static bool GameOver(Peg gameOverPeg, int amountOfRings)
		{
			if (gameOverPeg.rings.Count() == amountOfRings) 
			{
				return true;
			}
			else return false;
		}
	}
}
