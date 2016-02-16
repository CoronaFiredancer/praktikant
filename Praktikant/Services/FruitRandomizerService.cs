using System;
using System.Collections.Generic;
using FruitMachine.Interfaces;
using FruitMachine.Models;

namespace FruitMachine.Services {
	public class FruitRandomizerService : IFruitProvider {

		public IEnumerable<Fruit> Provide(int howMany) {
			var random = new Random();
			var fruitArray = Enum.GetValues(typeof(FruitType));
			var colorArray = Enum.GetValues(typeof(FruitColor));

			for (var i = 0; i < howMany; i++) {
				var fruit = new Fruit(
					(FruitType)fruitArray.GetValue(random.Next(1, fruitArray.Length)),
					(FruitColor)fruitArray.GetValue(random.Next(1, colorArray.Length)),
					random.Next(50, 500));

				yield return fruit;
			}
		}
	}
}
