﻿using System;
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
    class Character
    {
        //position of character on grid
        private int xPos;
        private int yPos;
        private int health;
        private int player; //tells which player controls character
        private Projectile bullet;
        private Texture2D skin;

        //properties for attributes
        public int XPos { get { return xPos; } }
        public int YPos { get { return yPos; } }

        //constructor
        public Character(int x, int y, int hp, int play, Texture2D color)
        {
            xPos = x;//xposition which corresponds to the 2D array in gameboard
            yPos = y;//y position which corresponds to the 2d array in gameboard
            health = hp;//health points
            player = play; //owner of the character
            bullet = new Projectile(10, play, x, y); //player's projectile
            skin = color; // sets skin for character
        }

        //move method and fire method
        //adjusts the xPos and yPos to determine which spot in array character occupies
        public void Input(KeyboardState kstate)
        {
            //player 1, left side of the board
            if (player == 1)
            {
                if (kstate.IsKeyDown(Keys.W))
                {
                    if (yPos > 0)
                    {
                        yPos--;
                    }
                }

                if (kstate.IsKeyDown(Keys.A))
                {
                    if (xPos > 0)
                    {
                        xPos--;
                    }
                }

                if (kstate.IsKeyDown(Keys.S))
                {
                    if (yPos < 3)
                    {
                        yPos++;
                    }
                }

                if (kstate.IsKeyDown(Keys.D))
                {
                    if (xPos < 3)
                    {
                        xPos++;
                    }
                }

                if (kstate.IsKeyDown(Keys.F))
                {
                    bullet.Fire();
                }
            }

            //player 2 right side of board
            //player 1, left side of the board
            if (player == 1)
            {
                if (kstate.IsKeyDown(Keys.I))
                {
                    if (yPos < 4)
                    {
                        yPos++;
                    }
                }

                if (kstate.IsKeyDown(Keys.J))
                {
                    if (xPos > 0)
                    {
                        xPos--;
                    }
                }

                if (kstate.IsKeyDown(Keys.K))
                {
                    if (yPos > 0)
                    {
                        yPos--;
                    }
                }

                if (kstate.IsKeyDown(Keys.L))
                {
                    if (xPos < 4)
                    {
                        xPos++;
                    }
                }

                if (kstate.IsKeyDown(Keys.H))
                {
                    bullet.Fire();
                }
            }
        }

        //Damage method
        public void takeDamage(int dmg)
        {
            health -= dmg;
        }

        //Draw method
        public void Draw(SpriteBatch spritebatch)
        {
            //draws in different spaces based on which tile in the grid the character occupies
            if(player == 1)
            {
                if(yPos == 0)
                {
                    if(xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }
                    
                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }
                }

                if (yPos == 1)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }
                }

                if (yPos == 2)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }
                }

                if (yPos == 3)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
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