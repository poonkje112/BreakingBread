using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace breakingBread.breakingBread.Game
{
    class pInteractable : pGameObject
    {

        public delegate void iCallback();

        public Color color = Color.White;
        MainGameClass game = MainGameClass.Instance;
        MissingTexture missing;
        public float angle = 0f;

        #region variables
        #region public
        public float hoverAlpha = 0f;
        public bool doHoverAnimation = true;
        public bool visible = true;
        public int bXOffset = -3;
        public int bYOffset = -2;
        public int highlightAlpha = 150;

        #endregion

        #region private
        //private string bmpName;
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
        private bool exiting = false;

        private int bX = -1, bY = -1, bW = -1, bH = -1;

        #endregion
        #endregion

        public pInteractable(iCallback c, int _x, int _y, int _w, int _h, Dimension bmpD)
        {
            Load(c, _x, _y, _w, _h, bmpD, true, 255, 255, 255);
        }
        public pInteractable(iCallback c, int _x, int _y, int _w, int _h, Dimension bmpD, bool gHighlight, int hR, int hG, int hB)
        {
            Load(c, _x, _y, _w, _h, bmpD, gHighlight, hR, hG, hB);
        }

        public void Load(iCallback c, int _x, int _y, int _w, int _h, Dimension bmpD, bool gHighlight, int hR, int hG, int hB)
        {
            x = _x;
            y = _y;
            w = _w;
            h = _h;
            hoverR = hR;
            hoverG = hG;
            hoverB = hB;
            highlightMap = gHighlight;
            if (bmpD.x != -1 && bmpD.y != -1 && bmpD.w != -1 && bmpD.h != -1)
                {
                bX = bmpD.x;
                bY = bmpD.y;
                bW = bmpD.w;
                bH = bmpD.h;

                if (highlightMap)
                    while (!generateHighlight(bX, bY, bW, bH)) { }
            }
            else
            {
                game.util.Log("Could not find texture, using mising texture...");
                missing = new MissingTexture(x, y, w, h);
                missingTexture = true;
                missing.layer = layer + 1;
            }
            if (c == null)
            {
                callback = noFunction;
            }
            else
            {
                callback = c;
            }
            //bmpName = _bmpName;
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
                if (doHoverAnimation && !exiting)
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
                    game.engine.DrawBitmap(game.assetSheet, x, y, bX, bY, bW, bH, new Vector2f(1, 1), angle);
            }
        }

        public int frameCount = 0;
        public override void pUpdate()
        {
            if (doHoverAnimation)
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


                if (hoverAnimate && hoverAlpha < highlightAlpha)
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

            if (hoverAlpha > highlightAlpha)
            {
                hoverAlpha = highlightAlpha;
            }
            else if (hoverAlpha < 0)
            {
                hoverAlpha = 0;
            }

            if (missingTexture)
            {
                missing.x = x;
                missing.y = y;
                missing.w = w;
                missing.h = h;
            }

        }

        void doCallbackChecks()
        {
            Cursor.Current = Cursors.Hand;
            if (hoverAlpha == 0)
                hoverAnimate = true;

            if (game.engine.GetMouseButtonDown(0))
                callback.Invoke();

        }

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
                highlightBmp.Save(game.assetPath + "Hover_" + bmpX + "-" + bmpY + ".png");
                hoverBitmap = new Bitmap("Hover_" + bmpX + "-" + bmpY + ".png");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }

            
            highlightBmp.Dispose();
            bit.Dispose();
            GC.Collect();
            return true;

        }

        public override void Destroy()
        {
            exiting = true;
            Console.WriteLine("Called");
            if (hoverBitmap != null)
                hoverBitmap.Dispose();

            hoverBitmap = null;

            if (File.Exists(game.assetPath + "Hover_" + bX + "-" + bY + ".png"))
                File.Delete(game.assetPath + "Hover_" + bX + "-" + bY + ".png");

            if (!missingTexture)
            {
                //bitmap.Dispose();
                //bitmap = null;
            }
            else
            {
                missing.Unsubscribe(missing);
            }
            highlightBmp = null;
            GC.Collect();
        }
    }
}
