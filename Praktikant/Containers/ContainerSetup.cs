using Autofac;
using Praktikant.Interfaces;
using Praktikant.Services;

namespace Praktikant.Containers {
	public class ContainerSetup {

		private ContainerBuilder builder;

		public IContainer BuildContainer() {
			builder = new ContainerBuilder();

			builder.RegisterType<FruitRandomizerService>().As<IFruitProvider>();
			builder.RegisterType<FruitPrompterService>().As<IFruitPrompter>();
			builder.RegisterType<FruitPickerService>().As<IFruitPicker>();
			builder.RegisterType<FitnessOutputService>().As<IOutputService>();
			builder.RegisterType<FruitMixer>();

			return builder.Build();
		}
	}
}
