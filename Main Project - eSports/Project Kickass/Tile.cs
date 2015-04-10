using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

//Alex Heerding
namespace Project_Kickass
{
    public class Tile
    {
        //attributes
        private int x; //x coordinate
        private int y; //y coordinate

        private Texture2D tilePic; //image for tile
        private Vector2 tilePos; //position of tile

        //constructor
        public Tile(int xVal, int yVal, Texture2D tile)
        {
            x = xVal;
            y = yVal;
            tilePos = new Vector2(x, y);
            tilePic = tile;
        }

        //draw method
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(tilePic, tilePos, Color.White);
        }
    }
}
