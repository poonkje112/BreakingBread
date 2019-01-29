using breakingBread.breakingBread.Game.Scenes;
using breakingBread.breakingBread.Game.Scenes.Room_1;
using breakingBread.breakingBread.Game.Scenes.Room_3;
using breakingBread.breakingBread.Game.Scenes.Slides;

namespace breakingBread.breakingBread.Game
{
    class scenes
    {
        MainGameClass game = MainGameClass.Instance;

        Splashscreen splash = new Splashscreen();
        mainMenu menu = new mainMenu();
        room1 room1 = new room1();
        Slide_1_1 slide_1_1 = new Slide_1_1();
        Slide_1_2 slide_1_2 = new Slide_1_2();
        bombDefuse bomb = new bombDefuse();
        Slide_2_1 slide_2_1 = new Slide_2_1();
        room2 room2 = new room2();
        room3 room3 = new room3();
        Death death = new Death();
        Credits credits = new Credits();

        public void warmupScenes()
        {
            game.util.Log("Warming up scenes...");
            game.assetSheet = new GameEngine.Bitmap("Asset_Sheet.png");
            //game.scenes.Add(splash);
            game.scenes.Add(menu);
            game.scenes.Add(slide_1_1);
            game.scenes.Add(slide_1_2);
            game.scenes.Add(room1);
            game.scenes.Add(bomb);
            game.scenes.Add(slide_2_1);
            game.scenes.Add(room2);
            game.scenes.Add(room3);
            game.scenes.Add(credits);
            game.scenes.Add(death);
        }
    }
}
