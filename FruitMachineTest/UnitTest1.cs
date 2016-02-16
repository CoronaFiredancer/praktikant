using System;
using System.Linq;
using FruitMachine.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitMachineTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			int count;
			using (var dbcontext = new FruitMachineDbContext())
			{
				var fruits = dbcontext.Fruits;

				count = fruits.Count();
			}

			Assert.AreEqual(0, count);

		}
	}
}
