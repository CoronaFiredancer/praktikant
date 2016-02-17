using FruitMachine.Models;

namespace FruitMachine.Services.Interfaces {
	public interface IOutputService {
		void PrintResult(Fruit fruit, float fitness);
		void PrintAvailable();
	}
}
