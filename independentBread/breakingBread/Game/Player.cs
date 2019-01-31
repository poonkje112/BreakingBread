using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game
{
    public enum isMoving
    {
        n = 0,
        y
    }

    public enum movingDir
    {
        left = 0,
        right,
        up,
        down
    }
    public class Player : pGameObject
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
        public bool depthAnim = true;



        public Player(int _x, int _y, float _scale)
        {
            x = _x;
            y = _y;
            LoadSprites();
            scale = _scale;
            layer = 10000;
            game.player = this;
            Subscribe(this);
        }

        private void LoadSprites()
        {
            idle.Add(new Dimension(2, 835, 250, 1227));
            idle.Add(new Dimension(253, 835, 503, 1227));

            WalkingVert.Add(new Dimension(3, 418, 249, 810));
            WalkingVert.Add(new Dimension(255, 418, 502, 810));
            WalkingVert.Add(new Dimension(509, 418, 755, 810));
            WalkingVert.Add(new Dimension(762, 418, 1008, 810));
            WalkingVert.Add(new Dimension(1015, 418, 1261, 810));
            WalkingVert.Add(new Dimension(1268, 418, 1514, 810));
            WalkingVert.Add(new Dimension(1521, 418, 1767, 810));
            WalkingVert.Add(new Dimension(1774, 418, 2020, 810));
            WalkingVert.Add(new Dimension(2027, 418, 2273, 810));
            WalkingVert.Add(new Dimension(2280, 418, 2527, 810));
            WalkingVert.Add(new Dimension(2533, 418, 2779, 810));
            WalkingVert.Add(new Dimension(2786, 418, 3032, 810));

            walkingTowards.Add(new Dimension(1, 1, 251, 393));
            walkingTowards.Add(new Dimension(254, 1, 504, 393));
            walkingTowards.Add(new Dimension(507, 1, 757, 393));
            walkingTowards.Add(new Dimension(760, 1, 1010, 393));
            walkingTowards.Add(new Dimension(1013, 1, 1263, 393));
            walkingTowards.Add(new Dimension(1266, 1, 1516, 393));

            walkingAway.Add(new Dimension(1772, 1, 2022, 393));
            walkingAway.Add(new Dimension(2025, 1, 2275, 393));
            walkingAway.Add(new Dimension(2278, 1, 2528, 393));
            walkingAway.Add(new Dimension(2531, 1, 2781, 393));
            walkingAway.Add(new Dimension(2784, 1, 3034, 393));
            walkingAway.Add(new Dimension(3037, 1, 3287, 393));
        }

        bool called = false;
        public bool depthScale = true;
        public override void pUpdate()
        {
            if (moveState == isMoving.y)
            {
                if (!depthAnim)
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
                }
                else
                {
                    if (x >= mX && x <= (mX + 20))
                    {
                        if (!called)
                        {
                            currentFrame = 0;
                            called = true;
                        }
                        if (y != mY && y > mY)
                        {
                            y -= ((movementSpeed * 0.5f) * game.engine.GetDeltaTime());
                            if(scale > 0.1f && depthScale)
                            scale -= 0.0005f;
                            dir = movingDir.up;
                        }

                        if (y != mY && y < mY)
                        {
                            y += ((movementSpeed * 0.5f) * game.engine.GetDeltaTime());
                            if(scale < 0.2f && depthScale)
                            scale += 0.0005f;
                            dir = movingDir.down;
                        }
                    }
                    else
                    {

                        if (x != mX && x > mX)
                        {
                            dir = movingDir.left;
                            x -= (movementSpeed * game.engine.GetDeltaTime());
                        }

                        if (x != mX && x < mX)
                        {
                            dir = movingDir.right;
                            x += (movementSpeed * game.engine.GetDeltaTime());
                        }
                    }
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

                if (dir == movingDir.left || dir == movingDir.right)
                {
                    if (wFrameCount >= 2)
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
                }
                else
                {
                    if (wFrameCount >= 5)
                    {
                        wFrameCount = 0;
                        if (currentFrame == walkingAway.Count - 1)
                        {
                            currentFrame = 0;
                        }
                        else
                        {
                            currentFrame++;
                        }
                    } else
                    {
                        wFrameCount++;
                    }
                }


                if (x >= mX && x <= (mX + 20) && y >= mY && y <= (mY + 20))
                {
                    moveState = isMoving.n;
                    called = false;
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
                    game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(idle[0].x, idle[0].y, idle[0].w, idle[0].h));
                }
                else
                {
                    game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(idle[1].x, idle[1].y, idle[1].w, idle[1].h));
                }
            }
            else if (dir == movingDir.left)
            {
                game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(WalkingVert[currentFrame].x, WalkingVert[currentFrame].y, WalkingVert[currentFrame].w, WalkingVert[currentFrame].h), true);
            }
            else if (dir == movingDir.right)
            {
                game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(WalkingVert[currentFrame].x, WalkingVert[currentFrame].y, WalkingVert[currentFrame].w, WalkingVert[currentFrame].h), false);
            }
            else if (dir == movingDir.up)
            {
                game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(walkingAway[currentFrame].x, walkingAway[currentFrame].y, walkingAway[currentFrame].w, walkingAway[currentFrame].h), false);
            }
            else if (dir == movingDir.down)
            {
                game.engine.DrawBitmap(game.assetSheet, new Vector2f(x, y), new Vector2f(scale, scale), new Rectanglef(walkingTowards[currentFrame].x, walkingTowards[currentFrame].y, walkingTowards[currentFrame].w, walkingTowards[currentFrame].h), false);
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

        public override void Destroy()
        {
            game.player = null;
        }

    }
}
