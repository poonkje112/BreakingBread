using breakingBread.breakingBread.Game.gameObjects;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class room1 : pScene
    {
        Background bck;
        pInteractable Vent, Bomb, Bagu;
        MainGameClass game = MainGameClass.Instance;
        Player p;
        bool bombDefused = false;
        public override void startScene()
        {
            Console.WriteLine("Room 1");
            bck = new Background("Room_1_sketch.png");
            Bomb = new pInteractable(bombCallback, 40, 411, 85, 171, "bomb.png", true, 255, 0, 0);
            p = new Player(50, 50, 100, 100, 0);
            Bomb.setHover(true);
        }

        void bombCallback()
        {
            if (!bombDefused)
            {
                game.sceneManager.sceneIndex++;
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
