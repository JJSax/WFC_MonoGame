using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;

namespace Basic;

public class Game1 : Game
{
	private GraphicsDeviceManager _graphics;
	private SpriteBatch _spriteBatch;

	public const int size = 3;
	public const int drawSize = 32;

	private Tile[,] tiles = new Tile[size, size];
	Random rand;

	public Game1()
	{
		_graphics = new GraphicsDeviceManager(this);
		Content.RootDirectory = "Content";
		IsMouseVisible = true;
	}

	protected override void Initialize()
	{
		// TODO: Add your initialization logic here

		string connected = "a";
		string unconnected = "b";

		TileMap.New(new Point(0, 0), [connected, connected, connected, connected]);
		TileMap.New(new Point(1, 0), [connected, connected, unconnected, connected]);
		TileMap.New(new Point(1, 1), [unconnected, connected, connected, connected]);
		TileMap.New(new Point(1, 2), [connected, unconnected, connected, connected]);
		TileMap.New(new Point(1, 3), [connected, connected, connected, unconnected]);
		TileMap.New(new Point(5, 0), [unconnected, unconnected, unconnected, unconnected]);

		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				tiles[x, y] = new(new Point(x, y));
			}
		}
		tiles[0, 0].SetTile(TileMap.Tiles[TileMap.LocationMap[new Point(0, 0)]]);
		tiles[1, 1].SetTile(TileMap.Tiles[TileMap.LocationMap[new Point(1, 1)]]);

		rand = new();

		base.Initialize();
	}

	protected override void LoadContent()
	{
		_spriteBatch = new SpriteBatch(GraphicsDevice);

		Tile.image = Content.Load<Texture2D>("tiles");
		// TODO: use this.Content to load your game content here
	}

	protected override void Update(GameTime gameTime)
	{
		if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
			Exit();

		InputManager.Update();
		// TODO: Add your update logic here

		if (InputManager.KeyPressed(Keys.A))
		{
			List<ImageQuad> opts = tiles[0, 1].GetValidOptions(tiles);
			ImageQuad choice = opts[rand.Next(opts.Count)];
			tiles[0, 1].quad = Tile.Quad(choice.X, choice.Y);
		}

		base.Update(gameTime);
	}

	protected override void Draw(GameTime gameTime)
	{
		GraphicsDevice.Clear(Color.CornflowerBlue);

		_spriteBatch.Begin();
		// TODO: Add your drawing code here
		_spriteBatch.FillRectangle(0, 0, size * drawSize, size * drawSize, Color.White);
		for (int x = 0; x < size; x++)
		{
			for (int y = 0; y < size; y++)
			{
				_spriteBatch.DrawRectangle(new(x * drawSize, y * drawSize, drawSize, drawSize), Color.Black, 1);
				tiles[x, y].Draw(_spriteBatch, x * drawSize, y * drawSize);
			}
		}

		_spriteBatch.End();
		base.Draw(gameTime);
	}
}
