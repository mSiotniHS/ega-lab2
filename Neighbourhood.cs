using System.Collections.Generic;
using System.Linq;

namespace ega_lab2;

public sealed class Neighbourhood
{
	private readonly BinaryCoding _pivot;

	public Neighbourhood(BinaryCoding pivot)
	{
		_pivot = pivot;
	}

	private BinaryCoding GetNthNeighbour(int n)
	{
		return _pivot.InvertNthBit(n);
	}

	public IEnumerable<BinaryCoding> GetSequentially()
	{
		for (var i = 0; i < _pivot.Length; i++)
		{
			yield return GetNthNeighbour(i);
		}
	}

	public IEnumerable<BinaryCoding> GetRandomly()
	{
		return GetSequentially().OrderBy(_ => Utilities.GetRandom());
	}
}
