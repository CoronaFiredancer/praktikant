using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services
{
	public class ExactPickerService : SuperPicker, IFruitPicker
	{
		public ExactPickerService(IDbHandler dbHandler) : base(dbHandler)
		{
		}

		public KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match)
		{

			var picked =
				fruits.Where(x => x.Type == match.Type).Where(y => y.Color == match.Color).FirstOrDefault(z => z.Weight == match.Weight);

			if (picked == null) return new KeyValuePair<Fruit, float>(null, 0);

			RemoveFromSupply(picked);
			return new KeyValuePair<Fruit, float>(picked, 100);
		}
	}
}
