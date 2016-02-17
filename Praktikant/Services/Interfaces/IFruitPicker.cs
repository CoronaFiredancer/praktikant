using System.Collections.Generic;
using FruitMachine.Models;

namespace FruitMachine.Services.Interfaces {
	public interface IFruitPicker {
		KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match);
		//void RemoveFromSupply(Fruit match);
	}
}
