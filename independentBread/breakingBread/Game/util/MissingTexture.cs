using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.util
{
    class MissingTexture : pGameObject
    {
        int x, y, w, h;
        MainGameClass game = MainGameClass.Instance;

        public MissingTexture(int _x, int _y, int width, int height)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;
            Subscribe(this);
        }

        public override void pUpdate()
        {
            
        }

        public override void pDraw()
        {
            game.engine.SetColor(255, 25, 195);
            game.engine.FillRectangle(x, y, w / 2, h / 2);
            game.engine.FillRectangle(x + (w / 2), y + (h / 2), w / 2, h / 2);
            game.engine.SetColor(0, 0, 0);
            game.engine.FillRectangle(x + (w / 2), y, w / 2, h / 2);
            game.engine.FillRectangle(x, y + (h / 2), w / 2, h / 2);
        }

        public override void Destroy()
        {
            
        }
    }
}
