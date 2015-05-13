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
    /// numpad 1 to Fire
    /// 
    /// Player 2:
    /// IJKL Keys
    /// numpad 2 to Fire
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

        // enumerators
        private enum GameState
        {   
            MAIN_MENU,
            SELECT_SCREEN,
            IN_GAME,
            PAUSE_SCREEN,
            WIN_SCREEN
        }

        // asset attributes
        Texture2D titleScreen; // the title screen
        Texture2D healthBar; // the health bar
        Texture2D health; // the health of each player
        Texture2D tile;
        Texture2D hanzoSprite;
        Texture2D ignisSprite;
        Texture2D steveSprite;
        Texture2D pauseScreen;
        Texture2D background;
        Texture2D frame;
        Texture2D sel1;
        Texture2D sel2;
        Texture2D ignisTN;
        Texture2D hanzoTN;
        Texture2D steveTN;
        Texture2D ignisProj;
        Texture2D hanzoProj;
        Texture2D steveProj;
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
        //Character char1;
        //Character char2;
        Projectile char1Proj1;
        Projectile char2Proj1;
        Projectile igFireBall1; //Ability Passive
        Projectile igFireBall2; //Ability Passive
        HealthBar hbP1;
        HealthBar hbP2;
        SelectScreen selector1;
        SelectScreen selector2;
        GameState gameState = GameState.MAIN_MENU;
        bool canToggle;
        GameTime time;
        Character char1;
        Character char2;
       // Hanzo han1;
        //Hanzo han2;

        // keyboard state attribute
        KeyboardState kState;

        //External Tool-----------------------------------------------------------------
        //Ignis
        StreamReader ignisInput = new StreamReader("ignis.txt");
        int ignisHealth = 0;
        int ignisProjDmg = 0;
        int ignisFPB = 0;

        //Hanzo
        StreamReader hanzoInput = new StreamReader("hanzo.txt");
        int hanzoHealth = 0;
        int hanzoProjDmg = 0;
        int hanzoFPB = 0;

        //Steve
        StreamReader steveInput = new StreamReader("steve.txt");
        int steveHealth = 0;
        int steveProjDmg = 0;
        int steveFPB = 0;
        //-------------------------------------------------------------------------------

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
            //Read in Health Damage
            string inputLine = ignisInput.ReadLine();
            int.TryParse(inputLine, out ignisHealth);

            //Read in Projectile Damage
            inputLine = ignisInput.ReadLine();
            int.TryParse(inputLine, out ignisProjDmg);

            //Read in FPB
            inputLine = ignisInput.ReadLine();
            int.TryParse(inputLine, out ignisFPB);

            ignisInput.Close();


            //Hanzo
            //Read in Health Damage
            inputLine = hanzoInput.ReadLine();
            int.TryParse(inputLine, out hanzoHealth);

            //Read in Projectile Damage
            inputLine = hanzoInput.ReadLine();
            int.TryParse(inputLine, out hanzoProjDmg);

            //Read in FPB
            inputLine = hanzoInput.ReadLine();
            int.TryParse(inputLine, out hanzoFPB);

            hanzoInput.Close();


            //Steve
            //Read in Health Damage
            inputLine = steveInput.ReadLine();
            int.TryParse(inputLine, out steveHealth);

            //Read in Projectile Damage
            inputLine = steveInput.ReadLine();
            int.TryParse(inputLine, out steveProjDmg);

            //Read in FPB
            inputLine = steveInput.ReadLine();
            int.TryParse(inputLine, out steveFPB);

            steveInput.Close();
            //-------------------------------------------------------------------

            // character stuff
            hanzoSprite = Content.Load<Texture2D>("Standing Sprite.png");
            ignisSprite = Content.Load<Texture2D>("Scaled Character 1 Standing Sprite.png");
            steveSprite = Content.Load<Texture2D>("Steve Standing.png");
            projectile = Content.Load<Texture2D>("Projectile Sprite.png");
            ignisProj = Content.Load<Texture2D>("Ignis Projectile.png");
            hanzoProj = Content.Load<Texture2D>("Hanzo Projectile.png");
            steveProj = Content.Load<Texture2D>("St3v3 Projectile.png");
            characterPos = new Vector2(7, 75);
            time = new GameTime();
            char1Proj1 = new Projectile(10, 1, 8, 0, projectile, time);
            char2Proj1 = new Projectile(10, 2, -1, 7, projectile, time);
            igFireBall1 = new Projectile(15, 1, 8, 0, projectile, time);
            igFireBall2 = new Projectile(15, 2, -1, 7, projectile, time);
            //char1 = new Ignis(0, 0, 100, 1, ignisSprite, char1Proj1, igFireBall1);
            //char2 = new Ignis(7, 3, 100, 2, ignisSprite, char2Proj1, igFireBall2);
            //han1 = new Hanzo(0, 0, 100, 1, hanzoSprite, char1Proj1);
            //han2 = new Hanzo(7, 3, 100, 2, hanzoSprite, char2Proj1);
            ignisTN = Content.Load<Texture2D>("IgnisThumbnail.png");
            p2charSelectImage = new Rectangle(510, 108, 140, 80);
            hanzoTN = Content.Load<Texture2D>("Character 2 Thumbnail");
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
            hbP1 = new HealthBar(char1, health); // creates the health bar object for player 1 ignis
            hbP2 = new HealthBar(char2, health); // creates the health bar object for player 2 ignis

            // character select stuff
            frame = Content.Load<Texture2D>("CharFrame.png"); // loads the character selector frame
            sel1 = Content.Load<Texture2D>("CharSel1.png"); // loads the character selector for player 1
            sel2 = Content.Load<Texture2D>("CharSel2.png"); // loads the character selector for player 2
            selector1 = new SelectScreen(ignisTN, hanzoTN, sel1, frame, 1); // creates the character selector object for player 1
            selector2 = new SelectScreen(ignisTN, hanzoTN, sel2, frame, 2); // creates the character selecter object for player 2
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

            if (gameState == GameState.IN_GAME) // gameState has to be 'active' for commands to register
            {
                switch (selector1.PlayerChar) // p1
                {
                    case CharacterType.IGNIS: // Ignis
                        //Image
                        char1Proj1.ProjSkin = ignisProj; // set later to ignis projectile

                        //External Tool Values
                        char1Proj1.Damage = ignisProjDmg;
                        char1Proj1.FramesPerBlock = ignisFPB;
                        break;

                    case CharacterType.HANZO: // Hanzo
                        //Image
                        char1Proj1.ProjSkin = hanzoProj; // set later to hanzo projectile

                        //External Tool Values
                        char1Proj1.Damage = hanzoProjDmg;
                        char1Proj1.FramesPerBlock = hanzoFPB;
                        break;
                }

                switch (selector2.PlayerChar) // p2
                {
                    case CharacterType.IGNIS: // Ignis 
                        //Image
                        char2Proj1.ProjSkin = ignisProj; // set later to ignis projectile
                        
                        //External Tool Values
                        char2Proj1.Damage = ignisProjDmg;
                        char2Proj1.FramesPerBlock = ignisFPB;;
                        break;

                    case CharacterType.HANZO: // Hanzo 
                        //Image
                        char2Proj1.ProjSkin = hanzoProj; // set later to hanzo projectile

                        //External Tool Values
                        char2Proj1.Damage = hanzoProjDmg;
                        char2Proj1.FramesPerBlock = hanzoFPB;
                        break;
                }

                char1.Input(kState);
                char2.Input(kState);
                //han1.Input(kState);
                //han2.Input(kState);
                if (char1Proj1.isColliding(char2) == true)
                {
                    Console.WriteLine(char1Proj1.Damage + " " + char2.Health);
                    char2.takeDamage(char1Proj1.Damage);
                }

                //Flame's Wake
                if (igFireBall1.isColliding(char2) == true)
                {
                    Console.WriteLine(igFireBall1.Damage + " " + char2.Health);
                    char2.takeDamage(igFireBall1.Damage);
                }
                
                
                if (char2Proj1.isColliding(char1) == true)
                {
                    Console.WriteLine(char2Proj1.Damage + " " + char1.Health);
                    char1.takeDamage(char2Proj1.Damage);
                }
            }

            if (gameState == GameState.MAIN_MENU)
            {
                if (kState.IsKeyDown(Keys.Enter)) // sets the gameState to character select
                {
                    gameState = GameState.SELECT_SCREEN;

                }
            }

            if (gameState == GameState.SELECT_SCREEN)
            {

                // character select functionality
                selector1.CharacterSelect(kState);
                selector2.CharacterSelect(kState);

                if (selector1.CharacterChosen == true && selector2.CharacterChosen == true) // sets the gameState to active
                {
                    gameState = GameState.IN_GAME;
                    
                    // Player 1 character load
                    if (selector1.PlayerChar == CharacterType.IGNIS)
                    {
                        char1 = new Ignis(0, 0, ignisHealth, 1, ignisSprite, char1Proj1, igFireBall1);
                    }

                    if (selector1.PlayerChar == CharacterType.HANZO)
                    {
                        char1 = new Hanzo(0, 0, hanzoHealth, 1, hanzoSprite, char1Proj1);
                    }

                    // Player 2 character load
                    if (selector2.PlayerChar == CharacterType.IGNIS)
                    {
                        char2 = new Ignis(7, 3, ignisHealth, 2, ignisSprite, char2Proj1, igFireBall2);
                    }

                    if (selector2.PlayerChar == CharacterType.HANZO)
                    {
                        char2 = new Hanzo(7, 3, hanzoHealth, 2, hanzoSprite, char2Proj1);
                    }

                }

            }

            if (gameState == GameState.IN_GAME && kState.IsKeyDown(Keys.Tab) && canToggle == true) // if active and player presses tab, pause
            {
                canToggle = false;
                gameState = GameState.PAUSE_SCREEN;
            }

            if (gameState == GameState.PAUSE_SCREEN && kState.IsKeyDown(Keys.Tab) && canToggle == true) // if paused and player presses tab, unpause
            {
                canToggle = false;
                gameState = GameState.IN_GAME;
            }

            if (gameState == GameState.IN_GAME || gameState == GameState.PAUSE_SCREEN)
            {
                if (kState.IsKeyUp(Keys.Tab))
                {
                    canToggle = true;
                }
            }

            if (gameState == GameState.IN_GAME && char1.Health <= 0)
            {
                gameState = GameState.PAUSE_SCREEN;
            }
            else if (gameState == GameState.IN_GAME && char2.Health <= 0)
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
            GraphicsDevice.Clear(Color.HotPink);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            board.Draw(spriteBatch);
            char1Proj1.Draw(spriteBatch);
            char2Proj1.Draw(spriteBatch);
            igFireBall1.Draw(spriteBatch);

            switch (gameState)
            {
                case GameState.MAIN_MENU: // title screen gameState
                    spriteBatch.Draw(titleScreen, titleSize, Color.White);
                    break;

                case GameState.SELECT_SCREEN: // character select screen
                    spriteBatch.Draw(background, backgroundSize, Color.White);
                    selector1.Draw(spriteBatch);
                    selector2.Draw(spriteBatch);
                        
                    break;

                case GameState.IN_GAME: // active gameState

                    char1.Draw(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);
                    char2.Draw(spriteBatch, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);


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

                case GameState.PAUSE_SCREEN: // pause gameState

                    spriteBatch.Draw(healthBar, healthBarSize, Color.White);
                    spriteBatch.Draw(pauseScreen, pauseSize, Color.White);
                    break;
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}