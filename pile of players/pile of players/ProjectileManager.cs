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
    class ProjectileManager
    {
        MouseState mouseState;
        Projectile projectile;
        Weapon weapon;
        Player p;
        List<Projectile> projectiles = new List<Projectile>();
        
        float bulletSpeed = 2;
        Texture2D texture;

        public ProjectileManager(Player p) {
            this.p = p;
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                Shoooooooot(gameTime);
            }

            foreach (Projectile p in projectiles)
            {
                
                p.Update(gameTime);
                
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Projectile p in projectiles)
            {
                p.Draw(spriteBatch);
            }
        }

        public void Shoooooooot(GameTime gameTime)
        {
            Vector2 direction = new Vector2(mouseState.X - p.pos.X, mouseState.Y - p.pos.Y);
                direction.Normalize();
                projectiles.Add(new Projectile(TextureManager.bulletTex, p.pos, direction, bulletSpeed));
        }
    }
}
