using GameEngine;
using independentBread.BreakingBread.Util;


namespace independentBread.BreakingBread
{
    class TemplateScene
    {

        #region Singleton
        private static readonly TemplateScene instance = new TemplateScene();

        static TemplateScene() { }
        private TemplateScene() { }

        public static TemplateScene Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        variables vars = variables.Instance;

        public void Draw()
        {
            //Everything you want to draw goes here
        }

        public void Start()
        {
            //This will be called when the scene get's initialized
            vars.sceneManager.switching = isSceneSwitching.n;
        }

        public void Update()
        {
            //This is called every frame
        }

        public void unLoad()
        {
            //Cleanup your scene when you are going to an other scene
        }

    }
}
