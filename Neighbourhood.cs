namespace ega_lab2;

public sealed class Neighbourhood
{
	private BinaryCoding _pivot;
	private BinaryCoding? _previousPivot;
	private int _lastVisitedIndex;

	public Neighbourhood(BinaryCoding pivot, BinaryCoding? previousPivot = null)
	{
		_pivot = pivot;
		_previousPivot = previousPivot;
		_lastVisitedIndex = -1;
	}

	public BinaryCoding Pivot
	{
		set
		{
			_previousPivot = _pivot;
			_pivot = value;
			_lastVisitedIndex = -1;
		}
	}

	public BinaryCoding? Next() // sequential
	{
		if (_lastVisitedIndex + 1 == _pivot.Length) return null;

		BinaryCoding next;
		do
		{
			_lastVisitedIndex++;
			next = _pivot.InvertNthBit(_lastVisitedIndex);
		} while (_previousPivot is not null && next.Value == _previousPivot.Value);

		return next;
	}
}

// public interface INextNeighbourStrategy {
// 	public BinaryCoding? Next();
// }

// public sealed class RandomNextNeighbourStrategy : INextNeighbourStrategy {}

// public sealed class SequentialNextNeighbourStrategy : INextNeighbourStrategy {
// 	private Neighbourhood _neighbourhood;
// 	private int _currentIndex;
//
// 	public SequentialNextNeighbourStrategy(Neighbourhood neighbourhood)
// 	{
// 		_neighbourhood = neighbourhood;
// 		_currentIndex = 0;
// 	}
//
// 	public BinaryCoding? Next()
// 	{
// 		if (_currentIndex >= _neighbourhood.Pivot.Length) {
// 			return null;
// 		}
//
// 		var next = _neighbourhood.Pivot.Clone();
// 		next[_currentIndex] = !next[_currentIndex];
// 		_currentIndex++;
//
// 		return next;
// 	}
// }
