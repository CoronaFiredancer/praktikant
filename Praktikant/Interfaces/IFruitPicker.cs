using System.Collections.Generic;
using Praktikant.Models;

namespace Praktikant.Interfaces {
	public interface IFruitPicker {
		KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match);
	}
}
