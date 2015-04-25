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
//Aidan Kaufman
//Steven Ma
//Alex Mallory
namespace Project_Kickass
{
    //creates a projectile
    class Projectile
    {
        private int damage; //damage the projectile does
        private int player; // owner of the projectile
        private int xPos; //x position
        private int yPos; //y position
        private bool isActive; //shows whether the projectile is active
        private Texture2D projSkin;
        private Rectangle projHitBox; // the projectile's hitbox


        //properties for attributes
        public int Player { get { return player; } }
        public int Damage { get { return damage; } }
        public int XPos 
        { 
            get { return xPos; }
            set { xPos = value; }
        }
        public int YPos { get { return yPos; } }

        //constructor
        public Projectile(int dmg, int play, int x, int y)
        {
            damage = dmg;
            player = play;
            xPos = x;
            yPos = y;
            isActive = false;
        }

        //fire method
        public void Fire()
        {
            //player 1 left side of board
            if(player == 1)
            {
                isActive = true;
                while(xPos < 8)
                {
                    xPos++;
                }
            }

            //player 2 right side of board
            if (player == 2)
            {
                isActive = true;
                while (xPos > 0)
                {
                    xPos--;
                }
            }
        }

        //checks to see if a character occupies the same space as projectile
        //collision detection
        public bool isColliding(Character cha)
        {
            if(isActive == true)
            {
                if (this.XPos == cha.XPos && this.YPos == cha.YPos)
                {
                    isActive = false;
                    return true;
                }

                else
                {
                    return false;
                }
            }

            else
            {
                return false;
            }
        }

        //Draw method
        public void Draw(SpriteBatch spritebatch, int width, int height)
        {

            //draws in different spaces based on which tile in the grid the character occupies
            if (player == 1)
            {
                if (yPos == 0)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2(10, 90), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2(110, 90), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2(210, 90), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2(310, 90), Color.White);
                    }
                }

                if (yPos == 1)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2(10, 155), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2(110, 155), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2(210, 155), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2(310, 155), Color.White);
                    }
                }

                if (yPos == 2)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2(10, 220), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2(110, 220), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2(210, 220), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2(310, 220), Color.White);
                    }
                }

                if (yPos == 3)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2(10, 285), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2(110, 285), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2(210, 285), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2(310, 285), Color.White);
                    }
                }
            }

            if (player == 2)
            {
                if (yPos == 4)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 90), 285), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 190), 285), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 290), 285), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 390), 285), Color.White);
                    }
                }

                if (yPos == 5)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 90), 220), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 190), 220), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 290), 220), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 390), 220), Color.White);
                    }
                }

                if (yPos == 6)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 90), 155), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 190), 155), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 290), 155), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 390), 155), Color.White);
                    }
                }

                if (yPos == 7)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 90), 90), Color.White);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 190), 90), Color.White);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 290), 90), Color.White);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(projSkin, new Vector2((width - 390), 90), Color.White);
                    }
                }
            }
        }
    }
}
