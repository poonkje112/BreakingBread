using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    class Item
    {
        string itemName = null;
        Bitmap bmp;
        MissingTexture missing;
        MainGameClass game = MainGameClass.Instance;
        public Item(Bitmap bitmap)
        {
            if (bmp == null)
                missing = new MissingTexture(0, 0, 50, 50);
        }

        public void drawItem(int _x, int _y, int width, int height)
        {
            if (bmp == null)
            {
                missing.x = _x;
                missing.y = _y;
                missing.w = width;
                missing.h = height;
            } else
            {
                game.engine.DrawBitmap(bmp, _x, _y);
            }
        }
    }
}
