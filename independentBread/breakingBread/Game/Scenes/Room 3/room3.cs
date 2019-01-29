using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes.Room_3
{
    class room3 : pScene
    {
        pInteractable _lock, key, burger, knife, tomato, pan;
        Player player;
        public override void startScene()
        {
            new Background("Kamer_3.png");
            new Inventory();
            player = new Player(796, 563, 0.20f);
            _lock = new pInteractable(null, 687, 337, 34, 28, new Dimension(-1, -1, -1, -1));
            key = new pInteractable(null, 1020, 23, 70, 90, new Dimension(-1, -1, -1, -1));
            tomato = new pInteractable(null, 621, 554, 39, 33, new Dimension(-1, -1, -1, -1));
            burger = new pInteractable(null, 916, 558, 97, 43, new Dimension(-1, -1, -1, -1));
            knife = new pInteractable(null, 983, 224, 18, 127, new Dimension(-1, -1, -1, -1));
            pan = new pInteractable(null, 365, 591, 101, 50, new Dimension(-1, -1, -1, -1));
            //knife = new pInteractable(null, )
        }
    }
}
