using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic.TileTypes;

public class Tile3
{
	private static Texture2D[] Images = [];
	public static void SetImages(Texture2D[] textures) => Images = textures;

	public static void Initialize()
	{
		TileMap.New(new Point(0, 0), Images, ["DD", "DD", "DD", "DD"]);
		TileMap.New(new Point(1, 0), Images, ["GD", "DD", "DD", "DD"]);
		TileMap.New(new Point(2, 0), Images, ["GG", "DD", "DD", "DD"]);
		TileMap.New(new Point(3, 0), Images, ["GG", "GD", "DD", "DD"]);
		TileMap.New(new Point(4, 0), Images, ["GG", "DG", "DD", "DD"]);
		TileMap.New(new Point(5, 0), Images, ["GG", "DD", "GD", "DD"]);
		TileMap.New(new Point(6, 0), Images, ["GG", "GG", "DD", "DD"]);
		TileMap.New(new Point(7, 0), Images, ["GG", "DD", "GG", "DD"]);
		TileMap.New(new Point(8, 0), Images, ["GD", "DD", "DD", "DG"]);
		TileMap.New(new Point(9, 0), Images, ["GD", "GD", "DD", "DD"]);
		TileMap.New(new Point(10, 0), Images, ["GD", "DG", "DD", "DD"]);
		TileMap.New(new Point(11, 0), Images, ["GD", "DD", "GD", "DD"]);
		TileMap.New(new Point(12, 0), Images, ["GD", "DD", "DG", "DD"]);

		TileMap.New(new Point(0, 1), Images, ["GG", "GG", "GG", "GG"]);
		TileMap.New(new Point(1, 1), Images, ["DG", "GG", "GG", "GG"]);
		TileMap.New(new Point(2, 1), Images, ["DD", "GG", "GG", "GG"]);
		TileMap.New(new Point(3, 1), Images, ["DD", "DG", "GG", "GG"]);
		TileMap.New(new Point(4, 1), Images, ["DD", "GD", "GG", "GG"]);
		TileMap.New(new Point(5, 1), Images, ["DD", "GG", "DG", "GG"]);
		TileMap.New(new Point(6, 1), Images, ["DD", "DD", "GG", "GG"]);
		TileMap.New(new Point(7, 1), Images, ["DD", "GG", "DD", "GG"]);
		TileMap.New(new Point(8, 1), Images, ["DG", "GG", "GG", "GD"]);
		TileMap.New(new Point(9, 1), Images, ["DG", "DG", "GG", "GG"]);
		TileMap.New(new Point(10, 1), Images, ["DG", "GD", "GG", "GG"]);
		TileMap.New(new Point(11, 1), Images, ["DG", "GG", "DG", "GG"]);
		TileMap.New(new Point(12, 1), Images, ["DG", "GG", "GD", "GG"]);
	}

}
