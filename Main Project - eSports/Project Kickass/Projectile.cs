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
        GameTime timer;


        //properties for attributes
        public int Player { get { return player; } }
        public int Damage { get { return damage; } }
        public int XPos 
        { 
            get { return xPos; }
            set { xPos = value; }
        }
        public int YPos { get { return yPos; } set { yPos = value; } }

        public Texture2D ProjSkin
        {
            get { return projSkin; }
            set { projSkin = value; }
        }

        //constructor
        public Projectile(int dmg, int play, int x, int y, Texture2D skin, GameTime ti)
        {
            damage = dmg;
            player = play;
            xPos = x;
            yPos = y;
            isActive = false;
            projSkin = skin;
            timer = ti;
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
                if (this.xPos == cha.XPos && this.yPos==cha.YPos)
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
                            xVal = 90;
                            break;
                        case 1:
                            xVal = 190;
                            break;
                        case 2:
                            xVal = 290;
                            break;
                        case 3:
                            xVal = 390;
                            break;
                        case 4:
                            xVal = 490;
                            break;
                        case 5:
                            xVal = 590;
                            break;
                        case 6:
                            xVal = 690;
                            break;
                        case 7:
                            xVal = 790;
                            break;
                    }

                    switch (yPos)
                    {
                        case 0:
                            yVal = 135;
                            break;
                        case 1:
                            yVal = 200;
                            break;
                        case 2:
                            yVal = 265;
                            break;
                        case 3:
                            yVal = 330;
                            break;
                    }
                
                    if (xPos < 8)
                    {
                        //if (timer.ElapsedGameTime < 60)
                        {
                            spritebatch.Draw(projSkin, new Vector2(xVal, yVal), Color.White);
                            xPos++;
                        }
                    }
                }


                if (player == 2)
                {
                    switch (xPos)
                    {
                        case 7:
                            xVal = 700;
                            break;
                        case 6:
                            xVal = 600;
                            break;
                        case 5:
                            xVal = 500;
                            break;
                        case 4:
                            xVal = 400;
                            break;
                        case 3:
                            xVal = 300;
                            break;
                        case 2:
                            xVal = 200;
                            break;
                        case 1:
                            xVal = 100;
                            break;
                        case 0:
                            xVal = 10;
                            break;
                    }

                    switch (yPos)
                    {
                        case 0:
                            yVal = 135;
                            break;
                        case 1:
                            yVal = 200;
                            break;
                        case 2:
                            yVal = 265;
                            break;
                        case 3:
                            yVal = 330;
                            break;
                    }

                    if (xPos > -1)
                    {
                        spritebatch.Draw(projSkin, new Vector2(xVal, yVal), Color.White);
                        xPos--;
                    }
                }
            }
        }
    }
}
