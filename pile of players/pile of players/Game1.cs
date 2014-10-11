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

namespace pile_of_players
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Player player;
        TextureManager TM;
        Enemy enemy;
        Weapon weapon;
        ProjectileManager PM;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {


            base.Initialize();
        }


        protected override void LoadContent()
        {
            TM = new TextureManager();
            TM.LoadContent(this.Content);
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player = new Player(TextureManager.playerTex, new Vector2(100, 100), 5, 1f, 100);
            enemy = new Enemy(TextureManager.playerTex, new Vector2(0,0), 5, 1f, 100);
            weapon = new Weapon(TextureManager.weaponTex, new Vector2(100, 100), 10, 50, 0.5f, 15f);
            PM = new ProjectileManager(player);

            

        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            IsMouseVisible = true;

            player.Update(gameTime);
            enemy.Update(gameTime);
            weapon.Update(gameTime);
            PM.Update(gameTime);

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            weapon.Draw(spriteBatch, 0, Vector2.Zero);
            PM.Draw(spriteBatch);


            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
