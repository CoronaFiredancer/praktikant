using System;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services {
	public class FruitPrompterService : IFruitPrompter{
		public Fruit Prompt() {
			Console.WriteLine("What are you looking for?");

			FruitType wishType;
			FruitColor wishColor;

			Console.Write("Fruit: ");
			var consoleInput = Console.ReadLine();
			if (string.IsNullOrEmpty(consoleInput)) {
				wishType = FruitType.None;
			}
			else {
				wishType = (FruitType)Enum.Parse(typeof(FruitType), consoleInput, true);
			}

			Console.Write("Colour: ");
			consoleInput = Console.ReadLine();
			if (string.IsNullOrEmpty(consoleInput)) {
				wishColor = FruitColor.None;
			}
			else {
				wishColor = (FruitColor)Enum.Parse(typeof(FruitColor), consoleInput, true);
			}

			Console.Write("Weight: ");
			consoleInput = Console.ReadLine();
			var wishWeight = string.IsNullOrEmpty(consoleInput) ? 0 : int.Parse(consoleInput);

			return new Fruit(wishType, wishColor, wishWeight);
		}
	}
}
