using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Basic;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	public const int size = 15;
	public const int drawSize = 32;

	private Tile[,] tiles = new Tile[size, size];
	Random rand;
	const double TIMER = 0.025f;
	double Timer = TIMER;

	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	protected override void Initialize()
	{
		// TODO: Add your initialization logic here

		// Left to right or top to bottom, from top and moving clockwise
		TileMap.New(new Point(0, 0), ["WD", "DD", "DD", "WD"]);
		TileMap.New(new Point(1, 0), ["WW", "WD", "DD", "WD"]);
		TileMap.New(new Point(2, 0), ["DW", "WW", "WW", "DW"]);
		TileMap.New(new Point(3, 0), ["DW", "WD", "WD", "DW"]);
		TileMap.New(new Point(4, 0), ["WW", "WW", "WW", "WW"]);
		// TileMap.New(new Point(5, 0), ["WW", "WW", "DW", "DD"]);

		TileMap.New(new Point(0, 1), ["DW", "WD", "DD", "DD"]);
		TileMap.New(new Point(1, 1), ["DD", "DW", "WW", "DW"]);
		TileMap.New(new Point(2, 1), ["WD", "DW", "WW", "WW"]);
		TileMap.New(new Point(3, 1), ["WD", "DW", "DW", "WD"]);
		TileMap.New(new Point(4, 1), ["DD", "DD", "DD", "DD"]);
		// TileMap.New(new Point(5, 1), ["DW", "WW", "WW", "DD"]);

		TileMap.New(new Point(0, 2), ["DD", "DW", "DW", "DD"]);
		TileMap.New(new Point(1, 2), ["DW", "WW", "DW", "DD"]);
		TileMap.New(new Point(2, 2), ["WW", "WD", "WD", "WW"]);
		TileMap.New(new Point(3, 2), ["WD", "DW", "DW", "WD"]);
		// TileMap.New(new Point(5, 2), ["WW", "DD", "WD", "WW"]);

		TileMap.New(new Point(0, 3), ["DD", "DD", "WD", "DW"]);
		TileMap.New(new Point(1, 3), ["WD", "DD", "WD", "WW"]);
		TileMap.New(new Point(2, 3), ["WW", "WW", "DW", "WD"]);
		TileMap.New(new Point(3, 3), ["DW", "WD", "WD", "DW"]);
		// TileMap.New(new Point(5, 3), ["WD", "DD", "WW", "WW"]);

		// TileMap.New(new Point(1, 4), ["WW", "WW", "DW", "DD"]);
		// TileMap.New(new Point(2, 4), ["WW", "WW", "DW", "DD"]);
		// TileMap.New(new Point(3, 4), ["WW", "WW", "DW", "DD"]);

		// TileMap.New(new Point(1, 5), ["WD", "DD", "WW", "WW"]);
		// TileMap.New(new Point(2, 5), ["WD", "DD", "WW", "WW"]);
		// TileMap.New(new Point(3, 5), ["DD", "WW", "WW", "DD"]);

		// TileMap.New(new Point(1, 6), ["DW", "WW", "WW", "DD"]);
		// TileMap.New(new Point(2, 6), ["DW", "WW", "WW", "DD"]);
		// TileMap.New(new Point(3, 6), ["WW", "DD", "DD", "WW"]);

		// TileMap.New(new Point(1, 7), ["WW", "DD", "WD", "WW"]);
		// TileMap.New(new Point(2, 7), ["WW", "WW", "DD", "DD"]);


		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				tiles[x, y] = new(new Point(x, y));
			}
		}
		// tiles[0, 0].SetTile(TileMap.Tiles[TileMap.LocationMap[new Point(0, 0)]]);
		// tiles[1, 1].SetTile(TileMap.Tiles[TileMap.LocationMap[new Point(1, 1)]]);

		rand = new();

		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		Tile.image = Content.Load<Texture2D>("WandD");
		// TODO: use this.Content to load your game content here
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		InputManager.Update();
		// TODO: Add your update logic here

		Timer -= gameTime.ElapsedGameTime.TotalSeconds;
		if (Timer <= 0)
		{
			Timer = TIMER;
			List<Tile> mins = [];
			int minEntropy = int.MaxValue;
			foreach (Tile tile in tiles)
			{
				if (tile.Collapsed) continue;
				if (tile.availableTiles.Count == minEntropy)
				{
					mins.Add(tile);
				}
				else if (tile.availableTiles.Count < minEntropy)
				{
					mins = [tile];
					minEntropy = tile.availableTiles.Count;
				}
			}

			if (mins.Count > 0)
			{
				Tile choice = mins[rand.Next(mins.Count)];
				choice.Collapse(tiles);
			}
		}

		// if (InputManager.KeyPressed(Keys.A))
		// {
		// 	List<Tile> mins = [];
		// 	int minEntropy = int.MaxValue;
		// 	foreach (Tile tile in tiles)
		// 	{
		// 		if (tile.Collapsed) continue;
		// 		if (tile.availableTiles.Count == minEntropy)
		// 		{
		// 			mins.Add(tile);
		// 		}
		// 		else if (tile.availableTiles.Count < minEntropy)
		// 		{
		// 			mins = [tile];
		// 			minEntropy = tile.availableTiles.Count;
		// 		}
		// 	}

		// 	if (mins.Count > 0)
		// 	{
		// 		Tile choice = mins[rand.Next(mins.Count)];
		// 		choice.Collapse(tiles);
		// 	}


		// 	// tiles[0, 1].Reduce(tiles);
		// 	// ImageQuad choice = opts[rand.Next(opts.Count)];
		// 	// tiles[0, 1].quad = Tile.Quad(choice.X, choice.Y);
		// }

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		_spriteBatch.Begin();
		// TODO: Add your drawing code here
		// _spriteBatch.FillRectangle(0, 0, size * drawSize, size * drawSize, Color.White);
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				_spriteBatch.DrawRectangle(new(x * drawSize, y * drawSize, drawSize, drawSize), Color.Black, 1);
				if (tiles[x, y].Collapsed)
					tiles[x, y].Draw(_spriteBatch, x * drawSize, y * drawSize);
			}
		}

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
