using breakingBread.breakingBread.Game.gameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes.Slides
{
    class Slide_2_1 : pScene
    {
        public override void startScene()
        {
            new Background(@"\Slides\Slide_2.1.png");
        }

        bool called = false;
        int frameCount = 0;
        public override void updateScene()
        {
            if (!called && frameCount == 300)
            {
                game.sceneManager.sceneIndex++;
                called = true;
            }
            else
            {
                frameCount++;
            }
        }
    }
}
