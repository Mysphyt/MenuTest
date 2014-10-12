#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace MenuTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;

        SpriteBatch spriteBatch;
        // Hardcode each texture (this is a bad idea)
        public static Texture2D GAME;
        public static Texture2D MENU;
        bool menu = true;
        private MouseState oldState;
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 900;
            graphics.ApplyChanges();
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

            //The MouseState class contains all of the information that we could possibly want to know about the current state of the mouse.
            GAME = Content.Load<Texture2D>("Game.png");
            MENU = Content.Load<Texture2D>("Menu.png");
            // TODO: use this.Content to load your game content here
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

            // Set the mouse visibility to true
            this.IsMouseVisible = true;

            MouseState newState = Mouse.GetState();
            if (menu == true)
            {
                // Update the menu
                if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                {
                    // do something here
                    if ((newState.X > 200 && newState.Y < 700) && (newState.Y > 400 && newState.Y < 600))
                    {
                        menu = false;
                    }

                    /* This code first gets the current mouse state, and then checks to see if in the current state, the button was pressed, and if it was released in the old state (from the last update).
                     * This is equivalent to a button press, since it was up before and down now. If it was pressed, then do whatever you want it to do, and then finally, set the old mouse state to be this current state.
                     * By the time the next update comes around, this will be the old mouse state.
                    */
                }
                oldState = newState; // this reassigns the old state so that it is ready for next time
            }
            else if (menu == false)
            {
                //Update the game
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            // TODO: Add your drawing code here
            if(menu == true)
            {
                // Draw Menu
                spriteBatch.Draw(MENU, new Vector2(0, 0), Color.White);
            }
            else if(menu == false)
            {
                // Draw Game
                spriteBatch.Draw(GAME, new Vector2(0, 0), Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
