using breakingBread.breakingBread.Game.gameObjects;
using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes.Room_1
{
    class bombDefuse : pScene
    {
        Background bck;
        pInteractable bWire, yWire, rWire;
        public override void startScene()
        {
            bck = new Background("bombBackground.png");
            bWire = new pInteractable(null, 245, 191, 32, 320, "bWire.png");
            bWire.setHover(true, 255, 0, 0);
            yWire = new pInteractable(null, 365, 191, 32, 320, "yWire.png");
            yWire.setHover(true, 255, 0, 0);
            rWire = new pInteractable(null, 478, 191, 32, 320, "rWire.png");
            rWire.setHover(true, 255, 0, 0);
        }
        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
            
        }

    }
}
