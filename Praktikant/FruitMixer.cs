using FruitMachine.Interfaces;

namespace FruitMachine {
	public  class FruitMixer {

		private readonly IFruitProvider provider;
		private readonly IFruitPrompter prompter;
		private readonly IFruitPicker picker;
		private readonly IOutputService outputService;

		public FruitMixer(IFruitProvider provider, IFruitPrompter prompter, IFruitPicker picker, IOutputService outputService) {
			this.provider = provider;
			this.prompter = prompter;
			this.picker = picker;
			this.outputService = outputService;
		}

		public void Run() {



			var fruits = provider.Provide(100);

			var fruitWish = prompter.Prompt();

			var whatYouGet = picker.PickFruit(fruits, fruitWish);

			outputService.PrintResult(whatYouGet.Key, whatYouGet.Value);
		}
	}
}
