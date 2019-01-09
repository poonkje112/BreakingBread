using breakingBread.breakingBread.Game.Scenes;
using breakingBread.breakingBread.Game.Scenes.Room_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    class scenes
    {
        MainGameClass game = MainGameClass.Instance;

        Splashscreen splash = new Splashscreen();
        mainMenu menu = new mainMenu();
        room1 room1 = new room1();
        bombDefuse bomb = new bombDefuse();
        room2 room2 = new room2();
        Death death = new Death();
        Credits credits = new Credits();

        public void warmupScenes()
        {
            Console.WriteLine("Warming up scenes...");
            game.scenes.Add(splash);
            game.scenes.Add(menu);
            game.scenes.Add(room1);
            game.scenes.Add(bomb);
            game.scenes.Add(room2);
            game.scenes.Add(credits);
            game.scenes.Add(death);
        }

    }
}
