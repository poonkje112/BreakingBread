using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    class Item : pGameObject
    {
        string itemName = null;
        Bitmap bmp;
        MissingTexture missing;
        MainGameClass game = MainGameClass.Instance;
        Bitmap hoverBitmap;
        private int mX, mY;
        int hoverR = 255, hoverG = 0, hoverB = 0;
        bool doHoverAnimation = true;
        float hoverAlpha = 0f;
        bool hoverAnimate = false;
        string bmpName;


        public Item(string bitmap)
        {
            bmp = new Bitmap(bitmap);
            bmpName = bitmap;
            LoadItem();
        }

        public void LoadItem()
        {
            bmp = new Bitmap(bmpName);
            if (bmp == null)
                missing = new MissingTexture(0, 0, 50, 50);

            if (generateHighlight(bmpName))
                Subscribe(this);
            else
                Console.WriteLine("Could not generate highlight!");
        }

        public int bXOffset = -3;
        public int bYOffset = -2;
        public void drawItem(int _x, int _y, int width, int height)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;

            if (bmp == null)
            {
                missing.x = x;
                missing.y = y;
                missing.w = w;
                missing.h = h;
            }
            else
            {
                if (doHoverAnimation)
                {
                    game.engine.SetColor(hoverR, hoverG, hoverB, (int)hoverAlpha);
                    if (hoverBitmap != null)
                    {
                        game.engine.DrawBitmap(hoverBitmap, x + bXOffset, y + bYOffset);
                    }
                    else
                    {
                        game.engine.FillRectangle(x - 4, y - 4, w + 8, h + 8);
                    }
                }
                game.engine.SetColor(0, 0, 0, 255);
                game.engine.DrawBitmap(bmp, x, y);
            }
        }

        int frameCount = 0;
        public override void pUpdate()
        {
            mX = game.engine.GetMousePosition().X;
            mY = game.engine.GetMousePosition().Y;

            if (mX >= x && mX <= (x + w) && mY >= y && mY <= (y + h))
            {
                checkCallBacks();
            }

            if (hoverAnimate && hoverAlpha < 175)
            {
                frameCount++;
                if (frameCount == 5)
                {
                    hoverAlpha += 25;
                    frameCount = 0;
                }
            }
            else if (!hoverAnimate && hoverAlpha > 0f)
            {
                frameCount++;
                if (frameCount == 5)
                {
                    hoverAlpha -= 25;
                    frameCount = 0;
                }
            }

            if (hoverAlpha > 175)
            {
                hoverAlpha = 175;
            }
            else if (hoverAlpha < 0)
            {
                hoverAlpha = 0;
            }

            if (game.selectedItem == this)
                hoverAnimate = true;
            else
                hoverAnimate = false;
        }

        private void checkCallBacks()
        {
            if (game.engine.GetMouseButtonDown(0))
            {
                if (game.selectedItem != this)
                {
                    Console.WriteLine("Pressed");
                    game.selectedItem = this;
                }
            }
        }

        List<Vector2f> boundPoints = new List<Vector2f>();
        private System.Drawing.Bitmap bit;
        private System.Drawing.Bitmap highlightBmp;


        bool generateHighlight(string bmp)
        {
            //Initializing our main bitmap
            bit = new System.Drawing.Bitmap(game.assetPath + bmp);

            for (int _x = 0; _x < bit.Width; _x++)
            {
                //Initializing our highlight bitmap
                highlightBmp = new System.Drawing.Bitmap(bit.Width + 10, bit.Height + 10);
                for (int _y = 0; _y < bit.Height; _y++)
                {
                    if (bit.GetPixel(_x, _y).A == 0)
                    {
                        if (_x + 1 < bit.Width && bit.GetPixel(_x + 1, _y).A == 255)
                        {
                            Vector2f currentpos = new Vector2f(_x, _y);
                            boundPoints.Add(currentpos);
                        }

                        if (_x - 1 != -1 && bit.GetPixel(_x - 1, _y).A == 255)
                        {
                            Vector2f currentpos = new Vector2f(_x, _y);
                            boundPoints.Add(currentpos);
                        }

                        if ((_y - 1) != -1 && bit.GetPixel(_x, _y - 1).A == 255)
                        {
                            Vector2f currentpos = new Vector2f(_x, _y);
                            boundPoints.Add(currentpos);
                        }
                        if ((_y + 1) < bit.Height && bit.GetPixel(_x, _y + 1).A == 255)
                        {
                            Vector2f currentpos = new Vector2f(_x, _y);
                            boundPoints.Add(currentpos);
                        }

                    }
                }

            }

            for (int i = 0; i < boundPoints.Count; i++)
            {
                for (int x = 0; x < 6; x++)
                {
                    for (int y = 0; y < 5; y++)
                    {
                        highlightBmp.SetPixel((int)boundPoints[i].X + x, (int)boundPoints[i].Y + y, System.Drawing.Color.FromArgb(255, hoverR, hoverG, hoverB));
                    }
                }
            }
            try
            {
                highlightBmp.Save(game.assetPath + "Hover_" + bmp);
                hoverBitmap = new Bitmap("Hover_" + bmp);
            }
            catch (Exception ex) { }

            highlightBmp.Dispose();
            bit.Dispose();
            GC.Collect();
            return true;

        }

        public override void Destroy()
        {
            if (hoverBitmap != null)
                hoverBitmap.Dispose();
            hoverBitmap = null;

            if (File.Exists(game.assetPath + "Hover_" + bmpName))
                File.Delete(game.assetPath + "Hover_" + bmpName);
            if (bmp != null)
            {
                bmp.Dispose();
                bmp = null;
            }
            highlightBmp = null;
            GC.Collect();
        }

    }
}
