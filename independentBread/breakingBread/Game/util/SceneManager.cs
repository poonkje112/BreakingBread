using System;

namespace breakingBread.breakingBread.Game.util
{
    public enum isSceneSwitching
    {
        n = 0,
        y
    }

    class SceneManager
    {
        MainGameClass game;
        private int curSceneIndex = -1;
        public int sceneIndex = 0;
        isSceneSwitching switchState;
        int sceneAlpha = 255;

        public void Start()
        {
            game = MainGameClass.Instance;

        }

        int frameCount = 0;
        public void updateScene()
        {
            if (curSceneIndex != sceneIndex)
                switchState = isSceneSwitching.y;

            if (switchState == isSceneSwitching.y)
            {
                if (sceneAlpha == 255)
                {
                    for (int i = 0; i < game.gameObjects.Count; i++)
                    {
                        game.gameObjects[i].Unsubscribe(game.gameObjects[i].ID);
                    }

                    game.gameObjects.Clear();
                    curSceneIndex = sceneIndex;
                    game.scenes[sceneIndex].startScene();
                    switchState = isSceneSwitching.n;
                }
            }

            if (!game.goUpdating)
                for (int i = 0; i < game.gameObjects.Count; i++)
                    game.gameObjects[i].pUpdate();

            if (switchState == isSceneSwitching.n)
            {
                frameCount++;
                if (frameCount == 3)
                {
                    sceneAlpha -= 15;
                    frameCount = 0;
                }
            }
            else if (switchState == isSceneSwitching.y)
            {
                frameCount++;
                if (frameCount == 3)
                {
                    sceneAlpha += 15;
                    frameCount = 0;
                }
            }

            if (sceneAlpha > 255)
                sceneAlpha = 255;

            if (sceneAlpha < 0)
                sceneAlpha = 0;

        }

        public void drawScene()
        {
            for (int i = 0; i < game.gameObjects.Count; i++)
            {
                game.sortedGameObjects[i].pDraw();
            }
            game.engine.SetColor(0, 0, 0, sceneAlpha);
            game.engine.FillRectangle(0, 0, game.WIDTH, game.HEIGHT);
            game.engine.SetColor(0, 0, 0, 255);
        }
    }
}
