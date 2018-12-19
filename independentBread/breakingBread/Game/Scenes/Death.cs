using breakingBread.breakingBread.Game.gameObjects;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class Death : pScene
    {
        MainGameClass game = MainGameClass.Instance;
        public override void startScene()
        {
            new Background("GameOver.png");
            new Button(Exit, "Exit game", 707, 264, 328, 55);
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
