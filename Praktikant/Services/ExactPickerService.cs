using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services
{
	public class ExactPickerService : IFruitPicker
	{
		public KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match)
		{

			var picked = fruits
				.Where(x => x.Type == match.Type)
				.Where(y => y.Color == match.Color)
				.FirstOrDefault(z => z.Weight == match.Weight);

			return picked != null ? 
				new KeyValuePair<Fruit, float>(picked, 100) : 
				new KeyValuePair<Fruit, float>(null, 0);
		}
	}
}
