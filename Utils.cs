using System;

namespace Basic;

public static class Utils
{
	public static string Reverse(string input)
	{
		char[] charArray = input.ToCharArray();
		Array.Reverse(charArray);
		return new(charArray);
	}
}
