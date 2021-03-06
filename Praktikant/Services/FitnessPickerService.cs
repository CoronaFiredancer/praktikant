﻿using System;
using System.Collections.Generic;
using System.Linq;
using FruitMachine.Models;
using FruitMachine.Services.Interfaces;

namespace FruitMachine.Services {
	public class FitnessPickerService : SuperPicker, IFruitPicker {
		private const float TypeFit = 0.7f;
		private const float ColorFit = 0.2f;
		private const float WeightFit = 0.1f;

		public FitnessPickerService(IDbHandler dbHandler) : base(dbHandler)
		{
		}

		/// <summary>
		/// Matches existing fruit objects against list of criteria
		/// Match priority: Type 70%, Color 20%, Weight 10% 
		/// </summary>
		/// <param name="fruits">Collection of Fruit objects to test against</param>
		/// <param name="match">Fruit object with the exact criteria to match</param>
		/// <returns></returns>
		public KeyValuePair<Fruit, float> PickFruit(IEnumerable<Fruit> fruits, Fruit match) {

			return CalculateFitness(fruits, match);
		}

		private KeyValuePair<Fruit, float> CalculateFitness(IEnumerable<Fruit> fruits, Fruit match) {
			var bestFitness = 0.0f;
			var mostFitFruit = new Fruit();

			foreach (var fruit in fruits) {
				
				var fitness = 0.0f;
				if (fruit.Type == match.Type) {
					fitness += TypeFit;
				}
				if (fruit.Color == match.Color) {
					fitness += ColorFit;
				}
				else {
					fitness += WeightFit;
				}

				var c = PercentDeviation(match.Weight, fruit.Weight);
				fitness += (1 - c) * WeightFit;

				if (!(fitness > bestFitness)) continue;

				bestFitness = fitness;
				mostFitFruit = fruit;
			}

			RemoveFromSupply(mostFitFruit);

			return new KeyValuePair<Fruit, float>(mostFitFruit, bestFitness * 100);
		}

		private static float PercentDeviation(int target, int observation) {
			var c = Math.Abs(observation - target) / (float) observation;
			return c;
		}
	}
}
