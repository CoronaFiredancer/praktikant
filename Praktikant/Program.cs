using System;
using Autofac;
using FruitMachine.Containers;
using FruitMachine.Services;
using FruitMachine.Services.Interfaces;

namespace FruitMachine
{
	public class Program
	{
		public static void Main(string[] args)
		{

			/*
			 * This is tightly coupled, we can do better
			var provider = new FruitRandomizerService();
		    var prompter = new FruitPrompterService();
		    var picker = new FitnessPickerService();
			var resultWriter = new OutputService();
			
			var mixer = new FruitMixer(provider, prompter, picker, resultWriter);
		    
			mixer.Run();
			 * */

			var containerSetup = new ContainerSetup();
			var container = containerSetup.BuildContainer();
			container.Resolve<FruitMixer>().Run();

			var updater = new ContainerBuilder();
			updater.RegisterType<ExactPickerService>().As<IFruitPicker>();
			updater.Update(container);

			container.Resolve<FruitMixer>().Run();

			Console.ReadLine();
		}
	}
}
