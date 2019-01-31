using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
using System;

namespace breakingBread.breakingBread.Game.Scenes
{
    class room1 : pScene
    {
        Background bck;
        pInteractable Vent, Bomb, breadI, lamp, propl, bread1, bread2;
        MainGameClass game = MainGameClass.Instance;
        Player p;
        Random rand = new Random();

        public override void startScene()
        {
            game.util.Log("Room 1");
            bck = new Background("Room_1_sketch.png");
            Bomb = new pInteractable(bombCallback, 40, 411, (597 - 515), (1410 - 1242), new Dimension(515, 1242, 597, 1410));
            Bomb.moveY = false;
            Bomb.highlightAlpha = 255;
            Vent = new pInteractable(ventCallback, 511, 300, 256, (1483 - 1241), new Dimension(0, 1241, 256, 1483));
            Vent.moveY = false;
            Vent.highlightAlpha = 255;

            breadI = new pInteractable(baguCallback, 1000, 575, (746 - 600), (1399 - 1327), new Dimension(600, 1327, 746, 1399));
            breadI.moveY = false;
            breadI.highlightAlpha = 255;

            bread1 = new pInteractable(cBread1, game.WIDTH / 2, 575, (639 - 515), (1465 - 1413), new Dimension(515, 1413, 639, 1465));
            bread1.moveY = false;
            bread1.highlightAlpha = 255;

            bread2 = new pInteractable(cBread2, 270, 515, (678 - 600), (1324 - 1242), new Dimension(600, 1242, 678, 1324));
            bread2.moveY = false;
            bread2.highlightAlpha = 255;

            propl = new pInteractable(null, 511, 300, 70, 70, new Dimension(259, 1243, 511, 1481));
            propl.doHoverAnimation = false;

            new Inventory();
            p = new Player(((game.WIDTH / 4) * 3) - (int)37.5, 550, .2f);
            p.depthScale = false;
            Bomb.setHover(true);

            game.wState = wireState.R;

            Inventory inventory = new Inventory();
        }

        void cBread1()
        {

        }

        void cBread2()
        {

        }

        void bombCallback()
        {
            p.moveTo(switchBomb, 60, 550);
        }

        void switchBomb()
        {
            if (game.selectedItem != null && game.inventory[0] == game.selectedItem && game.gState != gameState.bombDefused && game.gState == gameState.baguEmpty)
            {
                game.sceneManager.sceneIndex++;
                game.selectedItem = null;
            }
            else
            {
                game.selectedItem = null;
            }
        }

        void baguCallback()
        {
            if (game.gState == gameState.begin)
            {
                game.gState = gameState.baguEmpty;
                game.inventory.Add(new Item(new Dimension(681, 1242, 733, 1296)));
                game.util.Log("Added item! Inventory count = {0}", game.inventory.Count);
            }
        }

        void ventCallback()
        {
            if (game.gState == gameState.bombDefused)
            {
                game.sceneManager.sceneIndex = game.sceneManager.sceneIndex + 2;
            }
        }

        public override void updateScene()
        {
            if (game.gState != gameState.bombDefused)
                propl.angle += 2f * game.engine.GetDeltaTime();
        }

        public override void drawScene()
        {
            //game.engine.DrawBitmap(testbit, 50, 50);
        }

        public override void unLoadScene()
        {

        }
    }
}
