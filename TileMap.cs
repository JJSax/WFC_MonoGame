using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Basic;


public struct ImageQuad
{
	public int X { get; }
	public int Y { get; }
	public string[] Connections { get; }

	public ImageQuad(Point imgPosition, string[] connections)
	{
		X = imgPosition.X;
		Y = imgPosition.Y;
		Connections = connections;
	}
}

/// <summary>
///
/// </summary>
/// <param name="x"></param>
/// <param name="y"></param>
/// <param name="connections"></param>
public static class TileMap
{
	public static List<ImageQuad> Tiles { get; private set; } = [];
	public static Dictionary<Point, int> LocationMap { get; private set; } = [];

	/// <summary>
	///
	/// </summary>
	/// <param name="tx"></param>
	/// <param name="ty"></param>
	/// <param name="connections">Top - Right - Bottom - Left</param>
	/// <returns></returns>
	public static int New(Point imagePosition, string[] connections)
	{

		if (LocationMap.ContainsKey(imagePosition))
			throw new InvalidOperationException("Position already mapped.");

		LocationMap.Add(imagePosition, Tiles.Count);
		Tiles.Add(new ImageQuad(imagePosition, connections));
		return Tiles.Count;

	}


}
