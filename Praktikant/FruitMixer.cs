using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine {
	public  class FruitMixer {

		private readonly IFruitProvider _provider;
		private readonly IFruitPrompter _prompter;
		private readonly IFruitPicker _picker;
		private readonly IOutputService _outputService;
		private readonly IDbHandler _dbHandler;

		public FruitMixer(IFruitProvider provider, IFruitPrompter prompter, IFruitPicker picker, IOutputService outputService, IDbHandler dbHandler) {
			_provider = provider;
			_prompter = prompter;
			_picker = picker;
			_outputService = outputService;
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
					var provided = _provider.Provide(10);

					dbFruits.AddRange(provided);
					dbContext.SaveChanges();

					dbFruits = dbContext.Fruits;
				}

				fruits = dbFruits?.ToList();
			}

			_outputService.PrintAvailable();

			var fruitWish = _prompter.Prompt();

			var whatYouGet = _picker.PickFruit(fruits, fruitWish);

			_outputService.PrintResult(whatYouGet.Key, whatYouGet.Value);
		}
	}
}
