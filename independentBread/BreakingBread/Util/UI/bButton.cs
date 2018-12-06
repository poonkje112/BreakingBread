using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.BreakingBread.Util
{
    class bButton : GameObject
    {
        public delegate void bButtonCallback();


        #region variables
        #region public
        public float hoverAlpha = 0f;
        public bool doHoverAnimation = true;
        public bool visible = true;
        public int bXOffset = 5;
        public int bYOffset = 5;

        #endregion

        #region private
        private variables var = variables.Instance;
        private bButtonCallback callback;
        private Bitmap bitmap;
        private int x, y, w, h, mX, mY;
        private Color hoverCollor = Color.White;
        private bool doHoverCallback = false;
        private bool hoverAnimate = false;
        //private Vector2f[] boundPoints;
        private List<Vector2f> boundPoints;
        private System.Drawing.Bitmap bit;
        #endregion
        #endregion

        public bButton(bButtonCallback _callback, Bitmap bmp, int _x, int _y, int width, int height, string boundsFile)
        {
            callback = _callback;
            bitmap = bmp;
            x = _x;
            y = _y;
            w = width;
            h = height;
            if (boundsFile != string.Empty && boundsFile != "")
            {
                boundPoints = new List<Vector2f>();
                while (!calculateBounds(boundsFile))
                {
                    // Wait until it's done
                }
            }
        }

        public void setHover(bool hover)
        {
            doHoverCallback = hover;
        }

        public void setHover(bool hover, Color color)
        {
            doHoverCallback = hover;
            hoverCollor = color;
        }

        public int frameCount = 0;
        public override void Update()
        {
            mX = var.engine.GetMousePosition().X;
            mY = var.engine.GetMousePosition().Y;

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
                        hoverAlpha += 20;
                        frameCount = 0;
                    }
                }
                else if (!hoverAnimate && hoverAlpha > 0f)
                {
                    frameCount++;
                    if (frameCount == 1)
                    {
                        hoverAlpha -= 20f;
                        frameCount = 0;
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
            //Console.WriteLine("{0} | {1}", hoverAnimate, hoverAlpha);
        }

        void doCallbackChecks()
        {
            hoverAnimate = true;
            if (var.engine.GetMouseButtonDown(0))
                callback.Invoke();

        }

        public override void Paint()
        {
            //Console.WriteLine("T");
            if (visible)
            {
                if (doHoverAnimation)
                {
                    var.engine.SetColor(hoverCollor.R, hoverCollor.G, hoverCollor.B, (int)hoverAlpha);
                    if (boundPoints != null)
                    {
                        for (int i = 0; i < boundPoints.Count; i++)
                        {
                            var.engine.FillRectangle(boundPoints[i].X + (x-bXOffset), boundPoints[i].Y + (y-bYOffset), 5, 5);
                        }
                    }
                    else
                    {
                        var.engine.FillRectangle(x - 4, y - 4, w + 8, h + 8);
                    }
                }
                var.engine.SetColor(0, 0, 0, 255);
                var.engine.DrawBitmap(bitmap, x, y);
            }
        }

        //Calculate bounds
        bool calculateBounds(string bmp)
        {
            bit = new System.Drawing.Bitmap(var.assetPath + bmp);
            for (int _x = 0; _x < bit.Width; _x++)
            {
                for (int _y = 0; _y < bit.Height; _y++)
                {


                    if (bit.GetPixel(_x, _y).A == 0)
                    {
                        if (_x + 1 < bit.Width && bit.GetPixel(_x + 1, _y).A == 255)
                        {
                            Vector2f currentPos = new Vector2f(_x, _y);
                            if (!boundPoints.Contains(currentPos))
                            {
                                boundPoints.Add(new Vector2f(_x, _y));
                            }
                        }

                        if (_x - 1 != -1 && bit.GetPixel(_x - 1, _y).A == 255)
                        {
                            Vector2f currentPos = new Vector2f(_x, _y);
                            if (!boundPoints.Contains(currentPos))
                            {
                                boundPoints.Add(new Vector2f(_x, _y));
                            }
                        }
                    }

                    if (bit.GetPixel(_x, _y).A == 0)
                    {
                        if ((_y - 1) != -1 && bit.GetPixel(_x, _y - 1).A == 255)
                        {
                            Vector2f currentPos = new Vector2f(_x - 5, _y - 5);
                            if (!boundPoints.Contains(currentPos))
                                boundPoints.Add(new Vector2f(_x, _y));
                        }
                        if ((_y + 1) < bit.Height && bit.GetPixel(_x, _y + 1).A == 255)
                        {
                            Vector2f currentPos = new Vector2f(_x - 5, _y - 5);
                            if (!boundPoints.Contains(currentPos))
                                boundPoints.Add(new Vector2f(_x, _y));
                        }
                    }
                }
            }

            Console.WriteLine(boundPoints.Count);
            bit.Dispose();
            return true;

        }
    }
}
