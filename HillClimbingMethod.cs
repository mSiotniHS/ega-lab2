using System;

namespace ega_lab2;

public static class HillClimbingMethod
{
	public static (BinaryCoding, int) FindSolution(SearchDomain domain, uint iterationCount)
	{
		var bestCoding = domain.PickRandomWord();
		var bestFitness = domain.CalculateFitness(bestCoding);

		var neighbourhood = new Neighbourhood(bestCoding);

		for (var i = 0; i < iterationCount; i++)
		{
			Console.WriteLine($"\nИтерация №{i+1}  |  \"Лучшее\" слово: {bestCoding} ({bestFitness})");

			var word = neighbourhood.Next();
			if (word is null) break;

			var fitness = domain.CalculateFitness(word);

			Console.WriteLine($"> Отобранный кандидат: {word} ({fitness})");

			if (fitness > bestFitness)
			{
				bestFitness = fitness;
				bestCoding = word;

				neighbourhood.Pivot = bestCoding;

				Console.WriteLine("> Рассматриваемая приспособленность лучше имеющейся, обновляем");
			}
			else
			{
				Console.WriteLine("> Рассматриваемая приспособленность не лучше имеющейся, пропускаем");
			}
		}

		return (bestCoding, bestFitness);
	}
}
