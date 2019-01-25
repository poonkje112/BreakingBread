using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;

namespace breakingBread.breakingBread.Game
{
    enum isMoving
    {
        n = 0,
        y
    }
    class Player : pGameObject
    {
        int animation, mX, mY, mW, mH;
        float movementSpeed = 200f;
        public isMoving moveState;
        MainGameClass game = MainGameClass.Instance;
        public delegate void iCallback();
        Bitmap bmp;
        iCallback callback;
        public float scaleX = 1f, scaleY = 1f;



        public Player(int _x, int _y, int width, int height, int animationIndex)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;
            animation = animationIndex;
            bmp = new Bitmap("Player.png");
            Subscribe(this);
        }

        public override void pUpdate()
        {
            if (moveState == isMoving.y)
            {
                //Do movement/scale shizzle
                if (x != mX && x > mX)
                {
                    x -= (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (x != mX && x < mX)
                {
                    x += (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (y != mY && y > mY)
                {
                    y -= (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (y != mY && y < mY)
                {
                    y += (int)(movementSpeed * game.engine.GetDeltaTime());
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
                if(x >= mX && x <= (mX + 20) && y >= mY && y <= (mY + 20))
                {
                    callback.Invoke();
                    moveState = isMoving.n;
                }

            }
        }
        public override void pDraw()
        {
            game.engine.DrawBitmap(bmp, new Vector2f(x, y), new Vector2f(scaleX, scaleY));
        }
        public void moveTo(iCallback c, int _x, int _y)
        {
            moveTo(c, _x, _y, w, h);
        }

        public void moveTo(iCallback c, int _x, int _y, int width, int height)
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
                scaleX = 0.5f;
                scaleY = 1.5f;
            }
        }

    }
}
