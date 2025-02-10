using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic.TileTypes;

public class Tile1
{

	public static string[] ImageNames => [
		"tile1",
		"tile2",
		"tile3"
	];

	private static Texture2D[] Images = [];
	public static void SetImages(Texture2D[] textures) => Images = textures;

	public static void Initialize()
	{
		TileMap.New(new Point(0, 0), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 0), Images, ["WD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 0), Images, ["WW", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 0), Images, ["WW", "WD", "DD", "DD"]);
		TileMap.New(new Point(4, 0), Images, ["WW", "DW", "DD", "DD"]);
		TileMap.New(new Point(5, 0), Images, ["WW", "DD", "WD", "DD"]);
		TileMap.New(new Point(6, 0), Images, ["WW", "WW", "DD", "DD"]);
		TileMap.New(new Point(7, 0), Images, ["WW", "DD", "WW", "DD"]);
		TileMap.New(new Point(8, 0), Images, ["WD", "DD", "DD", "DW"]);
		TileMap.New(new Point(9, 0), Images, ["WD", "WD", "DD", "DD"]);
		TileMap.New(new Point(10, 0), Images, ["WD", "DW", "DD", "DD"]);
		TileMap.New(new Point(11, 0), Images, ["WD", "DD", "WD", "DD"]);
		TileMap.New(new Point(12, 0), Images, ["WD", "DD", "DW", "DD"]);

		TileMap.New(new Point(0, 1), Images, ["WW", "WW", "WW", "WW"]);
		TileMap.New(new Point(1, 1), Images, ["DW", "WW", "WW", "WW"]);
		TileMap.New(new Point(2, 1), Images, ["DD", "WW", "WW", "WW"]);
		TileMap.New(new Point(3, 1), Images, ["DD", "DW", "WW", "WW"]);
		TileMap.New(new Point(4, 1), Images, ["DD", "WD", "WW", "WW"]);
		TileMap.New(new Point(5, 1), Images, ["DD", "WW", "DW", "WW"]);
		TileMap.New(new Point(6, 1), Images, ["DD", "DD", "WW", "WW"]);
		TileMap.New(new Point(7, 1), Images, ["DD", "WW", "DD", "WW"]);
		TileMap.New(new Point(8, 1), Images, ["DW", "WW", "WW", "WD"]);
		TileMap.New(new Point(9, 1), Images, ["DW", "DW", "WW", "WW"]);
		TileMap.New(new Point(10, 1), Images, ["DW", "WD", "WW", "WW"]);
		TileMap.New(new Point(11, 1), Images, ["DW", "WW", "DW", "WW"]);
		TileMap.New(new Point(12, 1), Images, ["DW", "WW", "WD", "WW"]);
	}

}
