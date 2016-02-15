using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktikant.Models
{
	public class FruitMachineDataContext : DbContext, IDbHandler
	{
		public DbSet<Fruit> Fruits { get; set; }

		public int RecordCount(string tableName)
		{
			throw new NotImplementedException();
		}
	}
}
