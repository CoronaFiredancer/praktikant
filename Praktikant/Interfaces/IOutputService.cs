using FruitMachine.Models;

namespace FruitMachine.Interfaces {
	public interface IOutputService {
		void PrintResult(Fruit fruit, float fitness);
	}
}
