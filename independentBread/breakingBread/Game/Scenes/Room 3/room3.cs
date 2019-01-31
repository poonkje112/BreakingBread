using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;

namespace breakingBread.breakingBread.Game.Scenes.Room_3
{
    class room3 : pScene
    {
        pInteractable _lock, key, burger0, burger1, burger2, burger3, knife, tomato, pan, doorClosed, doorOpen, bacon, painting;
        Player player;
        public override void startScene()
        {
            new Background("Kamer_3.png");
            Inventory inv = new Inventory();
            game.inventory.RemoveAt(0);
            game.inventory.RemoveAt(0);
            //VERWIJDER MIJ

            game.inventory.Add(new Item(new Dimension(681, 1242, 733, 1296)));
            game.inventory.Add(new Item(new Dimension(1235, 1395, 1287, 1449)));
            game.gState = gameState.lampClicked;
            player = new Player(796, 563, 0.20f);
            _lock = new pInteractable(_Lock, 687, 337, 34, 28, new Dimension(696, 1627, 724, 1651));
            _lock.moveY = false;
            key = new pInteractable(Key, 1043, 77, 46, 80, new Dimension(453, 1672, 498, 1751));
            key.moveY = false;
            key.doHoverAnimation = false;
            key.layer = 5;
            key.movePlayer = false;
            tomato = new pInteractable(Tomato, 622, 560, 41, 45, new Dimension(501, 1672, 541, 1716));
            painting = new pInteractable(Painting, 969, -1, 241, 171, new Dimension(453, 1499, 693, 1669));
            painting.layer = 6;
            painting.moveY = false;


            burger0 = new pInteractable(Burger, 910, 558, 97, 43, new Dimension(2123, 1682, 2242, 1721));
            burger0.moveY = false;
            burger0.layer = 7;

            burger1 = new pInteractable(Burger, 910, 420, 120, 178, new Dimension(2245, 1544, 2364, 1721));
            burger1.visible = false;
            burger1.moveY = false;
            burger1.layer = 7;

            burger2 = new pInteractable(Burger, 910, 284, 120, 314, new Dimension(2367, 1408, 2486, 1721));
            burger2.visible = false;
            burger2.moveY = false;
            burger2.layer = 7;

            burger3 = new pInteractable(Burger, 910, 118, 120, 480, new Dimension(2489, 1242, 2608, 1721));
            burger3.visible = false;
            burger3.moveY = false;
            burger3.layer = 7;


            knife = new pInteractable(Knife, 983, 224, 18, 127, new Dimension(696, 1499, 722, 1624));
            knife.moveY = false;
            pan = new pInteractable(Pan, 389, 521, 109, 70, new Dimension(725, 1551, 833, 1620));
            doorClosed = new pInteractable(Door, 123, -1, 224, 278, new Dimension(1, 1499, 224, 1776));
            doorClosed.moveY = false;
            doorClosed.layer = 6;
            doorOpen = new pInteractable(null, 123, -1, 224, 278, new Dimension(227, 1499, 450, 1776));
            doorOpen.moveY = false;
            doorOpen.layer = 5;
            doorOpen.doHoverAnimation = false;
            bacon = new pInteractable(Bacon, 174, 227, 74, 50, new Dimension(725, 1499, 798, 1548));
            bacon.doHoverAnimation = false;
            bacon.moveY = false;
            bacon.layer = 4;

            //knife = new pInteractable(null, )
        }

        void Burger()
        {
            if (game.gState == gameState.lampClicked && game.inventory.Count > 1 && game.inventory[1] != null && game.selectedItem == game.inventory[1])
            {
                game.gState = gameState.Stage1;
                game.inventory.RemoveAt(1);
                burger1.visible = true;
                burger0.visible = false;
            }
            else if (game.gState == gameState.Stage1 && game.inventory.Count > 2 && game.inventory[2] != null && game.selectedItem == game.inventory[2])
            {
                game.gState = gameState.Stage2;
                game.inventory.RemoveAt(2);
                burger2.visible = true;
                burger1.visible = false;
            }
            else if (game.gState == gameState.Stage2 && game.inventory.Count > 2 && game.inventory[2] != null && game.selectedItem == game.inventory[2])
            {
                game.gState = gameState.Stage3;
                game.inventory.RemoveAt(2);
                burger3.visible = true;
                burger2.visible = false;
            }
        }

        void Knife()
        {
            if (game.gState == gameState.Stage1)
            {
                knife.Unsubscribe(knife);
                game.inventory.Add(new Item(new Dimension(654, 1672, 706, 1726)));
            }
        }

        void Tomato()
        {
            if (game.gState == gameState.Stage1 && game.inventory.Count > 1 && game.inventory[1] != null && game.selectedItem == game.inventory[1])
            {
                game.inventory.Add(new Item(new Dimension(544, 1672, 596, 1726)));
                game.selectedItem = null;
                tomato.Unsubscribe(tomato);
            }
        }

        void Door()
        {
            if (game.gState == gameState.Stage2)
            {
                doorOpen.visible = true;
                doorClosed.visible = false;
                bacon.doHoverAnimation = true;
            }
        }

        void Bacon()
        {
            bacon.Unsubscribe(bacon);
            game.inventory.Add(new Item(new Dimension(709, 1672, 761, 1726)));
        }

        void Pan()
        {
            if (game.gState == gameState.Stage2 && game.inventory.Count > 2 && game.inventory[2] != null && game.selectedItem == game.inventory[2])
            {
                game.inventory.RemoveAt(2);
                game.inventory.Add(new Item(new Dimension(764, 1672, 816, 1726)));
            }
        }

        void Painting()
        {
            if(game.gState == gameState.Stage3)
            {
                painting.Unsubscribe(painting);
                key.doHoverAnimation = true;
            }
        }

        void Key()
        {
            if (game.gState == gameState.Stage3)
            {
                key.Unsubscribe(key);
                game.inventory.Add(new Item(new Dimension(599, 1672, 651, 1726)));
            }
        }

        void _Lock ()
        {
            if (game.gState == gameState.Stage3 && game.inventory.Count > 2 && game.inventory[2] != null && game.selectedItem == game.inventory[2])
            {
                game.sceneManager.sceneIndex++;
            }
        }
    }
}
