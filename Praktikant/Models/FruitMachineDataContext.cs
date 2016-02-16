using System;
using System.Data.Entity;

namespace FruitMachine.Models
{
	public partial class FruitMachineDataContext : DbContext, IDbHandler
	{
		public DbSet<Fruit> Fruits { get; set; }
		//public DbSet<FruitColor> FruitColors { get; set; }
		//public DbSet<FruitType> FruitTypes { get; set; } 

		public int RecordCount(string tableName)
		{
			throw new NotImplementedException();
		}
	}
}
