using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;

namespace breakingBread.breakingBread.Game.Scenes
{
    class room2 : pScene
    {
        pInteractable lamp, cheese, rat, decal1, decal2, decal3;
        MainGameClass game = MainGameClass.Instance;
        Player player;
        Inventory inventory;
        public override void startScene()
        {
            new Background("room2.png");
            game.inventory.RemoveAt(0);
            player = new Player(45, 595, .2f);
            player.depthAnim = false;
            inventory = new Inventory();
            lamp = new pInteractable(moveTo, 537, -300, 31, 550, new Dimension(996, 1242, 1010, 1721));
            lamp.movePlayer = false;
            cheese = new pInteractable(Cheese, 268, 264, (1297 - 1235), (1392 - 1349), new Dimension(1235, 1349, 1297, 1392));
            cheese.movePlayer = false;
            rat = new pInteractable(Rat, 714, 534, (1088 - 1013), (1517 - 1454), new Dimension(1013, 1454, 1088, 1517));
            rat.movePlayer = false;
            game.inventory.Add(new Item(new Dimension(681, 1242, 733, 1296)));
            decal1 = new pInteractable(null, 229, 104, 5, 5, new Dimension(1013, 1242, 1232, 1452));
            decal1.doHoverAnimation = false;
            decal1.layer = player.layer + 1;

            decal2 = new pInteractable(null, 484, 8, 5, 5, new Dimension(1235, 1242, 1390, 1346));
            decal2.doHoverAnimation = false;
            decal2.layer = player.layer + 1;

            decal3 = new pInteractable(null, 613, 457, 5, 5, new Dimension(1393, 1242, 1623, 1388));
            decal3.doHoverAnimation = false;
            decal3.layer = player.layer + 1;

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
                game.inventory.Add(new Item(new Dimension(1235, 1395, 1287, 1449)));
                cheese.Unsubscribe(cheese);
            }
        }

        void Rat()
        {
            //if (game.selectedItem != null && game.inventory.Count > 1 && game.inventory[1] != null && game.inventory[1] == game.selectedItem)
            //{
                game.selectedItem = null;
                player.moveTo(moveCallback, 300, 595);
            //}
        }

        void moveCallback()
        {
            player.moveTo(moveCallback2, 495 + ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale), 500 - ((player.WalkingVert[0].h - player.WalkingVert[0].y) * player.scale));

        }
        void moveCallback2()
        {
            player.moveTo(switchScene, 932 - ((player.WalkingVert[0].w - player.WalkingVert[0].x) * player.scale), 500 - ((player.WalkingVert[0].h - player.WalkingVert[0].y) * player.scale));
            rat.Unsubscribe(rat);
        }

        void switchScene()
        {
            game.sceneManager.sceneIndex++;

        }
        public override void updateScene()
        {
            if (game.gState == gameState.lampMoving)
            {
                if (lamp.y <= 0)
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
