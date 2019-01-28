using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.IO;

namespace breakingBread.breakingBread.Game.gameObjects
{
    class Background : pGameObject
    {
        Bitmap bmp;
        MainGameClass game = MainGameClass.Instance;
        public Vector2f scale = new Vector2f(1f, 1f);
        bool missingTexture = false;
        public Background(string bitmap)
        {
            if (File.Exists(game.assetPath + bitmap))
            {
                bmp = new Bitmap(bitmap);
            }
            else
            {
                game.util.Log("Could not find texture, using mising texture...");
                new MissingTexture(0, 0, game.WIDTH, game.HEIGHT);
                missingTexture = true;
            }
            Subscribe(this);
        }

        public override void pDraw()
        {
            if(!missingTexture)
            game.engine.DrawBitmap(bmp, (int)x, (int)y, scale);
        }

        public override void Destroy()
        {
            bmp.Dispose();
            bmp = null;
            GC.Collect();
        }
    }
}
