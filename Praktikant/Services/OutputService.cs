using System;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services {
	public class OutputService : IOutputService {
		private readonly IDbHandler _dbHandler;

		public OutputService(IDbHandler dbHandler)
		{
			_dbHandler = dbHandler;
		}

		public void PrintResult(Fruit fruit, float fitness) {
			Console.WriteLine("This came close: ");
			Console.WriteLine(fruit);
			Console.WriteLine("With a fitness of " + fitness);
		}

		public void PrintAvailable()
		{
			using (var dbContext = _dbHandler as FruitMachineDbContext)
			{
				if (dbContext != null)
				{
					var available = dbContext.Fruits;

					foreach (var fruit in available)
					{
						Console.WriteLine(fruit);
					}
				}
			}
		}
	}
}
