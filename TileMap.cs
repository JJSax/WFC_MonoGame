using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
	public Texture2D[] Images { get; }

	public ImageQuad(Point imgPosition, Texture2D[] images, string[] originalConnections, SpriteEffects flipEffect = SpriteEffects.None, sbyte rotationBy90 = 0)
	{
		X = imgPosition.X;
		Y = imgPosition.Y;

		Images = images;

		Flip = flipEffect;

		if (rotationBy90 > 3) throw new ArgumentException("Attempt to rotate beyond limits");

		Rotation = rotationBy90 * (float)Math.PI / 2;
		string[] newConnections = new string[4];
		int currentConnectionsIndex = 0;
		int adjRotation = rotationBy90 > 0 && flipEffect != SpriteEffects.None ? rotationBy90 + 2 : rotationBy90;
		for (int i = 4 - adjRotation; i < 4; i++)
		{
			newConnections[currentConnectionsIndex] = originalConnections[i];
			currentConnectionsIndex++;
		}
		for (int i = 0; i < 4 - adjRotation; i++)
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
	/// <param name="imagePosition"></param>
	/// <param name="textures"></param>
	/// <param name="connections">Top - Right - Bottom - Left Clockwise</param>
	public static void New(Point imagePosition, Texture2D[] textures, string[] connections)
	{
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 0));
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 1));
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 2));
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 3));

		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 0, flipEffect: SpriteEffects.FlipHorizontally));
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 1, flipEffect: SpriteEffects.FlipHorizontally));

		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 0, flipEffect: SpriteEffects.FlipVertically));
		Tiles.Add(new ImageQuad(imagePosition, textures, connections, rotationBy90: 1, flipEffect: SpriteEffects.FlipVertically));
	}

}
