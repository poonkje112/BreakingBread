using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakingBread.breakingBread.Game.Scenes
{
    class room1 : pScene
    {
        Background bck;
        pInteractable Vent, Bomb, Bagu, lamp;
        MainGameClass game = MainGameClass.Instance;
        Player p;
        Random rand = new Random();
        
        public override void startScene()
        {
            game.util.Log("Room 1");
            bck = new Background("Room_1_sketch.png");
            Bomb = new pInteractable(bombCallback, 40, 411, 85, 171, new Dimension(515, 1242, 597, 1410));
            Bomb.highlightAlpha = 255;
            Vent = new pInteractable(ventCallback, 511, 340, 257, 200, new Dimension(-1, -1, -1, -1));
            Vent.highlightAlpha = 255;
            Bagu = new pInteractable(baguCallback, 860, 537, 288, 78, new Dimension(-1, -1, -1, -1));
            Bagu.highlightAlpha = 255;
            lamp = new pInteractable(null, 230, 160, 70, 70, new Dimension(-1, -1, -1, -1));
            lamp.doHoverAnimation = false;

            new Inventory();
            p = new Player(game.WIDTH / 2 - (int)37.5, 550, .2f);
            Bomb.setHover(true);
            //game.wState = (wireState)(rand.Next(Enum.GetNames(typeof(wireState)).Length));
            game.wState = wireState.R;

            Inventory inventory = new Inventory();
        }

        void bombCallback()
        {
            if (game.selectedItem != null && game.inventory[0] == game.selectedItem && game.gState != gameState.bombDefused && game.gState == gameState.baguEmpty)
            {
                game.selectedItem = null;
                if (p.moveState == isMoving.n)
                p.moveTo(switchBomb, 75, 550);
            } else
            {
                game.selectedItem = null;
            }
        }

        void switchBomb()
        {
            game.sceneManager.sceneIndex++;
        }

        void baguCallback()
        {
            if(game.gState == gameState.begin)
            {
                game.gState = gameState.baguEmpty;
                game.inventory.Add(new Item(new Dimension(681, 1242, 733, 1296)));
                game.util.Log("Added item! Inventory count = {0}", game.inventory.Count);
            }
        }

        void ventCallback()
        {
            if(game.gState == gameState.bombDefused)
            {
                game.sceneManager.sceneIndex = game.sceneManager.sceneIndex + 2;
            }
        }

        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
            
        }

        public override void unLoadScene()
        {
            
        }
    }
}
