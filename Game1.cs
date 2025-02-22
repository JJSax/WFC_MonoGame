using System;
using System.Collections.Generic;
using Basic.TileTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Basic;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	private SpriteFont font;

	public const int size = 15; // how many tiles wide/high
	public const int drawSize = 32;

	private Tile[,] tiles = new Tile[size, size];
	Random rand;
	const double TIMER = 0.0025f;
	double Timer = TIMER;

	bool Errored = false;
	bool autoRestart = false;

	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	protected override void Initialize()
	{
		// TODO: Add your initialization logic here
		rand = new();

		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		// Tile1.SetImages([
		// 	Content.Load<Texture2D>("land1"),
		// 	Content.Load<Texture2D>("land2"),
		// 	Content.Load<Texture2D>("land3"),
		// ]);

		// Tile2.SetImages([
		// 	Content.Load<Texture2D>("mDirt1")
		// ]);

		// Tile3.SetImages([
		// 	Content.Load<Texture2D>("Grass1")
		// ]);

		// Tile4.SetImages([
		// 	Content.Load<Texture2D>("GrassWater1")
		// ]);

		// Tile5.SetImages([
		// 	Content.Load<Texture2D>("DGwithWater")
		// ]);

		Tile6Genned.SetImages([
			Content.Load<Texture2D>("full")
		]);

		// Tile1.Initialize();
		// Tile2.Initialize();
		// Tile3.Initialize();
		// Tile4.Initialize();
		// Tile5.Initialize();
		Tile6Genned.Initialize();
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				tiles[x, y] = new(new Point(x, y));
			}
		}

		font = Content.Load<SpriteFont>("Arial");
		// TODO: use this.Content to load your game content here
	}

	private void Collapse()
	{
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
			if (choice.ERRORED)
			{
				Errored = true;
				return;
			}
		}
		else if (autoRestart)
		{
			for (int x = 0; x < size; x++)
			{
				for (int y = 0; y < size; y++)
				{
					tiles[x, y] = new(new Point(x, y));
				}
			}
		}
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		InputManager.Update();
		// TODO: Add your update logic here

		if (Errored) return;

		Timer -= gameTime.ElapsedGameTime.TotalSeconds;
		if (Timer <= 0)
		{
			Timer = TIMER;
			for (int i = 0; i < 40; i++)
			{
				Collapse();
				if (Errored) return;
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
				Tile tile = tiles[x, y];
				if (tile.Collapsed)
					tile.Draw(_spriteBatch, x * drawSize, y * drawSize);
				Rectangle dest = new(x * drawSize, y * drawSize, drawSize, drawSize);
				_spriteBatch.DrawRectangle(dest, Color.Black, 1);
				if (tile.Collapsed && dest.Contains(InputManager.MousePosition) && !tile.ERRORED)
				{
					_spriteBatch.DrawString(
						font,
						$"{tile.iQuad.X} - {tile.iQuad.Y} - {tile.iQuad.Rotation} - {tile.iQuad.Flip}",
						new(size * drawSize, 5), Color.Pink,
						0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f
					);
					_spriteBatch.DrawString(
						font,
						$"{tile.iQuad.Connections[0]}, {tile.iQuad.Connections[1]}, {tile.iQuad.Connections[2]}, {tile.iQuad.Connections[3]}",
						new(size * drawSize, drawSize), Color.Pink,
						0f, Vector2.Zero, 1f, SpriteEffects.None, 0.5f
					);
				}
			}
		}

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
