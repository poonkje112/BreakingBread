using GameEngine;
using System;

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
            if (game.sceneManager.switchState == util.isSceneSwitching.n)
            {
                for (int i = 0; i < game.inventory.Count; i++)
                {
                    //Checking if the item is subscribed if not the item has been unloaded and needs to be reloaded.
                    if (!game.gameObjects.Contains(game.inventory[i]))
                    {
                        game.inventory[i].LoadItem();
                    }
                    game.inventory[i].drawItem(853 + (63 * i), 663, 50, 50);
                }
            }
        }

        public override void Destroy()
        {
            bmp.Dispose();
            bmp = null;
            GC.Collect();
        }

    }
}
