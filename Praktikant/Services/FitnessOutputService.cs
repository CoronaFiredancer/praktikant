using System;
using FruitMachine.Interfaces;
using FruitMachine.Models;

namespace FruitMachine.Services {
	public class FitnessOutputService : IOutputService {

		public void PrintResult(Fruit fruit, float fitness) {
			Console.WriteLine("This came close: ");
			Console.WriteLine(fruit);
			Console.WriteLine("With a fitness of " + fitness);
		}
	}
}
