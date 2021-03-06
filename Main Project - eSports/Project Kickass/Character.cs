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
//Aidan Kaufman
//Steven Ma
//Alex Mallory
namespace Project_Kickass
{
    abstract class Character
    {
        //position of character on grid
        private int xPos;
        private int yPos;
        private double health;
        private double maxHealth;
        private int player; //tells which player controls character
        private Projectile bullet1;

        private Texture2D skin;
        private bool canMove = true; // tells whether character can move
        private string keyPress = ""; // stores which key was pressed
        private Rectangle hitBox; // the player's hitbox
        private bool dazed = false; //tells whether character is dazed
        //properties for attributes
        public Rectangle HitBox
        {
            get { return hitBox; }
            set { hitBox = value; }
        }
        public int XPos 
        { 
            get { return xPos; }
            set { xPos = value; }
        }
        public int YPos 
        { 
            get { return yPos; }
            set { yPos = value; }
        }

        public double Health
        {
            get { return health; }
            set { health = value; }
        }

        public int Player
        {
            get { return player; }
            set { player = value; }
        }

        public double MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }

        public Texture2D Skin
        {
            get { return skin; }
            set { skin = value; }
        }

        public bool Dazed
        {
            get { return dazed; }
            set { dazed = value; }
        }

        public bool CanMove
        {
            get { return canMove; }
            set { canMove = value; }
        }

        public string KeyPress
        {
            get { return keyPress; }
            set { keyPress = value; }
        }

        public Projectile Bullet1
        {
            get { return bullet1; }
            set { bullet1 = value; }
        }

        //constructor
        public Character(int x, int y, int hp, int play, Texture2D color, Projectile proj)
        {
            xPos = x;//xposition which corresponds to the 2D array in gameboard
            yPos = y;//y position which corresponds to the 2d array in gameboard
            health = hp;//health points
            maxHealth = hp;//beginning health points
            player = play; //owner of the character
            bullet1 = proj; //player's projectile
            skin = color; // sets skin for character
        }

        public Character()
        {
            // TODO: Complete member initialization
        }

        public virtual void PassiveAbility()
        {
            // a method stub to be overridden by any character passives
        }

        //move method and fire method
        //adjusts the xPos and yPos to determine which spot in array character occupies
        public abstract void Input(KeyboardState kstate);
        //{
            //player 1, left side of the board
        //    if (player == 1)
        //    {
        //        if (dazed == false)
        //        {
        //            if (canMove == true)
        //            {
        //                if (kstate.IsKeyDown(Keys.W))
        //                {
        //                    if (yPos > 0)
        //                    {
        //                        yPos--;
        //                        canMove = false;
        //                        keyPress = "w";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.A))
        //                {
        //                    if (xPos > 0)
        //                    {
        //                        xPos--;
        //                        canMove = false;
        //                        keyPress = "a";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.S))
        //                {
        //                    if (yPos < 3)
        //                    {
        //                        yPos++;
        //                        canMove = false;
        //                        keyPress = "s";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.D))
        //                {
        //                    if (xPos < 3)
        //                    {
        //                        xPos++;
        //                        canMove = false;
        //                        keyPress = "d";
        //                    }
        //                }
        //            }
        //        }

        //        switch (keyPress)
        //        {
        //            case "w":
        //                {
        //                    if (kstate.IsKeyUp(Keys.W))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "a":
        //                {
        //                    if (kstate.IsKeyUp(Keys.A))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "s":
        //                {
        //                    if (kstate.IsKeyUp(Keys.S))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "d":
        //                {
        //                    if (kstate.IsKeyUp(Keys.D))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }
        //        }

        //        if (!dazed)
        //        {
        //            if (kstate.IsKeyDown(Keys.NumPad1))
        //            {
        //                if (bullet1.XPos > 7 || !bullet1.IsActive)
        //                {
        //                    bullet1.XPos = this.xPos;
        //                    bullet1.YPos = this.yPos;
        //                    bullet1.Fire();
        //                    PassiveAbility();
        //                }
        //            }
        //        }

        //    }

        //    //player 2 right side of board
        //    //player 1, left side of the board
        //    if (player == 2)
        //    {
        //        if (!dazed)
        //        {
        //            if (canMove)
        //            {
        //                if (kstate.IsKeyDown(Keys.I))
        //                {
        //                    if (yPos > 0)
        //                    {
        //                        yPos--;
        //                        canMove = false;
        //                        keyPress = "i";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.L))
        //                {
        //                    if (xPos < 7)
        //                    {
        //                        xPos++;
        //                        canMove = false;
        //                        keyPress = "l";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.K))
        //                {
        //                    if (yPos < 3)
        //                    {
        //                        yPos++;
        //                        canMove = false;
        //                        keyPress = "k";
        //                    }
        //                }

        //                if (kstate.IsKeyDown(Keys.J))
        //                {
        //                    if (xPos > 4)
        //                    {
        //                        xPos--;
        //                        canMove = false;
        //                        keyPress = "j";
        //                    }
        //                }
        //            }
        //        }
        //        switch (keyPress)
        //        {
        //            case "i":
        //                {
        //                    if (kstate.IsKeyUp(Keys.I))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "k":
        //                {
        //                    if (kstate.IsKeyUp(Keys.K))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "j":
        //                {
        //                    if (kstate.IsKeyUp(Keys.J))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }

        //            case "l":
        //                {
        //                    if (kstate.IsKeyUp(Keys.L))
        //                    {
        //                        canMove = true;
        //                    }
        //                    break;
        //                }
        //        }

        //        if (dazed == false)
        //        {
        //            if (kstate.IsKeyDown(Keys.NumPad4))
        //            {
        //                if (bullet1.XPos < 0 || bullet1.IsActive == false)
        //                {
        //                    bullet1.XPos = this.xPos;
        //                    bullet1.YPos = this.yPos;
        //                    bullet1.Fire();
        //                }
        //            }
        //        }
        //    }
        //}

        //Damage method
        public void takeDamage(int dmg)
        {
            health -= dmg;
        }

        // check to see if dazed
        public bool IsDazed()
        {
            if (dazed == true)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        //Draw method
        public void Draw(SpriteBatch spritebatch,int width, int height)
        {
            //draws in different spaces based on which tile in the grid the character occupies
            if(player == 1)
            {
                spritebatch.Draw(skin, new Vector2(10 + 100 * xPos, 90 + 65 * yPos), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
                hitBox = new Rectangle(10 + 100 * xPos, 90, skin.Width, skin.Height);

            }

            if (player == 2)
            {
                spritebatch.Draw(skin, new Vector2(width - (90 + 100 * (7 - xPos)), 90 + (65 * (yPos))), null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.FlipHorizontally, 0);
                hitBox = new Rectangle(width - (90 + 100 * (7 - xPos)), 90 + (65 * (yPos)), skin.Width, skin.Height);
            }
        }
    }
}
