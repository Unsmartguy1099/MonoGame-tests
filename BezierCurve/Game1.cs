using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BezierCurve
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private BezierCurve bezierCurve;
        private Texture2D pixelTexture;

        Vector2 p1;
        Vector2 p2;
        Vector2 p3;
        Vector2 p4;
        Vector2 p5;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Define your control points
            p1 = new Vector2(100, 100);
            p2 = new Vector2(100, 200);
            p3 = new Vector2(300, 30);
            p4 = new Vector2(400, 250);
            p5 = new Vector2(500, 500);

            bezierCurve = new BezierCurve(p1, p2, p3, p4, p5);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            pixelTexture = Content.Load<Texture2D>("redPixel");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            bezierCurve.Draw(_spriteBatch,10000, pixelTexture);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}