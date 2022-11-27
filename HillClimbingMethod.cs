using System;
using System.Linq;

namespace ega_lab2;

public static class HillClimbingMethod
{
	public static (BinaryCoding, int) FindSolution(SearchDomain domain, uint iterationCount)
	{
		var bestCoding = domain.PickRandom();
		var bestFitness = domain.CalculateFitness(bestCoding);

		var neighbourhood = new Neighbourhood(bestCoding);
		var neighbours = neighbourhood.GetRandomly().ToList();

		for (var i = 0; i < iterationCount; i++)
		{
			if (neighbours.Count == 0) break;

			Console.WriteLine($"\nИтерация №{i + 1}  |  Лучшая кодировка: {bestCoding} ({bestFitness})");
			Console.WriteLine("> Оставшиеся соседи лучшей кодировки:");
			foreach (var neighbour in neighbours)
			{
				Console.WriteLine($"> {neighbour} ({domain.CalculateFitness(neighbour)})");
			}

			var word = neighbours.First();
			var fitness = domain.CalculateFitness(word);
			Console.WriteLine($">\n> Отобранный кандидат: {word} ({fitness})");

			if (fitness > bestFitness)
			{
				bestFitness = fitness;
				bestCoding = word;

				neighbourhood = new Neighbourhood(bestCoding);
				neighbours = neighbourhood.GetRandomly().ToList();

				Console.WriteLine("> (!) Рассматриваемая приспособленность лучше имеющейся, обновляем");
			}
			else
			{
				Console.WriteLine("> Рассматриваемая приспособленность не лучше имеющейся, пропускаем");
				neighbours.RemoveAt(0);
			}
		}

		return (bestCoding, bestFitness);
	}
}
