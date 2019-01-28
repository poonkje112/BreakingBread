using breakingBread.breakingBread.Game.gameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes.Slides
{
    class Slide_1_2 : pScene
    {
        Background bck;
        public override void startScene()
        {
            bck = new Background(@"\Slides\Slide_1.2.png");
        }

        bool called = false;
        int frameCount = 0;
        int x = -300;
        int y = 0;
        public override void updateScene()
        {
            //125 145
            if (frameCount == 180)
            {
                if(bck.scale.X >= 1.75f)
                {
                    game.sceneManager.sceneIndex++;
                }
                if (bck.scale.X <= 2f)
                {
                    bck.scale = new GameEngine.Vector2f(bck.scale.X + 0.01f, bck.scale.Y + 0.01f);
                }
                if (bck.x >= x)
                {
                    bck.x -= 3;
                }

                if (bck.y >= y)
                {       
                    bck.y--;
                }
            } else
            {
                frameCount++;
            }
        }
    }
}
