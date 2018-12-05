using GameEngine;
using independentBread.BreakingBread.Util;
using System.Collections.Generic;

namespace independentBread.BreakingBread.Scenes
{
    class Menu : Scene
    {

        #region Singleton
        private static readonly Menu instance = new Menu();

        static Menu() { }
        private Menu() { }

        public static Menu Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        variables vars = variables.Instance;
        List<Button> buttons;

        public void Draw()
        {
            //Everything you want to draw goes here
        }

        public void Start()
        {
            //This will be called when the scene get's initialized
            buttons = new List<Button>();
            buttons.Add(new Button(startGame, "Start Game", 0, vars.Height / 4 * 3, vars.Width / 3, vars.Height / 4));
            buttons.Add(new Button(Options, "Options", vars.Width / 3, vars.Height / 4 * 3, vars.Width / 3, vars.Height / 4));
            buttons.Add(new Button(Exit, "Exit", vars.Width / 3 * 2, vars.Height / 4 * 3, vars.Width / 3, vars.Height / 4));
            vars.sceneManager.switching = isSceneSwitching.n;
        }

        public void Update()
        {
            //This is called every frame
        }

        public void unLoad()
        {
            //Cleanup your scene when you are going to an other scene
            foreach(Button b in buttons)
            {
                b.SetActive(false);
            }
            buttons.RemoveRange(0, buttons.Count);
        }

        private void startGame()
        {
            vars.sceneManager.sceneIndex++;
        }

        private void Options()
        {

        }

        private void Exit()
        {
            vars.engine.Quit();
        }

    }
}
