using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace breakingBread.breakingBread.Game
{
    public class Item : pGameObject
    {
        MissingTexture missing;
        MainGameClass game = MainGameClass.Instance;
        Bitmap hoverBitmap;
        private int mX, mY;
        int hoverR = 255, hoverG = 255, hoverB = 255;
        bool doHoverAnimation = true;
        float hoverAlpha = 0f;
        bool hoverAnimate = false;
        private int bX = -1, bY = -1, bW = -1, bH = -1;
        Dimension bmpD;
        bool missingTexture = false;


        public Item(Dimension _bmpD)
        {
            bmpD = _bmpD;
            LoadItem();
            layer = 100;
        }

        public void LoadItem()
        {
            if (bmpD.x != -1 && bmpD.y != -1 && bmpD.w != -1 && bmpD.h != -1)
            {
                bX = bmpD.x;
                bY = bmpD.y;
                bW = bmpD.w;
                bH = bmpD.h;
                generateHighlight(bX, bY, bW, bH);
            }
            else
            {
                missing = new MissingTexture(0, 0, 50, 50);
                missingTexture = true;
            }
            Subscribe(this);

        }

        public int bXOffset = -3;
        public int bYOffset = -2;
        public void drawItem(int _x, int _y, int width, int height)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;

            if (missingTexture)
            {
                missing.x = x;
                missing.y = y;
                missing.w = w;
                missing.h = h;
                //missing.layer = 2001;
            }

            if (doHoverAnimation)
            {
                game.engine.SetColor(hoverR, hoverG, hoverB, (int)hoverAlpha);
                if (!missingTexture)
                {
                    //Console.WriteLine("Called");
                    game.engine.DrawBitmap(hoverBitmap, x + bXOffset, y + bYOffset);
                    //game.engine.DrawBitmap(bmp, x, y);
                    game.engine.SetColor(0, 0, 0, 255);
                    game.engine.DrawBitmap(game.assetSheet, x, y, bX, bY, bW, bH);
                }
                else
                {
                    game.engine.FillRectangle(x - 4, y - 4, w + 8, h + 8);
                }
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
                    game.selectedItem = this;

                }
                else
                {
                    game.selectedItem = null;
                }
            }
        }

        List<Vector2f> boundPoints = new List<Vector2f>();
        private System.Drawing.Bitmap bit;
        private System.Drawing.Bitmap highlightBmp;


        private bool generateHighlight(int bmpX, int bmpY, int bmpW, int bmpH)
        {
            //Initializing our main bitmap
            bit = new System.Drawing.Bitmap(game.assetPath + "Asset_Sheet.png");
            int threshold = 1;

            for (int _x = bmpX; _x <= (bmpW + bmpX); _x++)
            {
                //Initializing our highlight bitmap
                highlightBmp = new System.Drawing.Bitmap((bmpW) + 10, (bmpH) + 10);
                for (int _y = bmpY; _y <= (bmpH + bmpY); _y++)
                {
                    if (bit.GetPixel(_x, _y).A == 0)
                    {
                        if (_x + 1 < (bmpW + bmpX) && bit.GetPixel(_x + 1, _y).A > threshold)
                        {
                            Vector2f currentpos = new Vector2f(_x - bmpX, _y - bmpY);
                            boundPoints.Add(currentpos);
                        }

                        if (_x - 1 >= bmpX && bit.GetPixel(_x - 1, _y).A > threshold)
                        {
                            Vector2f currentpos = new Vector2f(_x - bmpX, _y - bmpY);
                            boundPoints.Add(currentpos);
                        }

                        if ((_y - 1) >= bmpY && bit.GetPixel(_x, _y - 1).A > threshold)
                        {
                            Vector2f currentpos = new Vector2f(_x - bmpX, _y - bmpY);
                            boundPoints.Add(currentpos);
                        }
                        if ((_y + 1) < (bmpH + bmpY) && bit.GetPixel(_x, _y + 1).A > threshold)
                        {
                            Vector2f currentpos = new Vector2f(_x - bmpX, _y - bmpY);
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
                if (File.Exists(game.assetPath + "Hover_" + bmpX + "-" + bmpY + ".png"))
                {
                    hoverBitmap = new Bitmap("Hover_" + bmpX + "-" + bmpY + ".png");
                }
                else
                {
                    hoverBitmap = new Bitmap("Hover_" + bmpX + "-" + bmpY + ".png");
                    highlightBmp.Save(game.assetPath + "Hover_" + bmpX + "-" + bmpY + ".png");
                    highlightBmp.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            bit.Dispose();
            GC.Collect();
            return true;

        }

        public override void Destroy()
        {
            if (hoverBitmap != null)
                hoverBitmap.Dispose();
            hoverBitmap = null;

            //if (File.Exists(game.assetPath + "Hover_" + bmpName))
            //    File.Delete(game.assetPath + "Hover_" + bmpName);
            //if (bmp != null)
            //{
            //    bmp.Dispose();
            //    bmp = null;
            //}
            highlightBmp = null;
            GC.Collect();
        }

    }
}
