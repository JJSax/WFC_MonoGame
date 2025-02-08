using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Graphics;

namespace Basic;

public readonly struct ImageQuad
{
	public const int imageQuadSize = 32;
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

		if (flipEffect == SpriteEffects.FlipHorizontally)
		{
			string cache = newConnections[1];
			newConnections[0] = Utils.Reverse(newConnections[0]);
			newConnections[1] = Utils.Reverse(newConnections[3]);
			newConnections[2] = Utils.Reverse(newConnections[2]);
			newConnections[3] = Utils.Reverse(cache);
		}
		else if (flipEffect == SpriteEffects.FlipVertically)
		{
			string cache = newConnections[0];
			newConnections[0] = Utils.Reverse(newConnections[2]);
			newConnections[1] = Utils.Reverse(newConnections[1]);
			newConnections[2] = Utils.Reverse(cache);
			newConnections[3] = Utils.Reverse(newConnections[3]);
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

		Tiles.Add(new ImageQuad(imagePosition, connections, flipEffect: SpriteEffects.FlipHorizontally));
		Tiles.Add(new ImageQuad(imagePosition, connections, flipEffect: SpriteEffects.FlipVertically));
		// Tiles.Add(new ImageQuad(imagePosition, connections, rotationBy90: 1));
	}


}
