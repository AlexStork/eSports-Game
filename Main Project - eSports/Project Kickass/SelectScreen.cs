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
    // enumerators
    public enum CharacterType
    {
        IGNIS,
        HANZO
    }
    class SelectScreen
    {        
        // attributes
        private CharacterType playerChar; // p1 int that represents the currently selected character
        private Texture2D IgnisSkin; // the first character's portrait (Ignis)
        private Texture2D HanzoSkin; // the second character's portrait (Hanzo)
        private Texture2D selectorSkin; // selector skin of the player
        private Texture2D charPortrait; // the border around the characters
        private bool characterChosen; // true if the player has chosen their character
        private bool released = true; // has the player released the key?
        private int player;

        public bool CharacterChosen
        {
            get { return characterChosen; }
            set { characterChosen = value; }
        }

        public CharacterType PlayerChar
        {
            get { return playerChar; }
            set { playerChar = value; }
        }

        // constructor
        public SelectScreen(Texture2D chSkin1, Texture2D chSkin2, Texture2D selSkin, Texture2D charPort, int player)
        {
            IgnisSkin = chSkin1;
            HanzoSkin = chSkin2;
            selectorSkin = selSkin;
            charPortrait = charPort;
            this.player = player;
            if (player == 1)
            {
                playerChar = CharacterType.IGNIS;
            }
            else if (player == 2)
            {
                playerChar = CharacterType.HANZO;
            }
        }

        // select screen controls
        public void CharacterSelect(KeyboardState kState)
        {
            if (player == 1 && kState.IsKeyUp(Keys.A) && kState.IsKeyUp(Keys.D)) released = true; // prevents the characters from switching every frame the keys are held down (p1)
            if (player == 2 && kState.IsKeyUp(Keys.L) && kState.IsKeyUp(Keys.J)) released = true; // prevents the characters from switching every frame the keys are held down (p2)

            if (player == 1)
            {
                if (released == true)
                {
                    if(playerChar == CharacterType.IGNIS)
                    {
                        if (kState.IsKeyDown(Keys.D))
                        {
                            playerChar = CharacterType.HANZO;
                            Console.WriteLine("D pressed");
                            released = false;
                        }
                    }
                            
                    if(playerChar == CharacterType.HANZO)
                    {
                        if (kState.IsKeyDown(Keys.A))
                        {
                            playerChar = CharacterType.IGNIS;
                            Console.WriteLine("A pressed");
                            released = false;
                        }
                    }
                            
                }
                if (kState.IsKeyDown(Keys.W)) // player 1 selects with W
                {
                    characterChosen = true;
                }
            }


            if (player == 2)
            {
                if (released == true)
                {
                    if (playerChar == CharacterType.IGNIS)
                    {
                        if (kState.IsKeyDown(Keys.L))
                        {
                            playerChar = CharacterType.HANZO;
                            Console.WriteLine("L pressed");
                            released = false;
                        }
                    }

                    if (playerChar == CharacterType.HANZO)
                    {
                        if (kState.IsKeyDown(Keys.J))
                        {
                            playerChar = CharacterType.IGNIS;
                            Console.WriteLine("J pressed");
                            released = false;
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
        public void Draw(SpriteBatch spriteBatch)
        {

            if (player == 1)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(96, 73, 168, 126), Color.White); // p1 selector skin
                spriteBatch.Draw(charPortrait, new Rectangle(100, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p1 frame
                if (playerChar == CharacterType.IGNIS)
                {
                    spriteBatch.Draw(IgnisSkin, new Rectangle(110, 108, 140, 80),null, Color.White, 0, new Vector2(0,0), SpriteEffects.FlipHorizontally,0); // draws Ignis in p1's spot
                }
                else if (playerChar == CharacterType.HANZO)
                {
                    spriteBatch.Draw(HanzoSkin, new Rectangle(110, 108, 140, 80), Color.White); // draws Hanzo in p1's spot
                }
            }

            if (player == 2)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(496, 73, 168, 126), Color.White); // p2 selector skin
                spriteBatch.Draw(charPortrait, new Rectangle(500, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p2 frame

                if (playerChar == CharacterType.IGNIS)
                {
                    spriteBatch.Draw(IgnisSkin, new Rectangle(510, 108, 140, 80), Color.White); // draws Ignis in p2's spot
                }
                else if (playerChar == CharacterType.HANZO)
                {
                    spriteBatch.Draw(HanzoSkin, new Rectangle(510, 108, 140, 80), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 0); // draws Hanzo in p2's spot
                }
            }

        }

    }
}