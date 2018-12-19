using GameEngine;

namespace breakingBread.breakingBread.Game
{
    class Inventory : pGameObject
    {
        Bitmap bmp = new Bitmap("HUD.png");
        MainGameClass game = MainGameClass.Instance;

        public Inventory()
        {
            Subscribe(this);
        }

        public override void pStart()
        {
            layer = 50;
        }

        public override void pUpdate()
        {

        }

        public override void pDraw()
        {
            game.engine.DrawBitmap(bmp, 0, 0);
        }

    }
}
