using breakingBread.breakingBread.Game;

namespace GameEngine
{
    public class breakingBread : AbstractGame
    {
        GameEngine engine;
        MainGameClass game;
        scenes scenes = new scenes();
        string version = "ALPHA 2.0";
        string buildDate = "9-1-2019";



        public override void GameStart()
        {
            scenes.warmupScenes();
            game.sceneManager.Start();

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
                game.gameObjects[i].Unsubscribe(game.gameObjects[i].ID);
        }

        public override void Update()
        {

            game.Update();
        }

        public override void Paint()
        {
            game.Draw();
            engine.DrawString("Version: " + version, game.WIDTH - 170, game.HEIGHT - 40, 250, 100);
            engine.DrawString("Build date: " + buildDate, game.WIDTH - 170, game.HEIGHT - 20, 250, 100);

        }
    }
}
