using breakingBread.breakingBread.Game.gameObjects;
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
        pInteractable Vent, Bomb, Bagu;
        MainGameClass game = MainGameClass.Instance;
        Player p;
        Random rand = new Random();
        public override void startScene()
        {
            Console.WriteLine("Room 1");
            bck = new Background("Room_1_sketch.png");
            Bomb = new pInteractable(bombCallback, 40, 411, 85, 171, "bomb.png", true, 255, 0, 0);
            Vent = new pInteractable(ventCallback, 511, 340, 257, 200, "vent.png", true, 255, 0, 0);
            Bagu = new pInteractable(baguCallback, 860, 537, 288, 78, "bagu.png", true, 255, 0, 0);
            new Inventory();
            p = new Player(game.WIDTH / 2 - (int)37.5, 550, 75, 75, 0);
            Bomb.setHover(true);
            game.wState = (wireState)(rand.Next(Enum.GetNames(typeof(wireState)).Length));

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
            Console.WriteLine("sCalled");
            game.sceneManager.sceneIndex++;
        }

        void baguCallback()
        {
            if(game.gState == gameState.begin)
            {
                game.gState = gameState.baguEmpty;
                game.inventory.Add(new Item("sample.png"));
                Console.WriteLine("Added item! Inventory count = {0}", game.inventory.Count);
            }
        }

        void ventCallback()
        {
            if(game.gState == gameState.bombDefused)
            {
                game.sceneManager.sceneIndex = game.scenes.Count - 2;
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
