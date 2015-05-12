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
using System.Threading;
using System.IO;

namespace Project_Kickass
{
    class SelectScreen
    {

        // attributes
        private int p1char; // p1 int that represents the currently selected character
        private int p2char; // p2 int that represents the currently selected character
        private Texture2D IgnisSkin; // the first character's portrait (Ignis)
        private Texture2D HanzoSkin; // the second character's portrait (Hanzo)
        private Texture2D selectorSkin; // selector skin of the player
        private Texture2D charPortrait; // the border around the characters
        private bool characterChosen; // true if the player has chosen their character
        private bool p1Released = true; // has the player released the key?
        private bool p2Released = true; // has the player released the key?

        public bool CharacterChosen
        {
            get { return characterChosen; }
            set { characterChosen = value; }
        }

        public int P1Char
        {
            get { return p1char; }
            set { p1char = value; }
        }

        public int P2Char
        {
            get { return p2char; }
            set { p2char = value; }
        }

        // constructor
        public SelectScreen(Texture2D chSkin1, Texture2D chSkin2, Texture2D selSkin, Texture2D charPort)
        {
            IgnisSkin = chSkin1;
            HanzoSkin = chSkin2;
            selectorSkin = selSkin;
            charPortrait = charPort;
            p1char = 0;
            p2char = 1;
        }

        // select screen controls
        public void CharacterSelect(Character ch, KeyboardState kState)
        {
            if (kState.IsKeyDown(Keys.D))
            {
                Console.WriteLine("MUTHA FUKKA IM WORKING!");
            }
            if (kState.IsKeyUp(Keys.A) && kState.IsKeyUp(Keys.D)) p1Released = true; // prevents the characters from switching every frame the keys are held down (p1)
            if (kState.IsKeyUp(Keys.L) && kState.IsKeyUp(Keys.J)) p2Released = true; // prevents the characters from switching every frame the keys are held down (p2)

            if (ch.Player == 1)
            {
                if (p1Released == true)
                {
                    if(p1char == 0)
                    {
                        if (kState.IsKeyDown(Keys.D))
                        {
                            p1char = 1;
                            Console.WriteLine("D pressed");
                            p1Released = false;
                        }
                    }
                            
                    if(p2char == 1)
                    {
                        if (kState.IsKeyDown(Keys.A))
                        {
                            p1char = 0;
                            Console.WriteLine("A pressed");
                            p1Released = false;
                        }
                    }
                            
                }
                if (kState.IsKeyDown(Keys.W)) // player 1 selects with W
                {
                    characterChosen = true;
                }
            }


            if (ch.Player == 2)
            {
                if (p2Released == true)
                {
                    if (p2char == 0)
                    {
                        if (kState.IsKeyDown(Keys.L))
                        {
                            p2char = 1;
                            Console.WriteLine("L pressed");
                            p2Released = false;
                        }
                    }

                    if (p2char == 1)
                    {
                        if (kState.IsKeyDown(Keys.J))
                        {
                            p2char = 0;
                            Console.WriteLine("J pressed");
                            p2Released = false;
                        }
                    }
                            
                }

                if (kState.IsKeyDown(Keys.I)) // player 2 selects with I
                {
                    characterChosen = true;
                }
            }
        }

        // the draw method, used to draw the character portrait, which should already be figured out before this method
        public void Draw(SpriteBatch spriteBatch, Character ch)
        {

            if (ch.Player == 1)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(96, 73, 168, 126), Color.White); // p1 selector skin
                spriteBatch.Draw(charPortrait, new Rectangle(100, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p1 frame
                if (p1char == 0)
                {
                    spriteBatch.Draw(IgnisSkin, new Rectangle(110, 108, 140, 80),null, Color.White, 0, new Vector2(0,0), SpriteEffects.FlipHorizontally,0); // draws Ignis in p1's spot
                }
                else if (p1char == 1)
                {
                    spriteBatch.Draw(HanzoSkin, new Rectangle(110, 108, 140, 80), Color.White); // draws Hanzo in p1's spot
                }
            }

            if (ch.Player == 2)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(496, 73, 168, 126), Color.White); // p2 selector skin
                spriteBatch.Draw(charPortrait, new Rectangle(500, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p2 frame

                if (p2char == 0)
                {
                    spriteBatch.Draw(IgnisSkin, new Rectangle(510, 108, 140, 80), Color.White); // draws Ignis in p2's spot
                }
                else if (p2char == 1)
                {
                    spriteBatch.Draw(HanzoSkin, new Rectangle(510, 108, 140, 80), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0); // draws Hanzo in p2's spot
                }
            }

        }

    }
}