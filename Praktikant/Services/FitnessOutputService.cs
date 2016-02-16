using System;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services {
	public class FitnessOutputService : IOutputService {

		public void PrintResult(Fruit fruit, float fitness) {
			Console.WriteLine("This came close: ");
			Console.WriteLine(fruit);
			Console.WriteLine("With a fitness of " + fitness);
		}
	}
}
