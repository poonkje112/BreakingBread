using breakingBread.breakingBread.Game.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    class Player : pGameObject
    {
        int x, y, w, h, animation;
        public Player(int _x, int _y, int width, int height, int animationIndex)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;
            animation = animationIndex;
            new MissingTexture(x,y,w,h);
            Subscribe(this);
        }
    }
}
