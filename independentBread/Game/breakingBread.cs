using breakingBread.breakingBread.Game;
using breakingBread.breakingBread.Game.util;
using System;

namespace GameEngine
{
    public class breakingBread : AbstractGame
    {
        GameEngine engine;
        MainGameClass game;
        scenes scenes = new scenes();
        string version = "Pre-Release 1.0";
        string buildDate = "26-1-2019";



        public override void GameStart()
        {
            scenes.warmupScenes();
            game.sceneManager.Start();
            foreach(Dimension d in game.util.dimensions)
            {
                game.util.Log("X: {0} Y: {1} W: {2} H: {3}", d.x, d.y, d.w, d.h);
            }
            game.dimensions = game.util.dimensions;

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
            for (int i = 0; i < game.gameObjects.Count; i++)
                game.gameObjects[i].Unsubscribe(game.gameObjects[i]);
        }

        public override void Update()
        {

            game.Update();
        }

        public override void Paint()
        {
            game.Draw();
            //engine.DrawString("Version: " + version, game.WIDTH - 170, game.HEIGHT - 40, 250, 100);
            //engine.DrawString("Build date: " + buildDate, game.WIDTH - 170, game.HEIGHT - 20, 250, 100);

        }
    }
}
