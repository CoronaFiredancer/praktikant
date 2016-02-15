using System;
using Praktikant.Interfaces;
using Praktikant.Models;

namespace Praktikant.Services {
	public class FruitPrompterService : IFruitPrompter{
		public Fruit Prompt() {
			Console.WriteLine("What are you looking for?");

			FruitType wishType;
			FruitColor wishColor;

			Console.Write("Fruit: ");
			var x = Console.ReadLine();
			if (string.IsNullOrEmpty(x)) {
				wishType = FruitType.None;
			}
			else {
				wishType = (FruitType)Enum.Parse(typeof(FruitType), x, true);
			}

			Console.Write("Colour: ");
			x = Console.ReadLine();
			if (string.IsNullOrEmpty(x)) {
				wishColor = FruitColor.None;
			}
			else {
				wishColor = (FruitColor)Enum.Parse(typeof(FruitColor), x, true);
			}

			Console.Write("Weight: ");
			x = Console.ReadLine();
			var wishWeight = string.IsNullOrEmpty(x) ? 0 : int.Parse(x);

			return new Fruit(wishType, wishColor, wishWeight);
		}
	}
}
