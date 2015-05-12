using System;
using System.Collections.Generic;
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
    // Alex Mallory
    class Sprite
    {
        // attributes
        private Texture2D image; // spritesheet to be animated 
        private Point imageSize; // dimensions of each frame 
        private Point currentFrame; // upper left corner of the displayed image 
        private Vector2 position; // location of the image
        private int frame; // frame # being displayed
        private int numFrames; // number of frames in the spritesheet 
        private int timePerFrame; // elapsed time since last frame 
        private int timeSinceLastFrame; // amount of time per frame

        // property
        public int TimePerFrame
        {
            set { timePerFrame = value; }
        }

        // constructor
        public Sprite(Texture2D img, Point size, Vector2 location, int frames, int msPerFrame)
        {
            image = img;
            imageSize = size;
            position = location;
            numFrames = frames;
            timePerFrame = msPerFrame;
            currentFrame.X = 0;
            currentFrame.Y = 0;
        }

        // update method
        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if(timeSinceLastFrame > timePerFrame)
            {
                timeSinceLastFrame = 0;
                frame++;

                if(frame >= numFrames)
                {
                    frame = 0;
                }

                currentFrame.X = imageSize.X * frame; 
            }
        }

        // draw method
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                image,
                position,
                new Rectangle(currentFrame.X, currentFrame.Y, imageSize.X, imageSize.Y),
                Color.White,
                0,
                Vector2.Zero,
                1f, 
                SpriteEffects.None,
                0
                );
        }
    }
}
