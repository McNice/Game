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
    class Projectile
    {
        Texture2D texture;
        Vector2 pos, direction;
        float bulletSpeed;
        

        public Projectile(Texture2D texture, Vector2 pos, Vector2 direction ,float bulletSpeed)
        {
            this.direction = direction;
            this.texture = texture;
            this.pos = pos;
            this.bulletSpeed = bulletSpeed;
        }

        public void Update(GameTime gameTime)
        {
            pos += direction * bulletSpeed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }
    }
}
