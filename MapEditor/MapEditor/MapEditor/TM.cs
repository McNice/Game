using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MapEditor
{
    public class TM
    {
        ContentManager content;
        public TM(ContentManager content)
        {
            this.content = content;
        }

        public Texture2D Texture(string s)
        {
            return content.Load<Texture2D>(s);
        }
    }
}
