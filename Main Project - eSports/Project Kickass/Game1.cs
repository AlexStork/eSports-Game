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
    /// F to Fire
    /// 
    /// Player 2:
    /// IJKL Keys
    /// H to Fire
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
        Texture2D hanzoSprite;
        Texture2D ignisSprite;
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
        Rectangle pauseSize;
        Rectangle p2charSelectImage;
        Rectangle p1charSelectImage;
        Boolean isShot;
        GameBoard board;
        Character char1;
        Character char2;
        Projectile char1Proj;
        Projectile char2Proj;
        HealthBar hbP1;
        HealthBar hbP2;
        SelectScreen selector1;
        SelectScreen selector2;
        int gameState = 0;
        bool canToggle;
        GameTime time;

        // keyboard state attribute
        KeyboardState kState;

        //External Tool
        //Ignis
        StreamReader ignisInput = new StreamReader("ignis.txt");
        int ignisProjDmg = 0;
        int ignisFPB = 0;

        //Hanzo
        StreamReader hanzoInput = new StreamReader("hanzo.txt");
        int hanzoProjDmg = 0;
        int hanzoFPB = 0;

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

            //External Tool Values ----------------------------------------------

            //Ignis
            //Read in Projectile Damage
            string inputLine = ignisInput.ReadLine();
            int.TryParse(inputLine, out ignisProjDmg);

            //Read in FPB
            inputLine = ignisInput.ReadLine();
            int.TryParse(inputLine, out ignisFPB);

            ignisInput.Close();

            //Hanzo
            //Read in Projectile Damage
            inputLine = hanzoInput.ReadLine();
            int.TryParse(inputLine, out hanzoProjDmg);

            //Read in FPB
            inputLine = hanzoInput.ReadLine();
            int.TryParse(inputLine, out hanzoFPB);

            hanzoInput.Close();
            //-------------------------------------------------------------------

            // character stuff
            hanzoSprite = Content.Load<Texture2D>("Standing Sprite.png");
            ignisSprite = Content.Load<Texture2D>("Scaled Character 1 Standing Sprite.png");
            projectile = Content.Load<Texture2D>("Projectile Sprite.png");
            characterPos = new Vector2(7, 75);
            time = new GameTime();
            char1Proj = new Projectile(10, 1, 0, 0, projectile, time);
            char2Proj = new Projectile(10, 2, 0, 7, projectile, time);
            char1 = new Character(0, 0, 100, 1, hanzoSprite, char1Proj);
            char2 = new Character(7, 3, 100, 2, ignisSprite, char2Proj);
            ignisTN = Content.Load<Texture2D>("IgnisThumbnail.png");
            p2charSelectImage = new Rectangle(510, 108, 140, 80);
            char05TN = Content.Load<Texture2D>("Char0.5Thumbnail.png");
            p1charSelectImage = new Rectangle(110, 108, 140, 80);

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
            healthBarSize = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, (GraphicsDevice.Viewport.Height)); // creates a Rectangle object to set the size of the title screen to the size of the screen
            health = Content.Load<Texture2D>("Health.png"); // loads the player health 
            hbP1 = new HealthBar(char1, health); // creates the health bar object for player 1
            hbP2 = new HealthBar(char2, health); // creates the health bar object for player 2

            // character select stuff
            frame = Content.Load<Texture2D>("CharFrame.png"); // loads the character selector frame
            sel1 = Content.Load<Texture2D>("CharSel1.png"); // loads the character selector for player 1
            sel2 = Content.Load<Texture2D>("CharSel2.png"); // loads the character selector for player 2
            selector1 = new SelectScreen(ignisTN, char05TN, sel1, frame); // creates the character selector object for player 1
            selector2 = new SelectScreen(ignisTN, char05TN, sel2, frame); // creates the character selecter object for player 2
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
                switch (selector1.P1Char) // p1
                {
                    case 0: // Ignis
                        //Image
                        char1.Skin = ignisSprite;
                        char1Proj.ProjSkin = projectile; // set later to ignis projectile

                        //External Tool Values
                        char1Proj.Damage = ignisProjDmg;
                        char1Proj.FramesPerBlock = ignisFPB;
                        break;

                    case 1: // Hanzo
                        //Image
                        char1.Skin = hanzoSprite;
                        char1Proj.ProjSkin = projectile; // set later to hanzo projectile

                        //External Tool Values
                        char1Proj.Damage = hanzoProjDmg;
                        char1Proj.FramesPerBlock = hanzoFPB;
                        break;
                }

                switch (selector2.P2Char) // p2
                {
                    case 0: // Ignis 
                        //Image
                        char2.Skin = ignisSprite;
                        char2Proj.ProjSkin = projectile; // set later to ignis projectile

                        //External Tool Values
                        char2Proj.Damage = ignisProjDmg;
                        char2Proj.FramesPerBlock = ignisFPB;
                        break;

                    case 1: // Hanzo 
                        //Image
                        char2.Skin = hanzoSprite;
                        char2Proj.ProjSkin = projectile; // set later to hanzo projectile

                        //External Tool Values
                        char2Proj.Damage = hanzoProjDmg;
                        char2Proj.FramesPerBlock = hanzoFPB;
                        break;
                }

                char1.Input(kState);
                char2.Input(kState);
                if (char1Proj.isColliding(char2) == true)
                {
                    Console.WriteLine(char1Proj.Damage + " " + char2.Health);
                    char2.takeDamage(char1Proj.Damage);
                }
                if (char2Proj.isColliding(char1) == true)
                {
                    Console.WriteLine(char2Proj.Damage + " " + char1.Health);
                    char1.takeDamage(char2Proj.Damage);
                }
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

                // character select functionality
                selector1.CharacterSelect(char1, kState);
                selector2.CharacterSelect(char2, kState);

                if (kState.IsKeyDown(Keys.Space)) // sets the gameState to active
                {
                    gameState = 2;
                }

                if (selector1.CharacterChosen == true && selector2.CharacterChosen == true) // sets the gameState to active
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

            if (gameState == 2 && char1.Health <= 0)
            {
                gameState = 3;
            }
            else if (gameState == 2 && char2.Health <= 0)
            {
                gameState = 0;
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
            char1.Draw(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            char2.Draw(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
            char1Proj.Draw(spriteBatch);
            char2Proj.Draw(spriteBatch);

            switch (gameState)
            {
                case 0: // title screen gameState
                    spriteBatch.Draw(titleScreen, titleSize, Color.White);
                    break;

                case 1: // character select screen
                    spriteBatch.Draw(background, backgroundSize, Color.White);
                    selector1.Draw(spriteBatch, char1);
                    selector2.Draw(spriteBatch, char2);
                        
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


                    // draw healthbars
                    hbP1.Draw(spriteBatch, char1);
                    hbP2.Draw(spriteBatch, char2);
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