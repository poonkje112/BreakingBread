using GameEngine;
using independentBread.BreakingBread.Util;
using System;

namespace independentBread.BreakingBread
{
    class SampleScene : Scene
    {

        #region Singleton
        private static readonly SampleScene instance = new SampleScene();

        static SampleScene() { }
        private SampleScene() { }

        public static SampleScene Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        variables vars = variables.Instance;
        Button btn;

        public void Draw()
        {
            vars.engine.SetColor(Color.White);
            vars.engine.DrawRectangle(10, 10, 50, 50);
        }

        public void Start()
        {
            Console.WriteLine("Hello world!");
            btn = new Button(callBack, "TestBTN", 20, 20, 100, 50);
            vars.sceneManager.switching = isSceneSwitching.n;
            //btn.SetBackgroundColor(new Color(0, 0, 0, 0));
        }

        public void Update()
        {

        }

        private void callBack()
        {
            vars.sceneManager.sceneIndex--;
        }

        public void unLoad()
        {
            btn.SetActive(false);
            btn = null;
        }

    }
}
