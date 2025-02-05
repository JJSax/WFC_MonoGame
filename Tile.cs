using System;
using System.Collections.Generic;
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
	/// <param name="tilePosition">Where the tile is</param>
	public Tile(int x, int y, Point tilePosition)
	{
		quad = new(x * tileSize, y * tileSize, tileSize, tileSize);
		TileConnections = TileMap.Tiles[TileMap.LocationMap[new Point(x, y)]];
		Position = tilePosition;
	}
	public Tile(Point tilePosition) : this(5, 0, tilePosition) { }

	public static Rectangle Quad(int x, int y) => new(x * tileSize, y * tileSize, tileSize, tileSize);

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		Rectangle dest = new(x, y, Game1.drawSize, Game1.drawSize);
		spriteBatch.Draw(image, dest, quad, Color.White);
	}


	private List<ImageQuad> SideReduction(Tile[,] tiles, List<ImageQuad> Tiles, int ox, int oy, int checkingSide)
	{
		if (Position.X + ox < 0 || Position.X + ox > Game1.size) return Tiles;
		if (Position.Y + oy < 0 || Position.Y + oy > Game1.size) return Tiles;
		Tile other = tiles[Position.X + ox, Position.Y + oy];
		if (!other.Collapsed) return Tiles;

		List<ImageQuad> nTiles = [];
		string otherConnection = other.TileConnections.Connections[checkingSide + 2 % 4];
		foreach (ImageQuad quad in Tiles)
		{
			if (otherConnection == quad.Connections[checkingSide]) nTiles.Add(quad);
		}
		return nTiles;
	}

	public List<ImageQuad> GetValidOptions(Tile[,] tiles) // for current tile
	{
		List<ImageQuad> Tiles = new(TileMap.Tiles);
		//top
		Tiles = SideReduction(tiles, Tiles, 0, -1, 0);
		//right
		Tiles = SideReduction(tiles, Tiles, 1, 0, 1);
		//bottom
		Tiles = SideReduction(tiles, Tiles, 0, 1, 2);
		//left
		Tiles = SideReduction(tiles, Tiles, -1, 0, 3);

		return Tiles;
	}

	public void SetTile(ImageQuad to)
	{
		TileConnections = to;
		quad = Quad(to.X, to.Y);
		Collapsed = true;
	}

}
