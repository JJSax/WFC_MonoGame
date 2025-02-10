using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Basic.TileTypes;

public class Tile5
{
	private static Texture2D[] Images = [];
	public static void SetImages(Texture2D[] textures) => Images = textures;

	public static void Initialize()
	{

		TileMap.New(new Point(0, 0), Images, ["GD", "DW", "WW", "WW"]);
		TileMap.New(new Point(1, 0), Images, ["DD", "DD", "WW", "GW"]);
		TileMap.New(new Point(2, 0), Images, ["DG", "GG", "WW", "WW"]);
		TileMap.New(new Point(3, 0), Images, ["GG", "DW", "WW", "WW"]);
		TileMap.New(new Point(4, 0), Images, ["GG", "WD", "WW", "WW"]);
		TileMap.New(new Point(5, 0), Images, ["GG", "WW", "DW", "WW"]);
		TileMap.New(new Point(6, 0), Images, ["GG", "DD", "WW", "WW"]);
		TileMap.New(new Point(7, 0), Images, ["GG", "WW", "DD", "WW"]);
		TileMap.New(new Point(8, 0), Images, ["DW", "WW", "WW", "WG"]);
		TileMap.New(new Point(9, 0), Images, ["GW", "DW", "WW", "WW"]);
		TileMap.New(new Point(10, 0), Images, ["GW", "WD", "WW", "WW"]);
		TileMap.New(new Point(11, 0), Images, ["GW", "WW", "DW", "WW"]);
		TileMap.New(new Point(12, 0), Images, ["GW", "WW", "WD", "WW"]);
		TileMap.New(new Point(13, 0), Images, ["WW", "WW", "DG", "DD"]);
		TileMap.New(new Point(14, 0), Images, ["DD", "DD", "DD", "GD"]);
		TileMap.New(new Point(15, 0), Images, ["DG", "WW", "WW", "GD"]);
		TileMap.New(new Point(16, 0), Images, ["DG", "GD", "WW", "WW"]);
		TileMap.New(new Point(17, 0), Images, ["WW", "DW", "DG", "WW"]);
		TileMap.New(new Point(18, 0), Images, ["GD", "DD", "DD", "DG"]);
		TileMap.New(new Point(19, 0), Images, ["WW", "WG", "DG", "WW"]);

		TileMap.New(new Point(0, 1), Images, ["DG", "GW", "WW", "WW"]);
		TileMap.New(new Point(1, 1), Images, ["GG", "GG", "WW", "DW"]);
		TileMap.New(new Point(2, 1), Images, ["GD", "DD", "WW", "WW"]);
		TileMap.New(new Point(3, 1), Images, ["DD", "GW", "WW", "WW"]);
		TileMap.New(new Point(4, 1), Images, ["DD", "WG", "WW", "WW"]);
		TileMap.New(new Point(5, 1), Images, ["DD", "WW", "GW", "WW"]);
		TileMap.New(new Point(6, 1), Images, ["DD", "GG", "WW", "WW"]);
		TileMap.New(new Point(7, 1), Images, ["DD", "WW", "GG", "WW"]);
		TileMap.New(new Point(8, 1), Images, ["GW", "WW", "WW", "WD"]);
		TileMap.New(new Point(9, 1), Images, ["DW", "GW", "WW", "WW"]);
		TileMap.New(new Point(10, 1), Images, ["DW", "WG", "WW", "WW"]);
		TileMap.New(new Point(11, 1), Images, ["DW", "WW", "GW", "WW"]);
		TileMap.New(new Point(12, 1), Images, ["DW", "WW", "WG", "WW"]);
		TileMap.New(new Point(13, 1), Images, ["WW", "WW", "GD", "GG"]);
		TileMap.New(new Point(14, 1), Images, ["GG", "GG", "GG", "DG"]);
		TileMap.New(new Point(15, 1), Images, ["GD", "WW", "WW", "DG"]);
		TileMap.New(new Point(16, 1), Images, ["GD", "DG", "WW", "WW"]);
		TileMap.New(new Point(17, 1), Images, ["WW", "GW", "GD", "WW"]);
		TileMap.New(new Point(18, 1), Images, ["DG", "GG", "GG", "GD"]);
		TileMap.New(new Point(19, 1), Images, ["WW", "WD", "GD", "WW"]);

		TileMap.New(new Point(0, 2), Images, ["WG", "WW", "WW", "GD"]);
		TileMap.New(new Point(1, 2), Images, ["WW", "WG", "DD", "DD"]);
		TileMap.New(new Point(2, 2), Images, ["DD", "DD", "DD", "GW"]);
		TileMap.New(new Point(3, 2), Images, ["WW", "DG", "GD", "DD"]);
		TileMap.New(new Point(4, 2), Images, ["GG", "GG", "DD", "WD"]);
		TileMap.New(new Point(5, 2), Images, ["WW", "WW", "GD", "WW"]);
		TileMap.New(new Point(6, 2), Images, ["DW", "GG", "WW", "DD"]);
		TileMap.New(new Point(7, 2), Images, ["GG", "GG", "GD", "WG"]);
		TileMap.New(new Point(8, 2), Images, ["GG", "GD", "GW", "WG"]);
		TileMap.New(new Point(9, 2), Images, ["WW", "DD", "GG", "GW"]);
		TileMap.New(new Point(10, 2), Images, ["GD", "WW", "GG", "GG"]);
		TileMap.New(new Point(11, 2), Images, ["DD", "WG", "DW", "DD"]);
		TileMap.New(new Point(12, 2), Images, ["WW", "DD", "DD", "GG"]);

		TileMap.New(new Point(0, 3), Images, ["WD", "WW", "WW", "DG"]);
		TileMap.New(new Point(1, 3), Images, ["WW", "WD", "GG", "GG"]);
		TileMap.New(new Point(2, 3), Images, ["GG", "GG", "GG", "DW"]);
		TileMap.New(new Point(3, 3), Images, ["WW", "GD", "DG", "GG"]);
		TileMap.New(new Point(4, 3), Images, ["DD", "DD", "GG", "WG"]);
		TileMap.New(new Point(5, 3), Images, ["WW", "WW", "DG", "WW"]);
		TileMap.New(new Point(6, 3), Images, ["GW", "DD", "WW", "GG"]);
		TileMap.New(new Point(7, 3), Images, ["DD", "DD", "DG", "WD"]);
		TileMap.New(new Point(8, 3), Images, ["DD", "DG", "DW", "WD"]);
		TileMap.New(new Point(9, 3), Images, ["WW", "GG", "DD", "DW"]);
		TileMap.New(new Point(10, 3), Images, ["DG", "WW", "DD", "DD"]);
		TileMap.New(new Point(11, 3), Images, ["GG", "WD", "GW", "GG"]);
		TileMap.New(new Point(12, 3), Images, ["WW", "GG", "GG", "DD"]);

	}

}
