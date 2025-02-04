using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic;

/// <summary>
/// Tile in 'world', not image
/// </summary>
public class Tile
{

	public static Texture2D image;
	private const short tileSize = 15;


	public Rectangle quad;
	public ImageQuad TileConnections;
	private Point Position { get; set; }
	private bool Collapsed { get; set; } = false;

	/// <summary>
	///
	/// </summary>
	/// <param name="x">The location in the image</param>
	/// <param name="y">The location in the image</param>
	public Tile(int x, int y, Point tilePosition)
	{
		quad = new(x * tileSize, y * tileSize, tileSize, tileSize);
		TileConnections = TileMap.Tiles[(int)TileMap.LocationMap[new Point(x, y)]];
		Position = tilePosition;
	}
	public Tile(Point tilePosition) : this(5, 0, tilePosition) { }

	public static Rectangle Quad(int x, int y) => new(x * tileSize, y * tileSize, tileSize, tileSize);

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		Rectangle dest = new(x, y, Game1.drawSize, Game1.drawSize);
		spriteBatch.Draw(image, dest, quad, Color.White);
	}

	public List<ImageQuad> GetValidOptions(Tile[,] tiles) // for current tile
	{
		List<ImageQuad> Tiles = new(TileMap.Tiles);
		List<ImageQuad> nTiles = [];
		//top
		if (Position.Y > 0 && tiles[Position.X, Position.Y - 1] is var above && above.Collapsed)
		{
			string aboveConnection = above.TileConnections.Connections[2];
			foreach (ImageQuad quad in Tiles)
			{
				if (aboveConnection == quad.Connections[0])
				{
					nTiles.Add(quad);
				}
			}
			Tiles = nTiles;
		}
		//right
		//bottom
		//left

		return Tiles;
	}

	public void SetTile(ImageQuad to)
	{
		TileConnections = to;
		quad = Quad(to.X, to.Y);
		Collapsed = true;
	}

}
