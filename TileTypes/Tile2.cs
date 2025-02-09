using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic.TileTypes;

public class Tile2
{

	public static string[] ImageNames => [
		"mDirt1"
	];

	private static Texture2D[] Images = [];
	public static void SetImages(Texture2D[] textures) => Images = textures;

	public static void Initialize()
	{
		TileMap.New(new Point(0, 0), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 0), Images, ["WD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 0), Images, ["WW", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 0), Images, ["WD", "DD", "WD", "DD"]);
		TileMap.New(new Point(4, 0), Images, ["WD", "DD", "WD", "DD"]);
		TileMap.New(new Point(5, 0), Images, ["WD", "DD", "DD", "DD"]);
		TileMap.New(new Point(6, 0), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(7, 0), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(8, 0), Images, ["DD", "DD", "DD", "DD"]);

		TileMap.New(new Point(0, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 1), Images, ["WD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(4, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(5, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(6, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(7, 1), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(8, 1), Images, ["DD", "DD", "DD", "DD"]);

		TileMap.New(new Point(0, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(4, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(5, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(6, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(7, 2), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(8, 2), Images, ["DD", "DD", "DD", "DD"]);

		TileMap.New(new Point(0, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(4, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(5, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(6, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(7, 3), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(8, 3), Images, ["DD", "DD", "DD", "DD"]);
	}

}
