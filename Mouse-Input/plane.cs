using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Project1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D missleSprite;
        Texture2D planeSprite;
        Texture2D skySprite;

        Vector2 planePossition;
        float rotationAngle;
        MouseState mouseState;
        Vector2 target;
        bool locked;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            planePossition = new Vector2(16, 16);
            rotationAngle = MathHelper.ToRadians(0);
            locked = false;
            target = new Vector2(0, 0);

            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            missleSprite = Content.Load<Texture2D>("missle");
            planeSprite = Content.Load<Texture2D>("plane");
            skySprite = Content.Load<Texture2D>("aa9bb7ffc6d502e9112ec8c7e9350175");

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                locked = true;
                target.X = mouseState.X;
                target.Y = mouseState.Y;
            }
            if (locked)
            {
                if ((target - planePossition).Length() <= 10)
                {
                    locked = false;
                    planePossition = target;
                }
                else
                {
                    planePossition = planePossition + (target - planePossition) / (target - planePossition).Length() * 10;
                }
            }

            Console.WriteLine(planePossition);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(skySprite, new Vector2(0, 0), Color.White);
            _spriteBatch.Draw(planeSprite, planePossition, null, Color.White, rotationAngle, new Vector2(planeSprite.Width / 2, planeSprite.Height / 2), 1.0f, SpriteEffects.None, 0);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}