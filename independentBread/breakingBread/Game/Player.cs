using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game
{
    enum isMoving
    {
        n = 0,
        y
    }

    enum movingDir
    {
        left = 0,
        right,
        up,
        down
    }
    class Player : pGameObject
    {
        float mX, mY, mW, mH;
        float movementSpeed = 200f;
        public isMoving moveState;
        public movingDir dir;
        MainGameClass game = MainGameClass.Instance;
        public delegate void iCallback();
        Bitmap bmp;
        iCallback callback;
        public float scaleX = 1f, scaleY = 1f;

        public List<Dimension> idle = new List<Dimension>();
        public List<Dimension> WalkingVert = new List<Dimension>();
        public List<Dimension> walkingAway = new List<Dimension>();
        public List<Dimension> walkingTowards = new List<Dimension>();
        Bitmap animationSheet;



        public Player(int _x, int _y, float _scale)
        {
            animationSheet = new Bitmap("textureMap.png");
            x = _x;
            y = _y;
            LoadSprites();
            scale = _scale;
            Subscribe(this);
        }

        private void LoadSprites()
        {
            idle.Add(new Dimension(1, 835, 251, 1227));
            idle.Add(new Dimension(254, 835, 504, 1227));

            WalkingVert.Add(new Dimension(2, 418, 250, 810));
            WalkingVert.Add(new Dimension(255, 418, 503, 810));
            WalkingVert.Add(new Dimension(508, 418, 756, 810));
            WalkingVert.Add(new Dimension(761, 418, 1009, 810));
            WalkingVert.Add(new Dimension(1014, 418, 1262, 810));
            WalkingVert.Add(new Dimension(1267, 418, 1515, 810));
            WalkingVert.Add(new Dimension(1520, 418, 1768, 810));
            WalkingVert.Add(new Dimension(1773, 418, 2021, 810));
            WalkingVert.Add(new Dimension(2026, 418, 2274, 810));
            WalkingVert.Add(new Dimension(2279, 418, 2528, 810));
            WalkingVert.Add(new Dimension(2532, 418, 2780, 810));
            WalkingVert.Add(new Dimension(2785, 418, 3033, 810));

            walkingTowards.Add(new Dimension(1, 1, 251, 393));
            walkingTowards.Add(new Dimension(254, 1, 504, 393));
            walkingTowards.Add(new Dimension(507, 1, 757, 393));
            walkingTowards.Add(new Dimension(760, 1, 1010, 393));
            walkingTowards.Add(new Dimension(1013, 1, 1263, 393));
            walkingTowards.Add(new Dimension(1266, 1, 1516, 393));

            walkingAway.Add(new Dimension(2060, 1, 2310, 393));
            walkingAway.Add(new Dimension(2313, 1, 2563, 393));
            walkingAway.Add(new Dimension(2566, 1, 2861, 393));
            walkingAway.Add(new Dimension(2819, 1, 3068, 393));
            walkingAway.Add(new Dimension(3072, 1, 3321, 393));
            walkingAway.Add(new Dimension(3325, 1, 3575, 393));
        }

        public override void pUpdate()
        {
            if (moveState == isMoving.y)
            {

                //Do movement/scale shizzle
                if (y != mY && y > mY)
                {
                    y -= ((movementSpeed * 0.5f) * game.engine.GetDeltaTime());
                }

                if (x != mX && x > mX)
                {
                    dir = movingDir.left;
                    x -= (movementSpeed * game.engine.GetDeltaTime());
                }

                if (y != mY && y < mY)
                {
                    y += ((movementSpeed * 0.5f) * game.engine.GetDeltaTime());
                }

                if (x != mX && x < mX)
                {
                    dir = movingDir.right;
                    x += (movementSpeed * game.engine.GetDeltaTime());
                }
                //Scaling

                //if (w != mW && w > mW)
                //{
                //    w -= (int)(movementSpeed * game.engine.GetDeltaTime());
                //}

                //if (w != mW && w < mW)
                //{
                //    w += (int)(movementSpeed * game.engine.GetDeltaTime());
                //}

                //if (h != mH && h > mH)
                //{
                //    h -= (int)(movementSpeed * game.engine.GetDeltaTime());
                //}

                //if (h != mH && h < mH)
                //{
                //    h += (int)(movementSpeed * game.engine.GetDeltaTime());
                //}

                //if (x == mX && y == mY)

                if (wFrameCount == 2)
                {
                    wFrameCount = 0;
                    if (currentFrame == 11)
                    {
                        currentFrame = 0;
                    }
                    else
                    {
                        currentFrame++;
                    }
                }
                else
                {
                    wFrameCount++;
                }

                if (x >= mX && x <= (mX + 20) && y >= mY && y <= (mY + 20))
                {
                    moveState = isMoving.n;
                    callback.Invoke();
                }

            }
            else
            {
                Blink();
            }
            //if (game.engine.GetKeyDown(Key.K))
            //{
            //    if (currentFrame != 11)
            //        currentFrame++;
            //    else
            //        currentFrame = 0;
            //    Console.WriteLine(currentFrame);
            //}

        }
        int wFrameCount = 0;

        Random rand = new Random();
        int blinkFrames = -1;
        int frameCount = 0;
        bool blinking = false;
        private void Blink()
        {
            if (blinkFrames == -1)
            {
                blinkFrames = rand.Next(120, 660);
            }

            if (frameCount != blinkFrames)
            {
                frameCount++;
            }
            else
            {
                if (blinking == false)
                {
                    frameCount = 0;
                    blinkFrames = 12;
                }
                else
                {
                    frameCount = 0;
                    blinkFrames = -1;
                }
                blinking = !blinking;
            }
        }

        int currentFrame = 0;
        public override void pDraw()
        {
            if (moveState == isMoving.n)
            {
                if (!blinking)
                {
                    game.engine.DrawBitmap(animationSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(idle[0].x, idle[0].y, idle[0].w, idle[0].h));
                }
                else
                {
                    game.engine.DrawBitmap(animationSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(idle[1].x, idle[1].y, idle[1].w, idle[1].h));
                }
            }
            else if (dir == movingDir.left)
            {
                game.engine.DrawBitmap(animationSheet, new Vector2f(x + ((WalkingVert[0].w - WalkingVert[0].x) * scale), y), new Vector2f(scale, scale), new Rectanglef(WalkingVert[currentFrame].x, WalkingVert[currentFrame].y, WalkingVert[currentFrame].w, WalkingVert[currentFrame].h), true);
            }
            else if (dir == movingDir.right)
            {
                game.engine.DrawBitmap(animationSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(WalkingVert[currentFrame].x, WalkingVert[currentFrame].y, WalkingVert[currentFrame].w, WalkingVert[currentFrame].h), false);
            }
        }
        public void moveTo(iCallback c, float _x, float _y)
        {
            moveTo(c, _x, _y, w, h);
        }

        public void moveTo(iCallback c, float _x, float _y, float width, float height)
        {
            if (moveState == isMoving.n)
            {
                mX = _x;
                mY = _y;
                mW = width;
                mH = height;
                callback = c;
                moveState = isMoving.y;
                game.util.Log("Moving to -> X: {0} | Y: {1} | W: {2} | H: {3}", mX, mY, mW, mH);
                //scaleX = 0.5f;
                //scaleY = 1.5f;
            }
        }

    }
}
