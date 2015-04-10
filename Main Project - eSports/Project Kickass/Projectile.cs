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
    //creates a projectile
    class Projectile
    {
        private int damage; //damage the projectile does
        private int player; // owner of the projectile
        private int xPos; //x position
        private int yPos; //y position
        private bool isActive; //shows whether the projectile is active

        //properties for attributes
        public int Player { get { return player; } }
        public int Damage { get { return damage; } }
        public int XPos { get { return xPos; } }
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
        public void Draw(SpriteBatch spritebatch)
        {
            //draws in different spaces based on which tile in the grid the character occupies
            if (player == 1)
            {
                if (yPos == 0)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 1)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 2)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 3)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }
            }

            if (player == 2)
            {
                if (yPos == 4)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 5)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 6)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }

                if (yPos == 7)
                {
                    if (xPos == 0)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 1)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 2)
                    {
                        //spritebatch.Draw()
                    }

                    if (xPos == 3)
                    {
                        //spritebatch.Draw()
                    }
                }
            }
        }
    }
}
