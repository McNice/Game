using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MapEditor
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Form1 form;
        MouseState mS;
        public static TM tm;
        public static string tileType = "b";

        static int tileSize = 24;
        static int mapSize = 40;

        static int WIDTH = mapSize * tileSize;

        Tile[,] mapArray = new Tile[mapSize, mapSize];

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = WIDTH;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            form = new Form1();
            form.Show();
            mS = new MouseState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            tm = new TM(Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    mapArray[i, j] = new Tile("t", new Vector2(i * tileSize, j * tileSize));
                }
            }
        }

       
        protected override void Update(GameTime gameTime)
        {
            mS = Mouse.GetState();
            if (mS.LeftButton == ButtonState.Pressed)
            {
                if (0 < mS.X && mS.X < WIDTH && 0 < mS.Y && mS.Y < WIDTH)
                {
                    int x = Math.Abs(mS.X / tileSize);
                    int y = Math.Abs(mS.Y / tileSize);

                    mapArray[x, y].EditTile(tileType);
                }
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            foreach (Tile t in mapArray)
            {
                t.Draw(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
