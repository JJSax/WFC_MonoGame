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
	private readonly SpriteEffects flip;
	private readonly float rotation;
	public int X { get; }
	public int Y { get; }
	public string[] Connections { get; }
	public Rectangle Quad { get; }

	public ImageQuad(Point imgPosition, string[] originalConnections, SpriteEffects flipEffect = SpriteEffects.None, sbyte rotationBy90 = 0)
	{
		X = imgPosition.X;
		Y = imgPosition.Y;

		flip = flipEffect;

		if (rotationBy90 > 3) throw new ArgumentException("Attempt to rotate beyond limits");

		rotation = rotationBy90 * (float)Math.PI / 2;

		Connections = originalConnections;
		Quad = new Rectangle(X * imageQuadSize, Y * imageQuadSize, imageQuadSize, imageQuadSize);
	}

	public void Draw(SpriteBatch _spriteBatch, Rectangle dest)
	{
		_spriteBatch.Draw(Tile.image, dest, Quad, Color.White, rotation, Vector2.Zero, flip, 0f);
		// _spriteBatch.Draw(Tile.image, new Rectangle(0, 0, 30, 30), new Rectangle(0, 0, 15, 15), Color.White, 0f, Vector2.Zero, SpriteEffects.FlipHorizontally, 0f);
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
	public static int New(Point imagePosition, string[] connections, SpriteEffects flip = SpriteEffects.None, sbyte rotationBy90 = 0)
	{

		if (LocationMap.ContainsKey(imagePosition))
		{
			Debug.WriteLine("POSITION ALREADY MAPPED: " + imagePosition);
			throw new InvalidOperationException("Position already mapped.");
		}

		LocationMap.Add(imagePosition, Tiles.Count);
		Tiles.Add(new ImageQuad(imagePosition, connections, flip, rotationBy90));
		return Tiles.Count;

	}


}
