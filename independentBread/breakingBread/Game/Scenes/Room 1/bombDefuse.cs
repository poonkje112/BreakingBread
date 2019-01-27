using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
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
        MainGameClass game = MainGameClass.Instance;
        int attempt = 0;
        public override void startScene()
        {
            bck = new Background("bombBackground.png");
            bWire = new pInteractable(bWireCallback, 245, 191, 32, 320, new Dimension(-1, -1, -1, -1));
            bWire.setHover(true, 255, 0, 0);
            yWire = new pInteractable(yWireCallback, 365, 191, 32, 320, new Dimension(-1, -1, -1, -1));
            yWire.setHover(true, 255, 0, 0);
            rWire = new pInteractable(rWireCallback, 478, 191, 32, 320, new Dimension(-1, -1, -1, -1));
            rWire.setHover(true, 255, 0, 0);
        }

        public void bWireCallback() {
            if (game.wState == wireState.B) { returnScene(); } else { playerDeath(); }
        }
        public void yWireCallback() {
            if (game.wState == wireState.Y) { returnScene(); } else { playerDeath(); }

        }
        public void rWireCallback() {
            if (game.wState == wireState.R) { returnScene(); } else { playerDeath(); }

        }

        void returnScene()
        {
            game.gState = gameState.bombDefused;
            game.sceneManager.sceneIndex--;

        }

        void playerDeath()
        {
            if(attempt == 1)
            {
                game.sceneManager.sceneIndex = game.scenes.Count - 1;
            } else
            {
                attempt++;
            }
        }

        public override void updateScene()
        {
            
        }

        public override void drawScene()
        {
            
        }

    }
}
