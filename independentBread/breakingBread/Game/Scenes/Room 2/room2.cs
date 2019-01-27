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
            lamp = new pInteractable(moveTo, 537, 0, 31, 169, "lamp.png", true, 255, 0, 0);

            Inventory inventory = new Inventory();
            
        }

        void moveTo()
        {
            if (game.gState != gameState.lampClicked)
            {
                lamp.y += 355;
                game.gState = gameState.lampClicked;
            }

        }

        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
            
        }

    }
}
