using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FruitMachine.Models;

namespace FruitMachine.Services
{
	public abstract class SuperPicker
	{
		private readonly IDbHandler _dbHandler;

		protected SuperPicker(IDbHandler dbHandler)
		{
			_dbHandler = dbHandler;
		}

		public void RemoveFromSupply(Fruit match)
		{
			using (var dbContext = _dbHandler as FruitMachineDbContext)
			{
				if (dbContext != null)
				{
					var result = from f in dbContext.Fruits where f.FruitId == match.FruitId select f;

					if (result.Any())
					{
						var f = result.First();
						dbContext.Fruits.Remove(f);
						dbContext.SaveChanges();
					}
				}
			}
		}
	}
}
