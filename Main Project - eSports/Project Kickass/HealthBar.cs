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
                spriteBatch.Draw(healthBarSkin, new Rectangle(460, 28, (int) ((ch.Health / 100) * 340), 52), Color.White);
            }
            if (ch.Player == 2)
            {
                spriteBatch.Draw(healthBarSkin, new Rectangle((int) ((1 - (ch.Health / 100)) * 340), 28, (int) ((ch.Health / 100)  * 345), 52), Color.White);
            }
        }


    }
}