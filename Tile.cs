using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Basic;

/// <summary>
/// Tile in 'world', not image
/// </summary>
public class Tile
{

	public static Texture2D[] image;
	static Point center = new(ImageQuad.imageQuadSize / 2, ImageQuad.imageQuadSize / 2);

	private byte Variant { get; }
	public ImageQuad iQuad;
	public Point Position { get; private set; }
	public bool Collapsed { get; private set; } = false;
	private bool ERRORED = false;
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
		// iQuad = TileMap.Tiles[TileMap.LocationMap[new Point(x, y)]];
		Position = tilePosition;
		availableTiles = new(TileMap.Tiles);
		Variant = (byte)rand.Next(3);
	}
	public Tile(Point tilePosition) : this(0, 3, tilePosition) { }

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		Rectangle dest = new(x + center.X, y + center.Y, Game1.drawSize, Game1.drawSize);
		if (ERRORED)
		{
			spriteBatch.FillRectangle(dest, Color.Pink);
			return;
		}
		spriteBatch.Draw(image[Variant], dest, iQuad.Quad, Color.White, iQuad.Rotation, center.ToVector2(), iQuad.Flip, 0f);
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
		string otherConnection = other.iQuad.Connections[(checkingSide + 2) % 4];
		string reversed = Utils.Reverse(otherConnection);
		foreach (ImageQuad quad in Tiles)
		{
			if (reversed == quad.Connections[checkingSide]) nTiles.Add(quad);
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


	void LogTileConnections(Tile[,] tiles, Point Position, int size)
	{
		string top = (Position.Y > 0 && tiles[Position.X, Position.Y - 1].Collapsed)
			? $"TOP<{tiles[Position.X, Position.Y - 1].iQuad.Connections[0]}> " : "TOP<NA> ";

		string right = (Position.X < size - 1 && tiles[Position.X + 1, Position.Y].Collapsed)
			? $"RIGHT<{tiles[Position.X + 1, Position.Y].iQuad.Connections[1]}> " : "RIGHT<NA> ";

		string bottom = (Position.Y < size - 1 && tiles[Position.X, Position.Y + 1].Collapsed)
			? $"BOTTOM<{tiles[Position.X, Position.Y + 1].iQuad.Connections[2]}> " : "BOTTOM<NA> ";

		string left = (Position.X > 0 && tiles[Position.X - 1, Position.Y].Collapsed)
			? $"LEFT<{tiles[Position.X - 1, Position.Y].iQuad.Connections[3]}> " : "LEFT<NA> ";

		Debug.WriteLine($"{top}{right}{bottom}{left}");
	}
	public void Collapse(Tile[,] tiles)
	{
		Collapsed = true;
		// Debug.Write(Position);
		if (availableTiles.Count == 0)
		{

			Debug.Write(Position);
			ERRORED = true;
			Debug.Write("MISSING: ");
			LogTileConnections(tiles, Position, Game1.size);
			return; //! When there is no valid texture
		}
		ImageQuad choice = availableTiles[rand.Next(availableTiles.Count)];
		SetTile(choice);

		if (Position.Y > 0) tiles[Position.X, Position.Y - 1].Reduce(tiles);
		if (Position.X < Game1.size - 1) tiles[Position.X + 1, Position.Y].Reduce(tiles);
		if (Position.Y < Game1.size - 1) tiles[Position.X, Position.Y + 1].Reduce(tiles);
		if (Position.X > 0) tiles[Position.X - 1, Position.Y].Reduce(tiles);
	}

	public void SetTile(ImageQuad to) => iQuad = to;

}
