using breakingBread.breakingBread.Game.util;
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
        float movementSpeed = 100f;
        public isMoving moveState;
        MissingTexture missing;
        MainGameClass game = MainGameClass.Instance;
        public Player(int _x, int _y, int width, int height, int animationIndex)
        {
            x = _x;
            y = _y;
            w = width;
            h = height;
            animation = animationIndex;
            missing = new MissingTexture(x, y, w, h);
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

                if (x == mX && y == mY)
                    moveState = isMoving.n;

            }      
                missing.x = x;
                missing.y = y;
        }

        public void moveTo(int _x, int _y)
        {
            moveTo(_x, _y, w, h);
        }

        public void moveTo(int _x, int _y, int width, int height)
        {
            mX = _x;
            mY = _y;
            mW = width;
            mH = height;
            moveState = isMoving.y;
        }

    }
}
