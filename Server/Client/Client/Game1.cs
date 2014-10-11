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

namespace Client
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        InputManager IM = new InputManager();
        ConnectionManager CM = new ConnectionManager();

        Texture2D test;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            CM.Initialize("localhost", "Dick");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            test = new Texture2D(GraphicsDevice, 2, 2);
            Color[] a = { Color.Black, Color.Black, Color.Black, Color.Black };
            test.SetData<Color>(a);

        }

        protected override void Update(GameTime gameTime)
        {
            CM.ReciveMessage();
            IM.Update(gameTime);
            CM.SendMovement((byte)IM.movey, (byte)IM.movex);
            Window.Title = "Players: " + CM.PlayerCount();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            foreach (Player p in CM.players)
            {
                spriteBatch.Draw(test,  new Rectangle(CM.players.IndexOf(p) * 100, CM.players.IndexOf(p) * 100,10,10), Color.Red);
            }

            spriteBatch.End();


            

            base.Draw(gameTime);
        }
    }
}
