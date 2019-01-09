using breakingBread.breakingBread.Game.gameObjects;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class room2 : pScene
    {
        pInteractable lamp;
        MainGameClass game = MainGameClass.Instance;
        public override void startScene()
        {
            new Background("room2.png");
            lamp = new pInteractable(moveTo, 552, 0, 31, 169, "lamp.png", true, 255, 0, 0);

            Inventory inventory = new Inventory();
            
        }

        void moveTo()
        {
            Console.WriteLine("Hello World!");
            lamp.y += 250;
        }

        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
            
        }

    }
}
