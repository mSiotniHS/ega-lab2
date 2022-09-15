namespace ega_lab2;

public sealed class NaturalFitnessCalculator: IFitnessCalculator<BinaryCoding, int>
{
	public int Calculate(BinaryCoding preimage)
	{
		return preimage.Value;
	}
}
