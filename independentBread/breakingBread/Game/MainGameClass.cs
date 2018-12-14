﻿using breakingBread.breakingBread.Game.util;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game
{
    class MainGameClass
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
        public GameEngine.GameEngine engine;
        public SceneManager sceneManager = new SceneManager();
        public Utils util = new Utils();
#if DEBUG
        public string assetPath = "../../Assets/";
#else
                public string assetPath = "./Assets/" + filePath;
#endif

        public void Update()
        {
            sceneManager.updateScene();
            sortedGameObjects = util.bubbleSort(gameObjects);
        }

        public void Draw()
        {
            sceneManager.drawScene();
        }
    }
}