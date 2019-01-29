using breakingBread.breakingBread.Game.gameObjects;
using breakingBread.breakingBread.Game.util;
using System;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game.Scenes
{

    public enum fading
    {
        n = 0,
        trans,
        y
    }
    class mainMenu : pScene
    {
        MainGameClass game = MainGameClass.Instance;
        List<pInteractable> buttons = new List<pInteractable>();
        List<Background> slides = new List<Background>();
        Background fade;
        Background bck;
        Player player;
        fading fadeState;
        public override void startScene()
        {
            bck = new Background("Startscherm.png");
            player = new Player(-100, -100, 0.2f);
            buttons.Add(new pInteractable(startGame, -1, 237, (3991 - 3613), (2427 - 2256), new Dimension(1701, 1242, 2079, 1413)));
            buttons[buttons.Count - 1].movePlayer = false;
            buttons.Add(new pInteractable(Exit, -1, 615, (3991 - 3613), (2532 - 2427), new Dimension(1701, 1631, 2079, 1737)));
            buttons[buttons.Count - 1].movePlayer = false;

            slides.Add(new Background(@"\Slides\Slide_1.1.png"));
            slides[slides.Count - 1].layer = -3;
            slides[slides.Count - 1].x = 193;
            slides[slides.Count - 1].draw = true;

            slides.Add(new Background(@"\Slides\Slide_1.2.png"));
            slides[slides.Count - 1].layer = -3;
            slides[slides.Count - 1].x = 193;
            slides[slides.Count - 1].draw = false;

            slides.Add(new Background(@"\Slides\Slide_2.1.png"));
            slides[slides.Count - 1].layer = -3;
            slides[slides.Count - 1].x = 193;
            slides[slides.Count - 1].draw = false;

            Console.WriteLine(slides.Count);

            fade = new Background("fade.png");
            fade.layer = -3;
            fade.x = 193;
            fade.alpha = 0;
        }

        private void startGame()
        {

            player.x = -30;
            player.y = 329;
            player.moveTo(switchLevel, ((3991 - 3613) - 250), 329);
        }
        
        void switchLevel()
        {
            player.moveTo(null, (3991 - 3613), 329);
            game.sceneManager.sceneIndex++;
        }

        private void Exit()
        {
            Environment.Exit(1);
        }

        Random rand = new Random();
        int frameCount, fadeCount;
        int current, last;

        public override void updateScene()
        {
            if (frameCount >= 300 && fadeState == fading.n)
            {
                Console.WriteLine("Call");
                while (current == last)
                {
                    current = rand.Next(slides.Count);
                }
                fadeState = fading.y;
            } else
            {
                frameCount++;
            }

            if(fadeState == fading.y)
            {
                if(fadeCount == 3)
                {
                    fade.alpha += 15;
                    if(fade.alpha >= 255)
                    {
                        slides[current].draw = true;
                        slides[last].draw = false;
                        last = current;
                        fadeState = fading.trans;
                    }
                    fadeCount = 0;
                } else
                {
                    fadeCount++;
                }
            }

            if(fadeState == fading.trans)
            {
                if (fadeCount == 3)
                {
                    fade.alpha -= 15;
                    if (fade.alpha <= 0)
                    {
                        fadeState = fading.n;
                        frameCount = 0;
                    }
                    fadeCount = 0;
                }
                else
                {
                    fadeCount++;
                }
            }
        }

        public override void drawScene()
        {

        }
    }
}
