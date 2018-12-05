using GameEngine;
using independentBread.BreakingBread.Util;

namespace independentBread.BreakingBread
{
    class TestScene : Scene
    {


        #region Singleton
        private static readonly TestScene instance = new TestScene();

        static TestScene() { }
        private TestScene() { }

        public static TestScene Instance
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

        }

        public void Start()
        {

            vars.sceneManager.switching = isSceneSwitching.n;
        }

        public void Update()
        {

        }

        private void callBack()
        {

        }

        public void unLoad()
        {

        }

    }
}
