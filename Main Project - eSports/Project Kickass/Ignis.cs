﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;

namespace Project_Kickass
{

    class Ignis:Character
    {
        public Ignis(int x, int y, int hp, int play, Texture2D color, Projectile proj)
            : base(x, y, hp, play, color, proj)
        {
           
        }

        
    }
}
