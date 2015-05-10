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
        int character; // int that represents which character you're selected on
        private Texture2D selectorSkin; // the border around the characters
        private Texture2D charPortrait1; // the first character's portrait (ie: Ignis)
        public int player;
        private bool characterChosen; // true if the player has chosen their character

        public bool CharacterChosen
        {
            get { return characterChosen; }
            set { characterChosen = value; }
        }

        // constructor (to be filled if necessary)
        public SelectScreen(Texture2D selSkin, Texture2D charPort1, int plyr)
        {
            selectorSkin = selSkin;
            charPortrait1 = charPort1;
            player = plyr;
        }

        // select screen controls
        public int CharacterSelect(Character ch, KeyboardState kState)
        {
            if (ch.Player == 1)
            {
                if (kState.IsKeyDown(Keys.A))
                {
                    character--;
                }

                if (kState.IsKeyDown(Keys.D))
                {
                    character++;
                }

                if (kState.IsKeyDown(Keys.W)) // player 1 selects with W
                {
                    characterChosen = true;
                    return character;
                }
            }


            if (ch.Player == 2)
            {
                if (kState.IsKeyDown(Keys.J))
                {
                    character--;
                }

                if (kState.IsKeyDown(Keys.L))
                {
                    character++;
                }

                if (kState.IsKeyDown(Keys.I)) // player 2 selects with I
                {
                    characterChosen = true;
                    return character;
                }
            }

            return 0;
        }

        // the draw method, used to draw the character portrait, which should already be figured out before this method
        public void Draw(SpriteBatch spriteBatch)
        {

            if (player == 1)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(96, 73, 168, 126), Color.White); // p1
                spriteBatch.Draw(charPortrait1, new Rectangle(100, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p1
            }

            if (player == 2)
            {
                spriteBatch.Draw(selectorSkin, new Rectangle(496, 73, 168, 126), Color.White); // p2
                spriteBatch.Draw(charPortrait1, new Rectangle(500, 100, spriteBatch.GraphicsDevice.Viewport.Width / 5, spriteBatch.GraphicsDevice.Viewport.Height / 5), Color.White); // p2
            }

        }

    }
}