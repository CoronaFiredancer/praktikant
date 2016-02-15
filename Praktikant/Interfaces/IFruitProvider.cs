using System.Collections.Generic;
using Praktikant.Models;

namespace Praktikant.Interfaces {
	public interface IFruitProvider {
		IEnumerable<Fruit> Provide(int howMany);
	}
}
