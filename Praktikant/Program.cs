using System;
using Autofac;
using FruitMachine.Containers;

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
		    var picker = new FruitPickerService();
			var resultWriter = new OutputService();
			
			var mixer = new FruitMixer(provider, prompter, picker, resultWriter);
		    
			mixer.Run();
			 * */

			var containerSetup = new ContainerSetup();
			var container = containerSetup.BuildContainer();
			container.Resolve<FruitMixer>().Run();

			Console.ReadLine();
		}
	}
}
