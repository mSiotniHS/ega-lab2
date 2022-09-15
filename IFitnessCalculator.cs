namespace ega_lab2;

public interface IFitnessCalculator<TPreimage, TImage>
{
	public TImage Calculate(TPreimage preimage);
}
