using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class Credits : pScene
    {
        MainGameClass game = MainGameClass.Instance;
        pInteractable exit;
        public override void startScene()
        {
            new Background("endOfDemo.png");
            exit = new pInteractable(Exit, 205, 470, 378, 107, new Dimension(3072 - 288, 1255, 3449 - 288, 1361));
        }
        private void Exit() {

            Environment.Exit(1);
        }
        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
        }
    }
}
