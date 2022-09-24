using System;

namespace ega_lab2;

public static class Utilities
{
	private static readonly Random Random = new();

	public static int GetRandom() => Random.Next();
	public static int GetRandom(int max) => Random.Next(max);
}
