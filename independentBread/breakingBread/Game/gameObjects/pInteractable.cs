using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.IO;

namespace breakingBread.breakingBread.Game
{
    class pInteractable : pGameObject
    {

        public delegate void iCallback();

        public Color color = Color.White;
        MainGameClass game = MainGameClass.Instance;

        #region variables
        #region public
        public float hoverAlpha = 0f;
        public bool doHoverAnimation = true;
        public bool visible = true;
        public int bXOffset = -3;
        public int bYOffset = -2;

        #endregion

        #region private
        private Bitmap bitmap;
        private string bmpName;
        private Bitmap hoverBitmap;
        private iCallback callback;
        private int mX, mY;
        //private Color hoverCollor = Color.White;
        int hoverR, hoverG, hoverB;
        private bool doHoverCallback = false;
        private bool hoverAnimate = false;
        //private Vector2f[] boundPoints;
        private List<Vector2f> boundPoints = new List<Vector2f>();
        private System.Drawing.Bitmap bit;
        private bool missingTexture = false;
        private bool highlightMap = false;
        private System.Drawing.Bitmap highlightBmp;
        #endregion
        #endregion


        public pInteractable(iCallback c, int _x, int _y, int _w, int _h)
        {
            Load(c, _x, _y, _w, _h, "", false, 0, 0, 0);
        }

        public pInteractable(iCallback c, int _x, int _y, int _w, int _h, string _bmpName)
        {
            Load(c, _x, _y, _w, _h, _bmpName, false, 0, 0, 0);
        }
        public pInteractable(iCallback c, int _x, int _y, int _w, int _h, string _bmpName, bool gHighlight, int hR, int hG, int hB)
        {
            Load(c, _x, _y, _w, _h, _bmpName, gHighlight, hR, hG, hB);
        }

        public void Load(iCallback c, int _x, int _y, int _w, int _h, string _bmpName, bool gHighlight, int hR, int hG, int hB)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            hoverR = hR;
            hoverG = hG;
            hoverB = hB;
            highlightMap = gHighlight;
            if (File.Exists(game.assetPath + _bmpName))
            {
                bitmap = new Bitmap(_bmpName);

                if(highlightMap)
                while (!calculateBounds(_bmpName)) { }
            }
            else
            {
                Console.WriteLine("Could not find texture, using mising texture...");
                new MissingTexture(x, y, w, h);
                missingTexture = true;
            }
            if (c == null)
            {
                callback = noFunction;
            }
            else
            {
                callback = c;
            }
            bmpName = _bmpName;
            Subscribe(this);
        }

        void noFunction() { }

        public void setHover(bool hover)
        {
            doHoverCallback = hover;
        }

        public void setHover(bool hover, int hR, int hG, int hB)
        {
            doHoverCallback = hover;
            hoverR = hR;
            hoverG = hG;
            hoverB = hB;
        }

        public override void pDraw()
        {
            if (visible)
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

                if (!missingTexture)
                    game.engine.DrawBitmap(bitmap, x, y);
            }
        }

        public int frameCount = 0;
        public override void pUpdate()
        {
            mX = game.engine.GetMousePosition().X;
            mY = game.engine.GetMousePosition().Y;

            if (mX >= x && mX <= (x + w) && mY >= y && mY <= (y + h))
            {
                doCallbackChecks();
            }
            else
            {
                hoverAnimate = false;
            }
            if (doHoverAnimation)
            {
                if (hoverAnimate && hoverAlpha < 200)
                {
                    frameCount++;
                    if (frameCount == 1)
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
            }

            if (hoverAlpha > 200)
            {
                hoverAlpha = 200;
            }
            else if (hoverAlpha < 0)
            {
                hoverAlpha = 0;
            }

        }

        void doCallbackChecks()
        {
            if(hoverAlpha == 0)
            hoverAnimate = true;

            if (game.engine.GetMouseButtonDown(0))
                callback.Invoke();

        }

        bool calculateBounds(string bmp)
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
                for(int x = 0; x < 6; x++)
                {
                    for(int y = 0; y < 5; y++)
                    {
                        highlightBmp.SetPixel((int)boundPoints[i].X + x, (int)boundPoints[i].Y + y, System.Drawing.Color.FromArgb(255, hoverR, hoverG, hoverB));
                    }
                }
            }

            highlightBmp.Save(game.assetPath + "Hover_" + bmp);
            hoverBitmap = new Bitmap("Hover_" + bmp);

            highlightBmp.Dispose();
            bit.Dispose();
            return true;

        }

        public override void Destroy()
        {
            if(highlightBmp != null)
            highlightBmp.Dispose();

            if (File.Exists(game.assetPath + "Hover_" + bmpName))
                File.Delete(game.assetPath + "Hover_" + bmpName);

            bitmap.Dispose();
            bitmap = null;
            highlightBmp = null;
        }
    }
}
