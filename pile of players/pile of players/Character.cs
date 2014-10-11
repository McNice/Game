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
    abstract class Character
    {
        protected Texture2D texture;
        public Vector2 pos;
        protected float rotation, speed;
        protected int health;

        public Character(Texture2D texture, Vector2 pos, float rotation, float speed, int health)
        {
            this.texture = texture;
            this.pos = pos;
            this.rotation = rotation;
            this.speed = speed;
            this.health = health;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
        }


    }
}
