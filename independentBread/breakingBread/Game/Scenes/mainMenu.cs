using breakingBread.breakingBread.Game.gameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.Scenes
{
    class mainMenu : pScene
    {
        MainGameClass game = MainGameClass.Instance;
        List<pInteractable> buttons = new List<pInteractable>();
        public override void startScene()
        {
            new Background("Startscherm.png");
            buttons.Add(new pInteractable(startGame, 0, 231, 379, 145, "playBtn.png"));
            buttons.Add(new pInteractable(Exit, 0, 613, 379, 107, "exitBtn.png"));
        }

        private void startGame()
        {
            game.sceneManager.sceneIndex++;
        }

        private void Exit()
        {
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
