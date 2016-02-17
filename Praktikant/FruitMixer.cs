using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine {
	public  class FruitMixer {

		private readonly IFruitProvider provider;
		private readonly IFruitPrompter prompter;
		private readonly IFruitPicker picker;
		private readonly IOutputService outputService;
		private readonly IDbHandler _dbHandler;

		public FruitMixer(IFruitProvider provider, IFruitPrompter prompter, IFruitPicker picker, IOutputService outputService, IDbHandler dbHandler) {
			this.provider = provider;
			this.prompter = prompter;
			this.picker = picker;
			this.outputService = outputService;
			_dbHandler = dbHandler;
		}

		public void Run()
		{

			List<Fruit> fruits;

			using (var dbContext = _dbHandler as FruitMachineDbContext)
			{
				var dbFruits = dbContext?.Fruits;

				if (dbFruits?.Count() < 10)
				{
					var provided = provider.Provide(10);

					dbFruits.AddRange(provided);
					dbContext.SaveChanges();

					dbFruits = dbContext.Fruits;
				}

				fruits = dbFruits?.ToList();
			}

			outputService.PrintAvailable();

			var fruitWish = prompter.Prompt();

			var whatYouGet = picker.PickFruit(fruits, fruitWish);

			//outputService.PrintResult(whatYouGet.Key, whatYouGet.Value);
		}
	}
}
