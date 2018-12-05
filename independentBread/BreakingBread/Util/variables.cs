using independentBread.BreakingBread.Util;

namespace GameEngine
{
    class variables
    {

        #region Singleton
        private static readonly variables instance = new variables();

        static variables() { }
        private variables() { }

        public static variables Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public GameEngine engine;
        public SceneManager sceneManager;
        public int Width = 1280;
        public int Height = 720;
#if DEBUG
        public string assetPath = "../../Assets/";
#else
                public string assetPath = "./Assets/" + filePath;
#endif

    }
}
