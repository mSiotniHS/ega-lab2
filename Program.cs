using System;

namespace ega_lab2;

internal static class Program
{
	private static void Main()
	{
		var domain = new SearchDomain(5);

		DomainTestDrive(domain);

		var (word, fitness) = HillClimbingMethod.FindSolution(domain, 20);
		Console.WriteLine($"\nНайденное решение: {word} ({fitness})");
	}

	private static void DomainTestDrive(SearchDomain domain)
	{
		for (var i = 0; i < 32; i++)
		{
			var word = domain.PickRandomWord();
			var fitness = domain.CalculateFitness(word);

			Console.WriteLine($"{word} ({fitness})");
		}
	}
}
