using breakingBread.breakingBread.Game.util;
using GameEngine;

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
        MissingTexture missing; // TODO: Remove me.
        MainGameClass game = MainGameClass.Instance;
        public delegate void iCallback();
        Bitmap bmp;
        iCallback callback;


        public Player(int _x, int _y, int width, int height, int animationIndex)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;
            animation = animationIndex;
            //missing = new MissingTexture(x, y, w, h); //TODO: Remove me.
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

                if (w != mW && w > mW)
                {
                    w -= (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (w != mW && w < mW)
                {
                    w += (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (h != mH && h > mH)
                {
                    h -= (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (h != mH && h < mH)
                {
                    h += (int)(movementSpeed * game.engine.GetDeltaTime());
                }

                if (x == mX && y == mY && w == mW && h == mH)
                {
                    callback.Invoke();
                    moveState = isMoving.n;
                } else
                {
                    //missing.x = x;
                    //missing.y = y;
                    //missing.w = w;
                    //missing.h = h;
                }

            }
        }
        public override void pDraw()
        {
            game.engine.DrawBitmap(bmp, x, y);
        }
        public void moveTo(iCallback c, int _x, int _y)
        {
            moveTo(c, _x, _y, w, h);
        }

        public void moveTo(iCallback c, int _x, int _y, int width, int height)
        {
            mX = _x;
            mY = _y;
            mW = width;
            mH = height;
            callback = c;
            moveState = isMoving.y;
        }

    }
}
