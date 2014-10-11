using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Lidgren.Network;

namespace Client
{
    public class InputManager
    {
        MoveY movey;
        MoveX movex;

        public void Update(GameTime gt)
        {
            movey = MoveY.NONE;
            movex = MoveX.NONE;
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                movey = MoveY.UP;
            else if (Keyboard.GetState().IsKeyDown(Keys.S))
                movey = MoveY.UP;

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                movex = MoveX.RIGHT;
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
                movex = MoveX.LEFT;

        }

        public InputManager() { }

    }

    enum MoveY
    {
        UP,
        DOWN,
        NONE
    }

    enum MoveX
    {
        RIGHT,
        LEFT,
        NONE
    }
}
