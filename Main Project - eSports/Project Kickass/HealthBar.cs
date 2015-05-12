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
    // Implements the health bar
    class HealthBar
    {

        // constants
        const int HEALTHBAR_HEIGHT = 52;
        const int HEALTHBAR_Y = 28;
        const int HEALTHBAR_WIDTH = 340;
        const int HEALTHBAR2_X = 460;

        // attributes
        private Texture2D healthBarSkin;


        // constructor
        public HealthBar(Character ch, Texture2D skin)
        {
            healthBarSkin = skin;
        }

        // draw method
        public void Draw(SpriteBatch spriteBatch, Character ch)
        {
            if (ch.Player == 1)
            {
                spriteBatch.Draw(healthBarSkin, new Rectangle((int)((1 - (ch.Health / ch.MaxHealth)) * HEALTHBAR_WIDTH), HEALTHBAR_Y, (int)((ch.Health / ch.MaxHealth) * HEALTHBAR_WIDTH + 5/* buffer*/), HEALTHBAR_HEIGHT), Color.White);
            }
            if (ch.Player == 2)
            {
                spriteBatch.Draw(healthBarSkin, new Rectangle(HEALTHBAR2_X, HEALTHBAR_Y, (int)((ch.Health / ch.MaxHealth) * HEALTHBAR_WIDTH), HEALTHBAR_HEIGHT), Color.White);
            }
        }


    }
}