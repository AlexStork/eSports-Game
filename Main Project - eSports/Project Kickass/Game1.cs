﻿#region Using Statements
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
    /// Player 1:
    /// WASD Keys
    /// 
    /// Player 2:
    /// IJKL Keys
    /// 
    /// ****IMPORTANT********IMPORTANT****
    /// To progress to game from the main menu:
    /// Press space then enter
    /// 
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // asset attributes
        Texture2D titleScreen; // the title screen
        Texture2D healthBar; // the health bar
        Texture2D health; // the health of each player
        Texture2D tile;
        Texture2D character;
        Texture2D character2;
        Texture2D pauseScreen;
        Texture2D background;
        Texture2D frame;
        Texture2D sel1;
        Texture2D sel2;
        Texture2D ignisTN;
        Texture2D char05TN;
        public Texture2D projSkin;
        Vector2 characterPos;
        Texture2D projectile;
        Rectangle titleSize;
        Rectangle healthBarSize;
        Rectangle backgroundSize;
        Rectangle frame1Size;
        Rectangle frame2Size;
        Rectangle sel1Size;
        Rectangle sel2Size;
        Rectangle pauseSize;
        Rectangle health1Size;
        Rectangle health2Size;
        Rectangle ignisTNRect;
        Rectangle char05TNRect;
        Boolean isShot;
        GameBoard board;
        Character char1;
        Character char2;
        Projectile char1Proj;
        Projectile char2proj;
        int gameState = 0;
        bool canToggle;

        // keyboard state attribute
        KeyboardState kState;

        //Ignis External Tool
        StreamReader input = new StreamReader("ignis.txt");
        int ignisHP = 0;
        int ignisProjDmg = 0;

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
            // stage stuff
            tile = Content.Load<Texture2D>("Panels HD.png");
            board = new GameBoard(tile);

            // character stuff
            character = Content.Load<Texture2D>("Standing Sprite.png");
            character2 = Content.Load<Texture2D>("Scaled Character 1 Standing Sprite.png");
            projectile = Content.Load<Texture2D>("Projectile Sprite.png");
            characterPos = new Vector2(7, 75);
            char1Proj = new Projectile(10, 1, 0, 0,projectile);
            char2proj = new Projectile(10, 2, 0, 7,projectile);
            char1 = new Character(0, 0, 100, 1, character, char1Proj);
            char2 = new Character(0, 7, 100, 2, character2,char2proj);
            ignisTN = Content.Load<Texture2D>("IgnisThumbnail.png");
            ignisTNRect = new Rectangle(510, 108, 140, 80);
            char05TN = Content.Load<Texture2D>("Char0.5Thumbnail.png");
            char05TNRect = new Rectangle(110, 108, 140, 80);

            // screen stuff
            titleScreen = Content.Load<Texture2D>("TitleScreen.png"); // loads the title screen
            titleSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height); // creates a Rectangle object to set the size of the title screen to the size of the screen
            pauseScreen = Content.Load<Texture2D>("PauseScreenTemp.png"); // loads the pause screen
            pauseSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the pause screen to the size of the screen
            background = Content.Load<Texture2D>("Background.png"); // loads the background screen
            backgroundSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the background screen to the size of the screen

            // projectile stuff
            projSkin = Content.Load<Texture2D>("Proj1Fireball.png");

            // health bar stuff
            healthBar = Content.Load<Texture2D>("HealthBar.png"); // loads the health bar
            healthBarSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the title screen to
            health = Content.Load<Texture2D>("Health.png"); // loads the player health 
            health1Size = new Rectangle(0, 28, 600, 52); // creates a Rectangle object to set the size of player 1's health to
            health2Size = new Rectangle(500, 28, 600, 52); // creates a Rectangle object to set the size of player 2's health to
            healthBarSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the title screen to the size of the screen

            // character select stuff
            frame = Content.Load<Texture2D>("CharFrame.png"); // loads the character selector frame
            frame1Size = new Rectangle(100, 100, GraphicsDevice.Viewport.Width / 5, GraphicsDevice.Viewport.Height / 5); // creates a Rectangle object to set the size of the character selector frame
            frame2Size = new Rectangle(500, 100, GraphicsDevice.Viewport.Width / 5, GraphicsDevice.Viewport.Height / 5); // creates a Rectangle object to set the size of the character selector frame
            sel1 = Content.Load<Texture2D>("CharSel1.png"); // loads the character selector for player 1
            sel2 = Content.Load<Texture2D>("CharSel2.png"); // loads the character selector for player 2
            sel1Size = new Rectangle(96, 73, 168, 126); // creates a Rectangle object to set the size of the character selector frame
            sel2Size = new Rectangle(496, 73, 168, 126); // creates a Rectangle object to set the size of the character selector frame

            //External Tool Values ----------------------------------------------
            //Read in Health
            string inputLine = input.ReadLine();
            int.TryParse(inputLine, out ignisHP);

            //Read in Projectile Damage
            inputLine = input.ReadLine();
            int.TryParse(inputLine, out ignisProjDmg);

            input.Close();
            //-------------------------------------------------------------------
        }

        

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

            if (gameState == 2) // gameState has to be 'active' for commands to register
            {
                char1.Input(kState);
                char2.Input(kState);
            }

            if (gameState == 0)
            {
                if (kState.IsKeyDown(Keys.Enter)) // sets the gameState to character select
                {
                    gameState = 1;

                }
            }

            if (gameState == 1)
            {
                if (kState.IsKeyDown(Keys.Space)) // sets the gameState to active
                {
                    gameState = 2;
                }
            }

            if (gameState == 2 && kState.IsKeyDown(Keys.Tab) && canToggle == true) // if active and player presses tab, pause
            {
                canToggle = false;
                gameState = 3;
            }

            if (gameState == 3 && kState.IsKeyDown(Keys.Tab) && canToggle == true) // if paused and player presses tab, unpause
            {
                canToggle = false;
                gameState = 2;
            }

            if (gameState == 2 || gameState == 3)
            {
                if (kState.IsKeyUp(Keys.Tab))
                {
                    canToggle = true;
                }
            }

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
            char1.Draw(spriteBatch,GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            char2.Draw(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            char1Proj.Draw(spriteBatch);
            char2proj.Draw(spriteBatch);

            switch (gameState)
            {
                case 0: // title screen gameState
                    spriteBatch.Draw(titleScreen, titleSize, Color.White);
                    break;

                case 1: // character select screen
                    spriteBatch.Draw(background, backgroundSize, Color.White);
                    spriteBatch.Draw(sel1, sel1Size, Color.White);
                    spriteBatch.Draw(sel2, sel2Size, Color.White);
                    spriteBatch.Draw(frame, frame1Size, Color.White);
                    spriteBatch.Draw(frame, frame2Size, Color.White);
                    spriteBatch.Draw(ignisTN, ignisTNRect, Color.White);
                    spriteBatch.Draw(char05TN, char05TNRect, Color.White);
                    break;

                case 2: // active gameState
                    if (isShot == true)
                    {
                        for (int i = 1; i < 800; i++)
                        {
                            spriteBatch.Draw(projectile, new Vector2((float)characterPos.X + i, (float)characterPos.Y), Color.White);
                            isShot = false;
                        }
                    }


                    spriteBatch.Draw(health, health1Size, Color.White);
                    spriteBatch.Draw(health, health2Size, Color.White);
                    spriteBatch.Draw(healthBar, healthBarSize, Color.White);
                    break;

                case 3: // pause gameState
                    
                    spriteBatch.Draw(healthBar, healthBarSize, Color.White);
                    spriteBatch.Draw(pauseScreen, pauseSize, Color.White);
                    break;
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
