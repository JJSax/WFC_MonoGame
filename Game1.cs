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
		TileMap.New(new Point(5, 0), ["WW", "WW", "DW", "DD"]);
		TileMap.New(new Point(6, 0), ["WW", "WW", "WW", "DD"]);
		TileMap.New(new Point(7, 0), ["DD", "WD", "WD", "WW"]);

		TileMap.New(new Point(0, 1), ["DW", "WD", "DD", "DD"]);
		TileMap.New(new Point(1, 1), ["DD", "DW", "WW", "DW"]);
		TileMap.New(new Point(2, 1), ["WD", "DW", "WW", "WW"]);
		TileMap.New(new Point(3, 1), ["WD", "DW", "DW", "WD"]);
		TileMap.New(new Point(4, 1), ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(5, 1), ["DW", "WW", "WW", "DD"]);
		TileMap.New(new Point(6, 1), ["DD", "WW", "WW", "WW"]);
		TileMap.New(new Point(7, 1), ["WW", "DD", "DW", "WD"]);

		TileMap.New(new Point(0, 2), ["DD", "DW", "DW", "DD"]);
		TileMap.New(new Point(1, 2), ["DW", "WW", "DW", "DD"]);
		TileMap.New(new Point(2, 2), ["WW", "WD", "WD", "WW"]);
		TileMap.New(new Point(3, 2), ["WD", "DW", "DW", "WD"]);
		TileMap.New(new Point(5, 2), ["WW", "DD", "WD", "WW"]);
		TileMap.New(new Point(6, 2), ["WW", "DD", "WW", "WW"]);
		TileMap.New(new Point(7, 2), ["DW", "WW", "DD", "DW"]);

		TileMap.New(new Point(0, 3), ["DD", "DD", "WD", "DW"]);
		TileMap.New(new Point(1, 3), ["WD", "DD", "WD", "WW"]);
		TileMap.New(new Point(2, 3), ["WW", "WW", "DW", "WD"]);
		TileMap.New(new Point(3, 3), ["DW", "WD", "WD", "DW"]);
		TileMap.New(new Point(5, 3), ["WD", "DD", "WW", "WW"]);
		TileMap.New(new Point(6, 3), ["WW", "WW", "DD", "WW"]);
		TileMap.New(new Point(7, 3), ["WD", "DW", "WW", "DD"]);

		TileMap.New(new Point(0, 4), ["WD", "DD", "DD", "WD"]);
		TileMap.New(new Point(1, 4), ["WW", "WW", "DW", "DD"]);
		TileMap.New(new Point(2, 4), ["WW", "WW", "DW", "DD"]);
		TileMap.New(new Point(3, 4), ["DD", "WW", "WW", "DD"]);
		TileMap.New(new Point(4, 4), ["DW", "WW", "WW", "WW"]);
		TileMap.New(new Point(5, 4), ["DW", "WW", "WD", "DW"]);
		TileMap.New(new Point(6, 4), ["DW", "DW", "WW", "WW"]);
		TileMap.New(new Point(7, 4), ["WW", "DW", "WD", "WW"]);
		TileMap.New(new Point(8, 4), ["WW", "WW", "DW", "WW"]);
		TileMap.New(new Point(9, 4), ["DW", "DD", "WW", "WW"]);
		TileMap.New(new Point(10, 4), ["WD", "WD", "WW", "WW"]);
		TileMap.New(new Point(11, 4), ["WW", "DD", "DW", "WW"]);

		TileMap.New(new Point(0, 5), ["DW", "WD", "DD", "DD"]);
		TileMap.New(new Point(1, 5), ["WD", "DD", "WW", "WW"]);
		TileMap.New(new Point(2, 5), ["WD", "DD", "WW", "WW"]);
		TileMap.New(new Point(3, 5), ["DD", "DD", "WW", "WW"]);
		TileMap.New(new Point(4, 5), ["WD", "WW", "WW", "WW"]);
		TileMap.New(new Point(5, 5), ["WD", "DW", "WW", "WD"]);
		TileMap.New(new Point(6, 5), ["WD", "WW", "WW", "DW"]);
		TileMap.New(new Point(7, 5), ["WW", "WW", "WD", "WD"]);
		TileMap.New(new Point(8, 5), ["WW", "WW", "WD", "WW"]);
		TileMap.New(new Point(9, 5), ["WW", "DW", "DD", "WW"]);
		TileMap.New(new Point(10, 5), ["WW", "WD", "DW", "WW"]);
		TileMap.New(new Point(11, 5), ["WW", "WW", "DD", "DW"]);

		TileMap.New(new Point(0, 6), ["DD", "DW", "DW", "DD"]);
		TileMap.New(new Point(1, 6), ["DW", "WW", "WW", "DD"]);
		TileMap.New(new Point(2, 6), ["DW", "WW", "WW", "DD"]);
		TileMap.New(new Point(3, 6), ["WW", "DD", "DD", "WW"]);
		TileMap.New(new Point(4, 6), ["WW", "WD", "WW", "WW"]);
		TileMap.New(new Point(5, 6), ["DW", "WD", "WD", "WW"]);
		TileMap.New(new Point(6, 6), ["WW", "WD", "DW", "WW"]);
		TileMap.New(new Point(7, 6), ["DW", "WW", "WW", "WD"]);
		TileMap.New(new Point(8, 6), ["WW", "DW", "WW", "WW"]);
		TileMap.New(new Point(9, 6), ["WW", "WW", "WD", "DD"]);
		TileMap.New(new Point(10, 6), ["WW", "WW", "DW", "DW"]);
		TileMap.New(new Point(11, 6), ["WD", "WW", "WW", "DD"]);

		TileMap.New(new Point(0, 7), ["DD", "DD", "WD", "DW"]);
		TileMap.New(new Point(1, 7), ["WW", "DD", "WD", "WW"]);
		TileMap.New(new Point(2, 7), ["WW", "DD", "WD", "WW"]);
		TileMap.New(new Point(3, 7), ["WW", "WW", "DD", "DD"]);
		TileMap.New(new Point(4, 7), ["WW", "WW", "WW", "WD"]);
		TileMap.New(new Point(5, 7), ["WW", "DW", "DW", "WD"]);
		TileMap.New(new Point(6, 7), ["WW", "WW", "WD", "WD"]);
		TileMap.New(new Point(7, 7), ["DW", "DW", "WW", "WW"]);
		TileMap.New(new Point(8, 7), ["WW", "WW", "WW", "DW"]);
		TileMap.New(new Point(9, 7), ["DD", "WW", "WW", "WD"]);
		TileMap.New(new Point(10, 7), ["WD", "WW", "WW", "DW"]);
		TileMap.New(new Point(11, 7), ["DD", "WD", "WW", "WW"]);


		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				tiles[x, y] = new(new Point(x, y));
			}
		}

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

		if (InputManager.KeyPressed(Keys.A))
		{
			for (int x = 0; x < size; x++)
			{
				for (int y = 0; y < size; y++)
				{
					tiles[x, y] = new(new Point(x, y));
				}
			}
		}

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
