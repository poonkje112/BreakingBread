
using breakingBread.breakingBread;
using breakingBread.breakingBread.Game;
using System.Collections.Generic;

namespace GameEngine
{
    public class breakingBread : AbstractGame
    {
        Button start, credits, settings, exit;
        GameEngine engine;
        MainGameClass game;
        Button b;
        scenes scenes = new scenes();


        public override void GameStart()
        {
            start = new Button("Test", 0, 0, 500, 200);
            start.SetActive(false);
            game.sceneManager.Start();
            scenes.warmupScenes();

        }

        public override void GameInitialize()
        {
            base.GameInitialize();

            engine = GAME_ENGINE;
            game = MainGameClass.Instance;
            game.engine = engine;
            engine.SetScreenWidth(game.WIDTH);
            engine.SetScreenHeight(game.HEIGHT);
            engine.SetTitle("Breaking Bread");
            engine.SetBackgroundColor(Color.Black);
            
        }

        public override void GameEnd()
        {
        }

        public override void Update()
        {
            
            game.Update();
        }

        public override void Paint()
        {
            //engine.FillRectangle(0, 0, 8, 8);
            game.Draw();

        }
    }
}
