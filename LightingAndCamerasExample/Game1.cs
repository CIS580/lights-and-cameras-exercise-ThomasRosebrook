﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LightingAndCamerasExample
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // our crate
        Crate[] crates;

        // The camera 
        //CirclingCamera camera;
        FPSCamera camera;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Make some crates
            crates = new Crate[] {
                new Crate(this, CrateType.DarkCross, Matrix.Identity),
                new Crate(this, CrateType.Slats, Matrix.CreateTranslation(4, 0, 5)),
                new Crate(this, CrateType.Cross, Matrix.CreateTranslation(-8, 0, 3)),
                new Crate(this, CrateType.DarkCross, Matrix.CreateRotationY(MathHelper.PiOver4) * Matrix.CreateTranslation(1, 0, 7)),
                new Crate(this, CrateType.Slats, Matrix.CreateTranslation(3, 0, -3)),
                new Crate(this, CrateType.Cross, Matrix.CreateRotationY(3) * Matrix.CreateTranslation(3, 2, -3))
            };

            //camera = new CirclingCamera(this, new Vector3(0, 5, 10), 0.5f);
            camera = new FPSCamera(this, new Vector3(0, 3, 10));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            camera.Update(gameTime);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Crate crate in crates)
            {
                crate.Draw(camera);
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
