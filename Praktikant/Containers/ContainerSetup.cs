using System.Data.Entity;
using Autofac;
using FruitMachine.Models;
using FruitMachine.Services;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Containers {
	public class ContainerSetup {

		private ContainerBuilder _builder;

		public IContainer BuildContainer() {
			_builder = new ContainerBuilder();

			_builder.RegisterType<FruitRandomizerService>().As<IFruitProvider>();
			_builder.RegisterType<FruitPrompterService>().As<IFruitPrompter>();
			_builder.RegisterType<FitnessPickerService>().As<IFruitPicker>();
			//_builder.RegisterType<ExactPickerService>().As<IFruitPicker>(); //NO! last registered will win
			_builder.RegisterType<OutputService>().As<IOutputService>();
			_builder.RegisterType<FruitMachineDbContext>().As<IDbHandler>();
			_builder.RegisterType<FruitMixer>();

			return _builder.Build();
		}
	}
}
