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
        pInteractable lamp, cheese, rat;
        MainGameClass game = MainGameClass.Instance;
        Player player;
        Inventory inventory;
        public override void startScene()
        {
            new Background("room2.png");
            lamp = new pInteractable(moveTo, 537, 0, 31, 169, "", true, 255, 0, 0);
            player = new Player(45, 595, .2f);
            inventory = new Inventory();
            cheese = new pInteractable(Cheese, 303, 207, 95, 95);
            rat = new pInteractable(null, 693, 512, 75, 75);
            
        }

        void moveTo()
        {
            if (game.gState != gameState.lampClicked && game.gState != gameState.lampMoving)
            {
                //lamp.y += 355;
                //game.gState = gameState.lampClicked;
                game.gState = gameState.lampMoving;
            }
        }

        void Cheese()
        {
            if (game.gState == gameState.lampClicked)
            {
                game.inventory.Add(new Item("cheese.png"));
                cheese.Unsubscribe(cheese);
            }
        }

        public override void updateScene()
        {
            if(game.gState == gameState.lampMoving)
            {
                if(lamp.y <= 355)
                {
                    lamp.y += 400f * game.engine.GetDeltaTime();
                } else
                {
                    game.gState = gameState.lampClicked;
                }
            }
        }

        public override void drawScene()
        {
            
        }

    }
}
