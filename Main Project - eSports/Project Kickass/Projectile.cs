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
        public int YPos { get { return yPos; } set { yPos = value; } }

        //constructor
        public Projectile(int dmg, int play, int x, int y, Texture2D skin)
        {
            damage = dmg;
            player = play;
            xPos = x;
            yPos = y;
            isActive = false;
            projSkin = skin;
        }

        //fire method
        public void Fire()
        {
            //player 1 left side of board
            if(player == 1)
            {
                isActive = true;
            }

            //player 2 right side of board
            if (player == 2)
            {
                isActive = true;
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
        public void Draw(SpriteBatch spritebatch)
        {

            //draws in different spaces based on which tile in the grid the character occupies
            if(isActive == true)
            {
                int xVal = 0;
                int yVal = 0;
                if(player == 1)
                {
                    switch (xPos)
                    {
                        case 0:
                            xVal = 10;
                            break;
                        case 1:
                            xVal = 110;
                            break;
                        case 2:
                            xVal = 210;
                            break;
                        case 3:
                            xVal = 310;
                            break;
                        case 4:
                            xVal = 410;
                            break;
                        case 5:
                            xVal = 510;
                            break;
                        case 6:
                            xVal = 610;
                            break;
                        case 7:
                            xVal = 710;
                            break;
                    }

                    switch (yPos)
                    {
                        case 0:
                            yVal = 90;
                            break;
                        case 1:
                            yVal = 155;
                            break;
                        case 2:
                            yVal = 220;
                            break;
                        case 3:
                            yVal = 285;
                            break;
                    }
                
                    if (xPos < 8)
                    {
                        spritebatch.Draw(projSkin, new Vector2(xVal, yVal), Color.White);
                        xPos++;
                    }
                }


                if (player == 2)
                {
                    switch (xPos)
                    {
                        case 0:
                            xVal = 710;
                            break;
                        case 1:
                            xVal = 610;
                            break;
                        case 2:
                            xVal = 510;
                            break;
                        case 3:
                            xVal = 410;
                            break;
                        case 4:
                            xVal = 310;
                            break;
                        case 5:
                            xVal = 210;
                            break;
                        case 6:
                            xVal = 110;
                            break;
                        case 7:
                            xVal = 10;
                            break;
                    }

                    switch (yPos)
                    {
                        case 7:
                            yVal = 90;
                            break;
                        case 6:
                            yVal = 155;
                            break;
                        case 5:
                            yVal = 220;
                            break;
                        case 4:
                            yVal = 285;
                            break;
                    }
                    if (xPos <8)
                    {
                        spritebatch.Draw(projSkin, new Vector2(xVal, yVal), Color.White);
                        xPos++;
                    }
                }
            }
        }
    }
}
