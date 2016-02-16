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

		public void Run() {

			using (var dbContext = _dbHandler as FruitMachineDbContext)
			{
				var fruits = dbContext?.Fruits;

				if (fruits?.Count() < 10)
				{
					var provided = provider.Provide(10);

					fruits.AddRange(provided);
				}
			}

			

			//var fruitWish = prompter.Prompt();

			//var whatYouGet = picker.PickFruit(fruits, fruitWish);

			//outputService.PrintResult(whatYouGet.Key, whatYouGet.Value);
		}
	}
}
