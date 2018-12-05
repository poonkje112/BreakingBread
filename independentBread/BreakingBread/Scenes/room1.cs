using breakingBread.BreakingBread.Util;
using GameEngine;
using independentBread.BreakingBread.Util;
using System;
using System.Collections.Generic;

namespace breakingBread.BreakingBread.Scenes
{
    class room1
    {
        //TODO: Fix memory leak
        //TODO: Fix Bounds

        #region Singleton
        private static readonly room1 instance = new room1();

        static room1() { }
        private room1() { }

        public static room1 Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        variables vars = variables.Instance;
        Bitmap placeHolderMap, bVent, bBomb, bBagu;
        Dictionary<string, bButton> buttons = new Dictionary<string, bButton>();

        public void Draw()
        {
            //Everything you want to draw goes here
            vars.engine.DrawBitmap(placeHolderMap, 0, 0);
        }

        public void Start()
        {
            //This will be called when the scene get's initialized
            Console.WriteLine("Room 1");
            placeHolderMap = new Bitmap("Room_1_sketch.png");
            bVent = new Bitmap("vent.png");
            bBomb = new Bitmap("bomb.png");
            bBagu = new Bitmap("bagu.png");
            vars.sceneManager.switching = isSceneSwitching.n;
            initializeButtons();
        }

        void initializeButtons()
        {
            buttons.Add("Vent", new bButton(Vent, bVent, 514, 342, 257, 200, string.Empty));
            buttons.Add("Bomb", new bButton(Bomb, bBomb, 40, 411, 85, 171, "bombBounds.png"));
            buttons.Add("Bagu", new bButton(Bagu, bBagu, 864, 538, 288, 78, "baguBounds.png"));
            //buttons["Bagu"].doHoverAnimation = false;
            buttons["Bomb"].setHover(true, Color.Black);
            buttons["Bagu"].setHover(true, Color.Black);
            buttons["Vent"].setHover(true, Color.Black);
        }

        void Vent()
        {
            Console.WriteLine("Vent");
        }

        void Bomb()
        {
            //Switch to bomb scene
            Console.WriteLine("Bomb");
        }

        void Bagu()
        {
            Console.WriteLine("Bagu");

        }

        void callback()
        {
            vars.sceneManager.sceneIndex--;
        }

        public void Update()
        {
            //This is called every frame
        }

        public void unLoad()
        {
            //Cleanup your scene when you are going to an other scene
            bBomb.Dispose();
            bVent.Dispose();
        }


    }
}
