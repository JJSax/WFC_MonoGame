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

	public const int size = 15; // how many tiles wide/high
	public const int drawSize = 32;

	private Tile[,] tiles = new Tile[size, size];
	Random rand;
	const double TIMER = 0.0025f;
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


		//! About at the point of remapping all of these to the sys2.png
		//! I noticed some of the tiles didn't line up now with rotation.

		TileMap.New(new Point(0, 0), ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 0), ["WD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 0), ["WW", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 0), ["WW", "WD", "DD", "DD"]);
		TileMap.New(new Point(4, 0), ["WW", "DW", "DD", "DD"]);
		TileMap.New(new Point(5, 0), ["WW", "DD", "WD", "DD"]);
		TileMap.New(new Point(6, 0), ["WW", "WW", "DD", "DD"]);
		TileMap.New(new Point(7, 0), ["WW", "DD", "WW", "DD"]);

		TileMap.New(new Point(0, 1), ["WW", "WW", "WW", "WW"]);
		TileMap.New(new Point(1, 1), ["DW", "WW", "WW", "WW"]);
		TileMap.New(new Point(2, 1), ["DD", "WW", "WW", "WW"]);
		TileMap.New(new Point(3, 1), ["DD", "DW", "WW", "WW"]);
		TileMap.New(new Point(4, 1), ["DD", "WD", "WW", "WW"]);
		TileMap.New(new Point(5, 1), ["DD", "WW", "DW", "WW"]);
		TileMap.New(new Point(6, 1), ["DD", "DD", "WW", "WW"]);
		TileMap.New(new Point(7, 1), ["DD", "WW", "DD", "WW"]);

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

		Tile.image = Content.Load<Texture2D>("Sys2");
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
