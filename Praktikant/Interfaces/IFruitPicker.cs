using System.Collections.Generic;
using FruitMachine.Models;

namespace FruitMachine.Interfaces {
	public interface IFruitPicker {
		KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match);
	}
}
