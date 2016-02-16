using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using FruitMachine.Models;
using FruitMachine.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitMachineTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void FruitCountIsZero()
		{
			int count;
			using (var dbcontext = new FruitMachineDbContext())
			{
				var fruits = dbcontext.Fruits;

				count = fruits.Count();
			}

			Assert.AreEqual(0, count);

		}

		[TestMethod]
		public void AddIfLessThanTen()
		{
			int count;
			const int amountToAdd = 10;
			List<Fruit> fakeDb;
			using (var dbcontext = new FruitMachineDbContext())
			{
				var fruits = dbcontext.Fruits;
				fakeDb = fruits.ToList();

				count = fruits.Count();
				if (count < 10)
				{
					var provider = new FruitRandomizerService();
					var provided = provider.Provide(amountToAdd);
					
					fakeDb.AddRange(provided);

					
				}
			}

			Assert.AreEqual(count + amountToAdd, fakeDb.Count);
		}
	}
}
