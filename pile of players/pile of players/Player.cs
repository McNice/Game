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
    class Player:Character
    {
        Weapon weapon;

        public Player(Texture2D texture, Vector2 pos, float speed, float rotation, int health) 
            :base (texture, pos, rotation, speed, health)
        {
            this.texture = texture;
            this.pos = pos;
            this.speed = speed;
            this.rotation = rotation;
            this.health = health;

            weapon = new Weapon(TextureManager.weaponTex, pos, 10, 50, 0.5f, 20f);
        }



        public override void Update(GameTime gameTime)
        {
            Movement(gameTime);
            Rotation(gameTime);
        }


        public override void Draw(SpriteBatch spriteBatch)
        {
            weapon.Draw(spriteBatch, rotation, pos);
            spriteBatch.Draw(TextureManager.playerTex, pos, null, Color.White, rotation, new Vector2(TextureManager.playerTex.Width/2, TextureManager.playerTex.Height/1.5f),1, SpriteEffects.None, 1f);
            
            base.Draw(spriteBatch);
        }



        void Movement(GameTime gameTime)
        {

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                pos.Y -= 10;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                pos.Y += 10;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                pos.X -= 10;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                pos.X += 10;
            }
        }

        void Rotation(GameTime gameTime)
        {
            rotation = (float)Math.Atan2(Mouse.GetState().Y- pos.Y, Mouse.GetState().X - pos.X);
        }
    }
}
