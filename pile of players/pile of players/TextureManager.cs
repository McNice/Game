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

using System.IO;

namespace pile_of_players
{
    public class TextureManager
    {
        public static Texture2D playerTex, weaponTex, bulletTex;

        public void LoadContent(ContentManager CM)
        {
            playerTex = CM.Load<Texture2D>("bollen");
            weaponTex = CM.Load<Texture2D>("Weapon");
            bulletTex = CM.Load<Texture2D>("blooood");
        }


    }
}
