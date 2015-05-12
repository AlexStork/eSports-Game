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

namespace Project_Kickass
{

    class Ignis:Character
    {
        private int flamesWake = 0;
        private int fanningFlames = 0;
        private int conflagration = 0;
        private Projectile fireBall;
        public Projectile Fireball
        {
            get { return fireBall; }
            set { fireBall = value; }
        }

        public Ignis(int x, int y, int hp, int play, Texture2D color, Projectile proj, Projectile proj2)
            : base(x, y, hp, play, color, proj)
        {
            fireBall = proj2;
        }

        //Overwrite Input Method
        public void Input(KeyboardState kstate)
        {
            //player 1, left side of the board
            if (this.Player == 1)
            {
                if (this.Dazed == false)
                {
                    if (this.CanMove == true)
                    {
                        if (kstate.IsKeyDown(Keys.W))
                        {
                            if (this.YPos > 0)
                            {
                                this.YPos--;
                                this.CanMove = false;
                                this.KeyPress = "w";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.A))
                        {
                            if (this.XPos > 0)
                            {
                                this.XPos--;
                                this.CanMove = false;
                                this.KeyPress = "a";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.S))
                        {
                            if (this.YPos < 3)
                            {
                                this.YPos++;
                                this.CanMove = false;
                                this.KeyPress = "s";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.D))
                        {
                            if (this.XPos < 3)
                            {
                                this.XPos++;
                                this.CanMove = false;
                                this.KeyPress = "d";
                            }
                        }
                    }
                }

                switch (this.KeyPress)
                {
                    case "w":
                        {
                            if (kstate.IsKeyUp(Keys.W))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "a":
                        {
                            if (kstate.IsKeyUp(Keys.A))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "s":
                        {
                            if (kstate.IsKeyUp(Keys.S))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "d":
                        {
                            if (kstate.IsKeyUp(Keys.D))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }
                }

                if (this.Dazed == false)
                {
                    if (kstate.IsKeyDown(Keys.NumPad1))
                    {
                        if (this.Bullet1.XPos > 7 || this.Bullet1.IsActive == false)
                        {
                            this.Bullet1.XPos = this.XPos;
                            this.Bullet1.YPos = this.YPos;
                            this.Bullet1.Fire();
 

                            //Passive: In Flame's Wake
                            if (flamesWake >= 4)
                            {
                                fireBall.XPos = this.XPos;
                                fireBall.YPos = this.YPos;
                                fireBall.FramesPerBlock = 60;
                                fireBall.Fire();

                                flamesWake = 0;
                            }
                            else
                            {
                                flamesWake++;
                            }

                            //Console.WriteLine(flamesWake);
                        }
                    }

                    if (kstate.IsKeyDown(Keys.NumPad2))
                    {

                    }
                }

            }

            //player 2 right side of board
            //player 1, left side of the board
            if (this.Player == 2)
            {
                if (this.Dazed == false)
                {
                    if (this.CanMove == true)
                    {
                        if (kstate.IsKeyDown(Keys.I))
                        {
                            if (this.YPos > 0)
                            {
                                this.YPos--;
                                this.CanMove = false;
                                this.KeyPress = "i";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.L))
                        {
                            if (this.XPos < 7)
                            {
                                this.XPos++;
                                this.CanMove = false;
                                this.KeyPress = "l";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.K))
                        {
                            if (this.YPos < 3)
                            {
                                this.YPos++;
                                this.CanMove = false;
                                this.KeyPress = "k";
                            }
                        }

                        if (kstate.IsKeyDown(Keys.J))
                        {
                            if (this.XPos > 4)
                            {
                                this.XPos--;
                                this.CanMove = false;
                                this.KeyPress = "j";
                            }
                        }
                    }
                }
                switch (this.KeyPress)
                {
                    case "i":
                        {
                            if (kstate.IsKeyUp(Keys.I))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "k":
                        {
                            if (kstate.IsKeyUp(Keys.K))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "j":
                        {
                            if (kstate.IsKeyUp(Keys.J))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }

                    case "l":
                        {
                            if (kstate.IsKeyUp(Keys.L))
                            {
                                this.CanMove = true;
                            }
                            break;
                        }
                }

                if (this.Dazed == false)
                {
                    if (kstate.IsKeyDown(Keys.NumPad4))
                    {
                        if (this.Bullet1.XPos < 0 || this.Bullet1.IsActive == false)
                        {
                            this.Bullet1.XPos = this.XPos;
                            this.Bullet1.YPos = this.YPos;
                            this.Bullet1.Fire();
                        }
                    }
                }
            }
        }
    }
}
