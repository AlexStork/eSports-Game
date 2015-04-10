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
    class GameBoard
    {
        //2D array of tiles to represent the ground
        //Tile[,] tiles = new Tile[4,8];
        
        Texture2D board;

        //constructor
        public GameBoard( Texture2D texture)
        {
            //for(int i = 0; i < 4; i ++)
            //{
            //    for(int j = 0; j < 8; j++)
            //    {
            //        //sets up an array of tiles to represent the game board
            //        //tiles[i, j] = new Tile(x,y,texture2D);
                    
            
                      board = texture;
            //    }
            //}
        }

        //draw method
        public void Draw(SpriteBatch spritebatch)
        {
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //    {
            //        tiles[i,j].Draw(spritebatch);
            //    }
            //}
            //spritebatch.Begin();
            spritebatch.Draw(board, new Rectangle(0, 5, 800, 480), Color.White);
            //spritebatch.End();
        }
    }
}
