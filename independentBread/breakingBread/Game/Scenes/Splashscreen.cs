using breakingBread.breakingBread.Game.gameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class Splashscreen : pScene
    {
        MainGameClass game = MainGameClass.Instance;
        public override void startScene()
        {
            new Background("Breaking_bread_splash_1.0.png");
        }

        int frameCount = 0;
        public override void updateScene()
        {
            if (frameCount == 120)
                game.sceneManager.sceneIndex++;
            frameCount++;
        }
    }
}
