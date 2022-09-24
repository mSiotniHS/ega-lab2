using System;

namespace ega_lab2;

public record BinaryCoding
{
	public int Length { get; }
	public int Value { get; }

	public BinaryCoding(int value, int? length)
	{
		Value = value;
		Length = length ?? Convert.ToInt32(Math.Ceiling(Math.Log(value, 2)));
	}

	// public BinaryCoding(string binary, int? length)
	// {
	// 	Value = Convert.ToInt32(binary, 2);
	// 	Length = length ?? binary.Length;
	// }

	public override string ToString()
	{
		return Convert.ToString(Value, 2).PadLeft(Length, '0');
	}

	public BinaryCoding InvertNthBit(int n)
	{
		if (n < 0 || n >= Length) throw new ArgumentOutOfRangeException(nameof(n));

		return GetNthBit(n) ?
			new BinaryCoding(Value & ~(1 << n), Length) :
			new BinaryCoding(Value ^ (1 << n), Length);
	}

	private bool GetNthBit(int n)
	{
		return (Value & (1 << n)) != 0;
	}
}
