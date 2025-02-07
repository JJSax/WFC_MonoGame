using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace Basic;

public readonly struct ImageQuad
{
	private const int imageQuadSize = 15;
	public readonly SpriteEffects Flip { get; }
	public readonly float Rotation { get; }
	public int X { get; }
	public int Y { get; }
	public string[] Connections { get; }
	public Rectangle Quad { get; }

	public ImageQuad(Point imgPosition, string[] originalConnections, SpriteEffects flipEffect = SpriteEffects.None, sbyte rotationBy90 = 0)
	{
		X = imgPosition.X;
		Y = imgPosition.Y;

		Flip = flipEffect;

		if (rotationBy90 > 3) throw new ArgumentException("Attempt to rotate beyond limits");

		Rotation = rotationBy90 * (float)Math.PI / 2;
		string[] newConnections = new string[4];
		int currentConnectionsIndex = 0;
		for (int i = 4 - rotationBy90; i < 4; i++)
		{
			newConnections[currentConnectionsIndex] = originalConnections[i];
			currentConnectionsIndex++;
		}
		for (int i = 0; i < 4 - rotationBy90; i++)
		{
			newConnections[currentConnectionsIndex] = originalConnections[i];
			currentConnectionsIndex++;
		}

		Connections = newConnections;
		Quad = new Rectangle(X * imageQuadSize, Y * imageQuadSize, imageQuadSize, imageQuadSize);
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
	// public static Dictionary<Point, int> LocationMap { get; private set; } = [];

	/// <summary>
	///
	/// </summary>
	/// <param name="tx"></param>
	/// <param name="ty"></param>
	/// <param name="connections">Top - Right - Bottom - Left</param>
	/// <returns></returns>
	public static void New(Point imagePosition, string[] connections)
	{

		// if (LocationMap.ContainsKey(imagePosition))
		// {
		// 	Debug.WriteLine("POSITION ALREADY MAPPED: " + imagePosition);
		// 	throw new InvalidOperationException("Position already mapped.");
		// }

		// LocationMap.Add(imagePosition, Tiles.Count);
		Tiles.Add(new ImageQuad(imagePosition, connections, rotationBy90: 0));
		Tiles.Add(new ImageQuad(imagePosition, connections, rotationBy90: 1));
		Tiles.Add(new ImageQuad(imagePosition, connections, rotationBy90: 2));
		Tiles.Add(new ImageQuad(imagePosition, connections, rotationBy90: 3));
	}


}
