using breakingBread.BreakingBread.Player;
using breakingBread.BreakingBread.Scenes;
using GameEngine;
using independentBread.BreakingBread.Scenes;
using System.Collections.Generic;

namespace independentBread.BreakingBread.Util
{

    public enum isSceneSwitching
    {
        n = 0,
        y
    }

    class SceneManager
    {

        private int curSceneIndex;
        public int sceneIndex;
        private List<object> s = new List<object>();
        public isSceneSwitching switching = isSceneSwitching.n;
        private variables vars = variables.Instance;
        private Inventory inv = Inventory.Instance;

        #region Singleton
        private static readonly SceneManager instance = new SceneManager();

        static SceneManager() { }
        private SceneManager() { }

        public static SceneManager Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public void sUpdate()
        {
            s[curSceneIndex].GetType().GetMethod("Update").Invoke(s[curSceneIndex], null);
            if (curSceneIndex != sceneIndex)
            {
                switching = isSceneSwitching.y;
                switchScene();
            }
        }

        private void sStart()
        {
            s[curSceneIndex].GetType().GetMethod("Start").Invoke(s[curSceneIndex], null);
        }

        public void sDraw()
        {
            inv.drawInventory();
            s[curSceneIndex].GetType().GetMethod("Draw").Invoke(s[curSceneIndex], null);
        }

        public void Init()
        {
            s.Add(Menu.Instance);
            s.Add(room1.Instance);
            s.Add(SampleScene.Instance);
            s.Add(TestScene.Instance);

            startScene();
        }

        private void startScene()
        {
            curSceneIndex = 0;
            sceneIndex = 0;
            sStart();
        }

        public void sUnload()
        {
            s[curSceneIndex].GetType().GetMethod("unLoad").Invoke(s[curSceneIndex], null);
        }

        private void switchScene()
        {
            //TODO: Fade-in fade-out
            s[curSceneIndex].GetType().GetMethod("unLoad").Invoke(s[curSceneIndex], null);
            curSceneIndex = sceneIndex;
            sStart();
        }

    }
}
