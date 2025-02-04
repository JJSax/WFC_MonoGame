using System;

namespace Basic;

//todo I don't actually think this is helpful.  Maybe just use strings
public class Side
{
	public string Connections { get; private set; }
	public Side(string connect)
	{
		Connections = connect;
	}

	public Side(char connect)
	{
		Connections = connect.ToString();
	}
}
