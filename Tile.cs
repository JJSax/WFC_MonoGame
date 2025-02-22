using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;

namespace Basic;

/// <summary>
/// Tile in 'world', not image
/// </summary>
public class Tile
{
	public bool ERRORED = false;
	private static Point center = new(ImageQuad.imageQuadSize / 2, ImageQuad.imageQuadSize / 2);

	private byte Variant { get; set; }
	private Point Position { get; set; }

	//todo consider using a single master list and just store integers of index to the list. Perhaps ImageQuad should be a class (reference type)
	public List<ImageQuad> availableTiles;
	private int MaxScore { get; set; }

	public ImageQuad iQuad;
	public bool Collapsed { get; private set; } = false;

	private static Random rand = new();

	/// <param name="x">The location in the image</param>
	/// <param name="y">The location in the image</param>
	/// <param name="tilePosition">Where the tile is</param>
	public Tile(Point tilePosition)
	{
		Position = tilePosition;
		availableTiles = new(TileMap.Tiles);
		MaxScore = TileMap.MaxScore;
	}

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		Rectangle dest = new(x + center.X, y + center.Y, Game1.drawSize, Game1.drawSize);
		if (ERRORED)
		{
			spriteBatch.FillRectangle(dest, Color.Pink);
			return;
		}
		spriteBatch.Draw(iQuad.Images[Variant], dest, iQuad.Quad, Color.White, iQuad.Rotation, center.ToVector2(), iQuad.Flip, 0f);
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
		MaxScore = 0;
		foreach (ImageQuad quad in Tiles)
		{
			if (reversed == quad.Connections[checkingSide])
			{
				nTiles.Add(quad);
				MaxScore += quad.Weight; // Will be reset and only the final one will remain
			}
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
		if (availableTiles.Count == 0)
		{
			Debug.Write(Position);
			ERRORED = true;
			Debug.Write("MISSING: ");
			LogTileConnections(tiles, Position, Game1.size);
			return; //! When there is no valid texture
		}

		int selection = rand.Next(MaxScore);
		bool choiceFound = false;
		ImageQuad choice = default;
		foreach (ImageQuad iq in availableTiles)
		{ // This weighted choice doesn't look like it's much better than random.
			selection -= iq.Weight;
			if (selection <= 0)
			{
				choice = iq;
				choiceFound = true;
				break;
			}
		}

		if (choiceFound)
			SetTile(choice);
		else
			throw new InvalidOperationException("No suitable ImageQuad found");

		if (Position.Y > 0) tiles[Position.X, Position.Y - 1].Reduce(tiles);
		if (Position.X < Game1.size - 1) tiles[Position.X + 1, Position.Y].Reduce(tiles);
		if (Position.Y < Game1.size - 1) tiles[Position.X, Position.Y + 1].Reduce(tiles);
		if (Position.X > 0) tiles[Position.X - 1, Position.Y].Reduce(tiles);
	}

	public void SetTile(ImageQuad to)
	{
		iQuad = to;
		Variant = (byte)rand.Next(iQuad.Images.Length);
	}

}
