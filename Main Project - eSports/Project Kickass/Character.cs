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
    class Character
    {
        //position of character on grid
        private int xPos;
        private int yPos;
        private int health;
        private int maxHealth;
        private int player; //tells which player controls character
        private Projectile bullet;
        private Texture2D skin;
        private bool canMove = true; // tells whether character can move
        private string keyPress = ""; // stores which key was pressed
        private Rectangle hitBox; // the player's hitbox

        //properties for attributes
        public Rectangle HitBox
        {
            get { return hitBox; }
            set { hitBox = value; }
        }
        public int XPos { get { return xPos; } }
        public int YPos { get { return yPos; } }

        //constructor
        public Character(int x, int y, int hp, int play, Texture2D color, Projectile proj)
        {
            xPos = x;//xposition which corresponds to the 2D array in gameboard
            yPos = y;//y position which corresponds to the 2d array in gameboard
            health = hp;//health points
            player = play; //owner of the character
            bullet = proj; //player's projectile
            skin = color; // sets skin for character
        }

        //move method and fire method
        //adjusts the xPos and yPos to determine which spot in array character occupies
        public void Input(KeyboardState kstate)
        {
            //player 1, left side of the board
            if (player == 1)
            {
                if (canMove == true)
                {
                    if (kstate.IsKeyDown(Keys.W))
                    {
                        if (yPos > 0)
                        {
                            yPos--;
                            canMove = false;
                            keyPress = "w";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.A))
                    {
                        if (xPos > 0)
                        {
                            xPos--;
                            canMove = false;
                            keyPress = "a";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.S))
                    {
                        if (yPos < 3)
                        {
                            yPos++;
                            canMove = false;
                            keyPress = "s";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.D))
                    {
                        if (xPos < 3)
                        {
                            xPos++;
                            canMove = false;
                            keyPress = "d";
                        }
                    }
                }

                switch (keyPress)
                {
                    case "w":
                        {
                            if(kstate.IsKeyUp(Keys.W))
                            {
                                canMove = true;
                            }
                            break;
                        }
                    
                    case "a":
                        {
                            if (kstate.IsKeyUp(Keys.A))
                            {
                                canMove = true;
                            }
                            break;
                        }

                    case "s":
                        {
                            if (kstate.IsKeyUp(Keys.S))
                            {
                                canMove = true;
                            }
                            break;
                        }

                    case "d":
                        {
                            if (kstate.IsKeyUp(Keys.D))
                            {
                                canMove = true;
                            }
                            break;
                        }
                }

                if (kstate.IsKeyDown(Keys.F))
                {
                    bullet.XPos = this.xPos;
                    bullet.YPos = this.yPos;
                    bullet.Fire();
                }
 
            }

            //player 2 right side of board
            //player 1, left side of the board
            if (player == 2)
            {
                if (canMove == true)
                {
                    if (kstate.IsKeyDown(Keys.I))
                    {
                        if (yPos < 7)
                        {
                            yPos++;
                            canMove = false;
                            keyPress = "i";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.L))
                    {
                        if (xPos > 0)
                        {
                            xPos--;
                            canMove = false;
                            keyPress = "l";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.K))
                    {
                        if (yPos > 4)
                        {
                            yPos--;
                            canMove = false;
                            keyPress = "k";
                        }
                    }

                    if (kstate.IsKeyDown(Keys.J))
                    {
                        if (xPos < 3)
                        {
                            xPos++;
                            canMove = false;
                            keyPress = "j";
                        }
                    }
                }

                switch (keyPress)
                {
                    case "i":
                        {
                            if (kstate.IsKeyUp(Keys.I))
                            {
                                canMove = true;
                            }
                            break;
                        }

                    case "k":
                        {
                            if (kstate.IsKeyUp(Keys.K))
                            {
                                canMove = true;
                            }
                            break;
                        }

                    case "j":
                        {
                            if (kstate.IsKeyUp(Keys.J))
                            {
                                canMove = true;
                            }
                            break;
                        }

                    case "l":
                        {
                            if (kstate.IsKeyUp(Keys.L))
                            {
                                canMove = true;
                            }
                            break;
                        }
                }

                if (kstate.IsKeyDown(Keys.H))
                {
                    bullet.XPos = this.xPos;
                    bullet.YPos = this.yPos;
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
        public void Draw(SpriteBatch spritebatch,int width, int height)
        {
            //draws in different spaces based on which tile in the grid the character occupies
            if(player == 1)
            {
                if(yPos == 0)
                {
                    if(xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(10, 90, skin.Width, skin.Height);
                    }
                    
                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(110, 90, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(210, 90, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(310, 90, skin.Width, skin.Height);
                    }
                }

                if (yPos == 1)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(10, 155, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(110, 155, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(210, 155, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(310, 155, skin.Width, skin.Height);
                    }
                }

                if (yPos == 2)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(10, 220, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(110, 220, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(210, 220, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(310, 220, skin.Width, skin.Height);
                    }
                }

                if (yPos == 3)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2(10, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(10, 285, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2(110, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(110, 285, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2(210, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(210, 285, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2(310, 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle(310, 285, skin.Width, skin.Height);
                    }
                }
            }

            if (player == 2)
            {
                if (yPos == 4)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 90), 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 90), 285, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 190), 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 190), 285, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 290), 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 290), 285, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 390), 285), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 390), 285, skin.Width, skin.Height);
                    }
                }

                if (yPos == 5)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 90), 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 90), 220, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 190), 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 190), 220, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 290), 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 290), 220, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 390), 220), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 390), 220, skin.Width, skin.Height);
                    }
                }

                if (yPos == 6)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 90), 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 90), 155, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 190), 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 190), 155, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 290), 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 290), 155, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 390), 155), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 390), 155, skin.Width, skin.Height);
                    }
                }

                if (yPos == 7)
                {
                    if (xPos == 0)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 90), 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 90), 90, skin.Width, skin.Height);
                    }

                    if (xPos == 1)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 190), 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 190), 90, skin.Width, skin.Height);
                    }

                    if (xPos == 2)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 290), 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 290), 90, skin.Width, skin.Height);
                    }

                    if (xPos == 3)
                    {
                        spritebatch.Draw(skin, new Vector2((width - 390), 90), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                        hitBox = new Rectangle((width - 390), 90, skin.Width, skin.Height);
                    }
                }
            }
        }
    }
}
