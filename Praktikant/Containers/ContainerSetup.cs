using System.Data.Entity;
using Autofac;
using FruitMachine.Models;
using FruitMachine.Services;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Containers {
	public class ContainerSetup {

		private ContainerBuilder builder;

		public IContainer BuildContainer() {
			builder = new ContainerBuilder();

			builder.RegisterType<FruitRandomizerService>().As<IFruitProvider>();
			builder.RegisterType<FruitPrompterService>().As<IFruitPrompter>();
			builder.RegisterType<FruitPickerService>().As<IFruitPicker>();
			builder.RegisterType<FitnessOutputService>().As<IOutputService>();
			builder.RegisterType<FruitMachineDbContext>().As<IDbHandler>();
			builder.RegisterType<FruitMixer>();

			return builder.Build();
		}
	}
}
