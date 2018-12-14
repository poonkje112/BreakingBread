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

        room1 room1 = new room1();
        room2 room2 = new room2();
        bombDefuse bomb = new bombDefuse();

        public void warmupScenes()
        {
            Console.WriteLine("Warming up scenes...");
            game.scenes.Add(room1);
            game.scenes.Add(bomb);
            game.scenes.Add(room2);
        }

    }
}
