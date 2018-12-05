using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.BreakingBread.Util
{
    class bButton : GameObject
    {
        public delegate void bButtonCallback();

        Bitmap bitmap;
        int x, y, w, h, mX, mY;
        bButtonCallback callback;
        variables var = variables.Instance;
        public bool visible = true;
        private Color hoverCollor = Color.White;
        private bool doHoverCallback = false;
        private bool hoverAnimate = false;
        public float hoverAlpha = 0f;
        public bool doHoverAnimation = true;
        public List<Vector2f> boundPoints;
        System.Drawing.Bitmap bit;

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
            if (visible)
            {
                if (doHoverAnimation)
                {
                    var.engine.SetColor(hoverCollor.R, hoverCollor.G, hoverCollor.B, (int)hoverAlpha);
                    if (boundPoints != null)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            Vector2f startPos = new Vector2f(boundPoints[i].X + (x - 4), boundPoints[i].Y + (y - 2));
                            Vector2f endPos;
                            if (i == 3)
                            {
                                endPos = new Vector2f(boundPoints[0].X + (x - 4), boundPoints[0].Y + y);
                            }
                            else
                            {
                                endPos = new Vector2f(boundPoints[i + 1].X + (x - 4), boundPoints[i + 1].Y + (y - 2));
                            }
                            var.engine.DrawLine(startPos, endPos, 5);
                        }
                    }
                    else
                    {
                        //Console.WriteLine("No bounds drawing cube");
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
            try
            {
                bit = new System.Drawing.Bitmap(var.assetPath + bmp);
                for (int _x = 0; _x < bit.Width; _x++)
                {
                    for (int _y = 0; _y < bit.Height; _y++)
                    {
                        if (bit.GetPixel(_x, _y).R == 255 && bit.GetPixel(_x, _y).G == 0 && bit.GetPixel(_x, _y).B == 215)
                        {
                            Console.WriteLine("Found bound");
                            boundPoints.Add(new Vector2f(_x, _y));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //visible = false;
            }
            //Shifting positions so we can iterate through
            Vector2f placeHolder;
            placeHolder = boundPoints[2];
            boundPoints[2] = boundPoints[3];
            boundPoints[3] = placeHolder;

            bit.Dispose();
            return true;

        }
    }
}
