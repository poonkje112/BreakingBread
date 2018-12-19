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
            for(int i = 0; i < game.inventory.Count; i++)
            {
                game.inventory[i].drawItem(853 + (63 * i), 663, 50, 50);
            }
        }

    }
}
