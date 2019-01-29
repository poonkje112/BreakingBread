using breakingBread.breakingBread.Game.util;
using GameEngine;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game
{
    public enum wireState
    {
        B = 0,
        Y,
        R
    }

    public enum gameState
    {
        begin = 0,
        baguEmpty,
        bombDefused,
        lampMoving,
        lampClicked,
        endGame
    }

    public class MainGameClass
    {

        #region Singleton
        private static readonly MainGameClass instance = new MainGameClass();

        static MainGameClass() { }
        private MainGameClass() { }

        public static MainGameClass Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public int WIDTH = 1280;
        public int HEIGHT = 720;
        public List<pGameObject> gameObjects = new List<pGameObject>();
        public List<pGameObject> sortedGameObjects = new List<pGameObject>();
        public List<pScene> scenes = new List<pScene>();
        public List<Item> inventory = new List<Item>();
        public GameEngine.GameEngine engine;
        public SceneManager sceneManager = new SceneManager();
        public wireState wState;
        public gameState gState;
        public Utils util = new Utils();
        public Item selectedItem = null;
        public List<Dimension> dimensions;
        public Bitmap assetSheet;
        public Player player;


        public bool goUpdating = false;
#if DEBUG
        public string assetPath = "../../Assets/";
#else
                public string assetPath = "./Assets/";
#endif

        public void Update()
        {
            sceneManager.updateScene();
            if (goUpdating)
                sortedGameObjects = util.bubbleSort(gameObjects, instance);
        }

        public void Draw()
        {
            sceneManager.drawScene();
        }
    }
}
