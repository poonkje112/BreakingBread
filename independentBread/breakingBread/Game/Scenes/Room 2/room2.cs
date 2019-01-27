using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;

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
            //169
            lamp = new pInteractable(moveTo, 537, -169, 31, 550, new Dimension(-1, -1, -1, -1), true, 255, 0, 0);
            player = new Player(45, 595, .2f);
            inventory = new Inventory();
            cheese = new pInteractable(Cheese, 303, 207, 95, 95, new Dimension(-1, -1, -1, -1));
            rat = new pInteractable(Rat, 693, 512, 75, 75, new Dimension(-1, -1, -1, -1));

        }

        void moveTo()
        {
            if (game.gState != gameState.lampClicked && game.gState != gameState.lampMoving)
            {
                game.gState = gameState.lampMoving;
            }
        }

        void Cheese()
        {
            if (game.gState == gameState.lampClicked)
            {
                game.inventory.Add(new Item(new Dimension(-1, -1, -1, -1)));
                cheese.Unsubscribe(cheese);
            }
        }

        void Rat()
        {
            if (game.selectedItem != null && game.inventory.Count > 1 && game.inventory[1] != null && game.inventory[1] == game.selectedItem)
            {
                rat.Unsubscribe(rat);
                game.selectedItem = null;
                player.moveTo(moveCallback, 300, 595);
            }
        }

        void moveCallback()
        {
            player.moveTo(moveCallback2, 495 + ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale), 569 - ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale));

        }
        void moveCallback2()
        {
            player.moveTo(switchScene, 932 - ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale), 569 - ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale));
        }

        void switchScene()
        {
            game.sceneManager.sceneIndex++;

        }
        public override void updateScene()
        {
            if (game.gState == gameState.lampMoving)
            {
                if (lamp.y <= -10)
                {
                    lamp.y += 400f * game.engine.GetDeltaTime();
                }
                else
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
