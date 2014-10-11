using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor
{
    class Tile
    {
        string name;
        Texture2D tex;
        Vector2 pos;
        public Tile(string name, Vector2 pos)
        {
            this.name = name;
            this.pos = pos;
            LoadContent();
        }
        void LoadContent()
        {
            tex = Game1.tm.Texture(name);
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, null, Color.White, 0, Vector2.Zero, .5f, SpriteEffects.None, 0);
        }

        public void EditTile(string name)
        {
            this.name = name;
            LoadContent();
        }
    }
}
