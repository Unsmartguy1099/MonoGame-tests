using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.Sockets;
using Autotiling1;
using System.Collections.Generic;
using System;

namespace Autotiling1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Tile T11;
        Tile T21;
        Tile T31;
        Tile T12;
        Tile T22;
        Tile T32;
        Tile T13;
        Tile T23;
        Tile T33;

        Tile C11;
        Tile C12;
        Tile C21;
        Tile C22;

        int[,] tilemap;
        Dictionary<int, Tile> tileDictionary;

        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tilemap = new int[50, 30];
            tileDictionary = new Dictionary<int, Tile>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //top,bottom,left,right,topleft,topright,bottomleft,bottomright
            T11 = new Tile(Content.Load<Texture2D>("topleft"),new int[,] {{}});
            T12 = new Tile(Content.Load<Texture2D>("topmiddle"),new int[,] {{}});
            T13 = new Tile(Content.Load<Texture2D>("topright"),new int[,] {{}});
            T21 = new Tile(Content.Load<Texture2D>("middleleft"),new int[,] {{}});
            T22 = new Tile(Content.Load<Texture2D>("center"),new int[,] {{}});
            T23 = new Tile(Content.Load<Texture2D>("middleright"),new int[,] {{}});
            T31 = new Tile(Content.Load<Texture2D>("bottomleft"),new int[,] {{}});
            T32 = new Tile(Content.Load<Texture2D>("bottommiddle"),new int[,] {{}});
            T33 = new Tile(Content.Load<Texture2D>("bottomright"),new int[,] {{}});
            C11 = new Tile(Content.Load<Texture2D>("topLC"),new int[,] {{}});
            C12 = new Tile(Content.Load<Texture2D>("topRC"),new int[,] {{}});
            C21 = new Tile(Content.Load<Texture2D>("bottomLC"),new int[,] {{}});
            C22 = new Tile(Content.Load<Texture2D>("bottomRC"),new int[,] {{}});

            tileDictionary.Add(11, T11);
            tileDictionary.Add(12, T12);
            tileDictionary.Add(13, T13);
            tileDictionary.Add(21, T21);
            tileDictionary.Add(22, T22);
            tileDictionary.Add(23, T23);
            tileDictionary.Add(31, T31);
            tileDictionary.Add(32, T32);
            tileDictionary.Add(33, T33);
            tileDictionary.Add(110, C11);
            tileDictionary.Add(120, C12);
            tileDictionary.Add(210, C21);
            tileDictionary.Add(220, C22);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            mouseState = Mouse.GetState();
            if (mouseState.LeftButton == ButtonState.Pressed && mouseState.X<800 && mouseState.X > 0 && mouseState.Y<480 && mouseState.Y >0)
            {   
                tilemap[mouseState.X / 16, mouseState.Y / 16] = 22;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 30; j++)
                    if (tilemap[i, j] != 0)
                        _spriteBatch.Draw(tileDictionary[tilemap[i, j]].Texture, new Vector2(i * 16, j * 16), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}