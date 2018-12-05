using independentBread.BreakingBread;
using independentBread.BreakingBread.Util;

namespace GameEngine
{
    public class breakingBread : AbstractGame
    {
        Button start, credits, settings, exit;
        GameEngine engine;
        SceneManager sceneManager;
        variables vars;
        public override void GameStart()
        {
            start = new Button("Test", 0, 0, 500, 200);
            start.SetActive(false);
        }

        public override void GameInitialize()
        {
            base.GameInitialize();
            vars = variables.Instance;
            sceneManager = SceneManager.Instance;

            engine = GAME_ENGINE;
            engine.SetScreenWidth(vars.Width);
            engine.SetScreenHeight(vars.Height);
            engine.SetTitle("Breaking Bread");
            engine.SetBackgroundColor(Color.Black);

            vars.sceneManager = sceneManager;
            sceneManager.Init();

            vars.engine = engine;
            
        }

        public override void GameEnd()
        {
            sceneManager.sUnload();
        }

        public override void Update()
        {
            sceneManager.sUpdate();
        }

        public override void Paint()
        {
            sceneManager.sDraw();

        }
    }
}
