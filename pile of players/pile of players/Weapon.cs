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
    class Weapon
    {
        Texture2D texture;
        Vector2 pos;
        int damage, maxAmmo;
        float fireRate, bulletSpeed;
        MouseState mouseState;

        public Weapon(Texture2D texture, Vector2 pos, int damage, int maxAmmo, float fireRate, float bulletSpeed)
        {
            this.texture = texture;
            this.pos = pos;
            this.damage = damage;
            this.maxAmmo = maxAmmo;
            this.fireRate = 0.2f;
            this.bulletSpeed = 10;
        }

            public void Update(GameTime gameTime)
            {
                mouseState = Mouse.GetState();
            }

            public void Draw(SpriteBatch spriteBatch, float rotation, Vector2 pos)
            {
                spriteBatch.Draw(texture, pos, null, Color.White, rotation, new Vector2(0,texture.Height/2), 1, SpriteEffects.None, 1);
            }

            

    }


    
}
