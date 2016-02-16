using System.Data.Entity;
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
				int count;
				if (dbContext != null)
				{
					var fruits = dbContext.Fruits;
				}
			}

			//var fruits = provider.Provide(10);

			//var fruitWish = prompter.Prompt();

			//var whatYouGet = picker.PickFruit(fruits, fruitWish);

			//outputService.PrintResult(whatYouGet.Key, whatYouGet.Value);
		}
	}
}
