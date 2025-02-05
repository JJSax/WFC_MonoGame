using System;
using System.Collections.Generic;
using System.Diagnostics;
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
	public Point Position { get; private set; }
	public bool Collapsed { get; private set; } = false;
	public List<ImageQuad> availableTiles;

	private static Random rand = new();

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
		availableTiles = new(TileMap.Tiles);
	}
	public Tile(Point tilePosition) : this(0, 3, tilePosition) { }

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
		if (Position.X + ox >= Game1.size) return Tiles;
		if (Position.Y + oy >= Game1.size) return Tiles;
		Tile other = tiles[Position.X + ox, Position.Y + oy];
		if (!other.Collapsed) return Tiles;

		List<ImageQuad> nTiles = [];
		string otherConnection = other.TileConnections.Connections[(checkingSide + 2) % 4];
		foreach (ImageQuad quad in Tiles)
		{
			if (otherConnection == quad.Connections[checkingSide]) nTiles.Add(quad);
		}
		return nTiles;
	}

	public void Reduce(Tile[,] tiles) // for current tile
	{
		//top
		availableTiles = SideReduction(tiles, availableTiles, 0, -1, 0);
		//right
		availableTiles = SideReduction(tiles, availableTiles, 1, 0, 1);
		//bottom
		availableTiles = SideReduction(tiles, availableTiles, 0, 1, 2);
		//left
		availableTiles = SideReduction(tiles, availableTiles, -1, 0, 3);
	}

	public void Collapse(Tile[,] tiles)
	{
		Collapsed = true;
		Debug.Write(Position);
		if (availableTiles.Count == 0)
			return; //! When there is no valid texture
		ImageQuad choice = availableTiles[rand.Next(availableTiles.Count)];
		Debug.Write(" : ");
		Debug.WriteLine(choice.X + " " + choice.Y);
		SetTile(choice);

		if (Position.Y > 0) tiles[Position.X, Position.Y - 1].Reduce(tiles);
		if (Position.X < Game1.size - 1) tiles[Position.X + 1, Position.Y].Reduce(tiles);
		if (Position.Y < Game1.size - 1) tiles[Position.X, Position.Y + 1].Reduce(tiles);
		if (Position.X > 0) tiles[Position.X - 1, Position.Y].Reduce(tiles);
	}

	public void SetTile(ImageQuad to)
	{
		TileConnections = to;
		quad = Quad(to.X, to.Y);
	}

}
