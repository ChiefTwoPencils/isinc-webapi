// InputWrapper.cs
//
// Class to wrap simple stream input
// Datatype supported:
//      int
//      double
//      decimal
//      string

using System;

class InputWrapper
{
	public int getInt(string prompt)
	{
		Console.Write(prompt);
		string buf = Console.ReadLine();
		return Convert.ToInt32(buf);
	}
	public double getDouble(string prompt)
	{
		Console.Write(prompt);
		string buf = Console.ReadLine();
		return Convert.ToDouble(buf);
	}
	public decimal getDecimal(string prompt)
	{
		Console.Write(prompt);
		string buf = Console.ReadLine();
		return Convert.ToDecimal(buf);
	}
	public string getString(string prompt)
	{
		Console.Write(prompt);
		string buf = Console.ReadLine();
		return buf;
	}
}
