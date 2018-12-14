using breakingBread.breakingBread.Game.util;

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
        isMoving moveState;
        MissingTexture missing;
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

            }
            else if (moveState == isMoving.n)
            {
                if (x > mX || x < mX)
                {
                    x = mX;
                }

                if (y > mY || y < mY)
                {
                    y = mY;
                }

                if (w > mW || w < mW)
                {
                    w = mX;
                }

                if (h > mH || h < mH)
                {
                    h = mH;
                }
            }            
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
        }

    }
}
