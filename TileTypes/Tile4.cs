using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic.TileTypes;

public class Tile4
{
	private static Texture2D[] Images = [];
	public static void SetImages(Texture2D[] textures) => Images = textures;

	public static void Initialize()
	{
		TileMap.New(new Point(0, 0), Images, ["WW", "WW", "WW", "WW"]);
		TileMap.New(new Point(1, 0), Images, ["GW", "WW", "WW", "WW"]);
		TileMap.New(new Point(2, 0), Images, ["GG", "WW", "WW", "WW"]);
		TileMap.New(new Point(3, 0), Images, ["GG", "GW", "WW", "WW"]);
		TileMap.New(new Point(4, 0), Images, ["GG", "WG", "WW", "WW"]);
		TileMap.New(new Point(5, 0), Images, ["GG", "WW", "GW", "WW"]);
		TileMap.New(new Point(6, 0), Images, ["GG", "GG", "WW", "WW"]);
		TileMap.New(new Point(7, 0), Images, ["GG", "WW", "GG", "WW"]);
		TileMap.New(new Point(8, 0), Images, ["GW", "WW", "WW", "WG"]);
		TileMap.New(new Point(9, 0), Images, ["GW", "GW", "WW", "WW"]);
		TileMap.New(new Point(10, 0), Images, ["GW", "WG", "WW", "WW"]);
		TileMap.New(new Point(11, 0), Images, ["GW", "WW", "GW", "WW"]);
		TileMap.New(new Point(12, 0), Images, ["GW", "WW", "WG", "WW"]);

		TileMap.New(new Point(0, 1), Images, ["GG", "GG", "GG", "GG"]);
		TileMap.New(new Point(1, 1), Images, ["WG", "GG", "GG", "GG"]);
		TileMap.New(new Point(2, 1), Images, ["WW", "GG", "GG", "GG"]);
		TileMap.New(new Point(3, 1), Images, ["WW", "WG", "GG", "GG"]);
		TileMap.New(new Point(4, 1), Images, ["WW", "GW", "GG", "GG"]);
		TileMap.New(new Point(5, 1), Images, ["WW", "GG", "WG", "GG"]);
		TileMap.New(new Point(6, 1), Images, ["WW", "WW", "GG", "GG"]);
		TileMap.New(new Point(7, 1), Images, ["WW", "GG", "WW", "GG"]);
		TileMap.New(new Point(8, 1), Images, ["WG", "GG", "GG", "GW"]);
		TileMap.New(new Point(9, 1), Images, ["WG", "WG", "GG", "GG"]);
		TileMap.New(new Point(10, 1), Images, ["WG", "GW", "GG", "GG"]);
		TileMap.New(new Point(11, 1), Images, ["WG", "GG", "WG", "GG"]);
		TileMap.New(new Point(12, 1), Images, ["WG", "GG", "GW", "GG"]);
	}

}
