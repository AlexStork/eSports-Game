#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using System.Threading;
#endregion

namespace Project_Kickass
{
    /// <summary>
    /// This is the main type for your game
    /// 
    /// //Alex Heerding
    /// //Aidan Kaufman
    /// //Alex Mallory
    /// //Steven Ma
    /// 
    /// ****Controls****
    /// WASD Keys
    /// Left Ctrl to fire
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // asset attributes
        Texture2D titleScreen; // the title screen
        Texture2D healthBar; // the health bar
        Texture2D tile;
        Texture2D character;
        Vector2 characterPos;
        Texture2D projectile;
        Rectangle titleSize;
        Rectangle healthBarSize;
        Thread t1;

        Vector2 projPos; 

        Boolean isActive;
        Boolean isShot;

        GameBoard board;
        Character char1;

        // keyboard state attribute
        KeyboardState kState; 

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tile = Content.Load<Texture2D>("Panels HD.png");
            character = Content.Load<Texture2D>("Standing Sprite.png");
            projectile = Content.Load<Texture2D>("Projectile Sprite.png");
            board = new GameBoard(tile);
            characterPos = new Vector2(7, 75);
            titleScreen = Content.Load<Texture2D>("TitleScreenPlaceHolder.png"); // loads the title screen
            titleSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); // creates a Rectangle object to set the size of the title screen to
            healthBar = Content.Load<Texture2D>("HealthBar.png"); // loads the title screen
            healthBarSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the title screen to
            char1 = new Character(0, 0, 100, 1, character);
            
        }

        /*
            //For use at a later date
            StreamReader input = new StreamReader("charData.txt");
            int xPos = 0;
            int yPos = 0;
            int hp = 0;
            int play = 1;

            try
            {
                string line = input.ReadLine();               
                int.TryParse(line, out xPos); //Convert lines into ints

                line = input.ReadLine();                
                int.TryParse(line, out yPos);

                line = input.ReadLine();
                int.TryParse(line, out hp);

                line = input.ReadLine();
                int.TryParse(line, out play);
            }
            catch (IOException ioe)
            {
                Console.WriteLine("Error reading file: " + ioe.Message);
            }
            finally
            {
                input.Close();
            }
            */

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            kState = Keyboard.GetState();

            char1.Input(kState);
            //// check for user input
            //if(kState.IsKeyDown(Keys.W))
            //{
            //    characterPos.Y = characterPos.Y - 75;
            //}

            //if (kState.IsKeyDown(Keys.S))
            //{
            //    characterPos.Y = characterPos.Y + 75;
            //}

            //if (kState.IsKeyDown(Keys.A))
            //{
            //    characterPos.X = characterPos.X - 15;
            //}

            //if (kState.IsKeyDown(Keys.D))
            //{
            //    characterPos.X = characterPos.X + 15; 
            //}

            if (kState.IsKeyDown(Keys.Space))
            {
                isActive = true; 
            }

            //if(kState.IsKeyDown(Keys.LeftControl))
            //{
            //    isShot = true;
            //}

            //if(characterPos.X < 0)
            //{
            //    characterPos.X = 0; 
            //}

            //if (characterPos.X > 400 - (0.4 * character.Width))
            //{
            //    characterPos.X = 400 - (0.4f * character.Width);
            //}

            //if(characterPos.Y < 65)
            //{
            //    characterPos.Y = 65;
            //}

            //if(characterPos.Y > 275)
            //{
            //    characterPos.Y = 275;
            //}

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            board.Draw(spriteBatch);
            //spriteBatch.Draw(character, characterPos, null, Color.White, 0, new Vector2(0, 0), 0.4f, SpriteEffects.None, 0);
            char1.Draw(spriteBatch);

            if(isShot == true)
            {
                for (int i = 1; i < 800; i++)
                {
                    spriteBatch.Draw(projectile, new Vector2((float)characterPos.X + i, (float)characterPos.Y), Color.White);
                    isShot = false; 
                }
            }

            if(isActive == true)
            {
                    spriteBatch.Draw(healthBar, healthBarSize, Color.White);
            }
            else spriteBatch.Draw(titleScreen, titleSize, Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
