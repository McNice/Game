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
    class Enemy : Character
    {
        public Enemy(Texture2D texture, Vector2 pos, float rotation, float speed, int health)
            : base(texture, pos, rotation, speed, health)
        {
            this.texture = texture;
            this.pos = pos;
            this.rotation = rotation;
            this.speed = speed;
            this.health = health;
        }

        public override void Update(GameTime gameTime)
        {
            Emovement(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

        void Emovement(GameTime gameTime)
        {
            
            if (pos.X >= 0)
            {
                pos.X += 1;
            }
               
        }

    }
}
