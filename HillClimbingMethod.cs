using System;

namespace ega_lab2;

public static class HillClimbingMethod
{
	public static (BinaryCoding, int) FindSolution(SearchDomain domain, uint iterationCount)
	{
		var bestCoding = domain.PickRandom();
		var bestFitness = domain.CalculateFitness(bestCoding);

		var neighbourhood = new Neighbourhood(bestCoding);
		var iterator = neighbourhood.GetRandomly().GetEnumerator();

		for (var i = 0; i < iterationCount; i++)
		{
			if (!iterator.MoveNext()) break;

			var word = iterator.Current;
			var fitness = domain.CalculateFitness(word);

			Console.WriteLine($"\nИтерация №{i+1}  |  Лучшая кодировка: {bestCoding} ({bestFitness})");
			Console.WriteLine($"> Отобранный кандидат: {word} ({fitness})");

			if (fitness > bestFitness)
			{
				bestFitness = fitness;
				bestCoding = word;

				neighbourhood = new Neighbourhood(bestCoding);
				iterator.Dispose();
				iterator = neighbourhood.GetRandomly().GetEnumerator();

				Console.WriteLine("> Рассматриваемая приспособленность лучше имеющейся, обновляем");
				Console.WriteLine("> Соседи новой лучшей кодировки:");
				foreach (var neighbour in neighbourhood.GetSequentially())
				{
					Console.WriteLine($"> {neighbour} ({domain.CalculateFitness(neighbour)})");
				}
			}
			else
			{
				Console.WriteLine("> Рассматриваемая приспособленность не лучше имеющейся, пропускаем");
			}
		}

		iterator.Dispose();

		return (bestCoding, bestFitness);
	}
}
