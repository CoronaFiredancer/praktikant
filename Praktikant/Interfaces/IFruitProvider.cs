using System.Collections.Generic;
using FruitMachine.Models;

namespace FruitMachine.Interfaces {
	public interface IFruitProvider {
		IEnumerable<Fruit> Provide(int howMany);
	}
}
