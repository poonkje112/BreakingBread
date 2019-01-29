using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.IO;

namespace breakingBread.breakingBread.Game.gameObjects
{
    class Background : pGameObject
    {
        Bitmap bmp;
        //Bitmap fade;
        MainGameClass game = MainGameClass.Instance;
        public Vector2f scale = new Vector2f(1f, 1f);
        bool missingTexture = false;
        public bool draw = true;
        //private bool drawing = true;
        public float alpha = 255f;
        public Background(string bitmap)
        {
            layer = -1;
            //fade = new Bitmap("fade.png");
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

        //int frameCount = 0;
        public override void pUpdate()
        {
            //if(!draw)
            //{
            //    if (frameCount == 5)
            //    {
            //        alpha += 0.1f;
            //        if (alpha >= 255f)
            //            alpha = 255f;
            //        if (alpha == 255f)
            //            drawing = false;

            //        frameCount = 0;
            //    } else
            //    {
            //        frameCount++;
            //    }
            //} else
            //{
            //    if (frameCount == 5)
            //    {
            //        alpha -= 0.1f;
            //        if (alpha <= 0f)
            //            alpha = 0f;
            //        if (alpha == 0f)
            //            drawing = true;

            //        frameCount = 0;
            //    } else
            //    {
            //        frameCount++;
            //    }
            //}
        }

        public override void pDraw()
        {
            if (draw)
            {
                game.engine.SetColor(0, 0, 0, (int)alpha);
                if (!missingTexture)
                    game.engine.DrawBitmap(bmp, (int)x, (int)y, scale);
            }
        }

        public override void Destroy()
        {
            bmp.Dispose();
            bmp = null;
            GC.Collect();
        }
    }
}
