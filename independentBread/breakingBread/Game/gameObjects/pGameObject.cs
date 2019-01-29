using breakingBread.breakingBread.Game;
using System;

namespace breakingBread.breakingBread
{
    public class pGameObject
    {

        private MainGameClass game = MainGameClass.Instance;
        public int ID = -1;
        public int layer = 0;
        public float scale = .25f;
        public float x, y, w, h;
        public string tag = "";

        public virtual void pUpdate() { }

        public virtual void pStart() { }

        public virtual void pInit() { }

        public virtual void pDraw() { }

        public virtual void Destroy() { }

        /// <summary>
        /// Subscribe the gameObject to the MainGameLoop
        /// </summary>
        /// <param name="gameObject">The gameObject</param>
        public void Subscribe(pGameObject gameObject)
        {
            game.goUpdating = true;
            gameObject.ID = game.gameObjects.Count;
            game.gameObjects.Add(gameObject);
        }

        /// <summary>
        /// Unsubscribe the gameObject from the MainGameLoop
        /// </summary>
        /// <param name="gameObjectIndex">The index of the gameObject you want to remove</param>
        public void Unsubscribe(pGameObject gameObject)
        {
            try
            {
                for (int i = 0; i < game.gameObjects.Count; i++)
                {
                    if (game.gameObjects[i].ID == gameObject.ID)
                    {
                        game.gameObjects[i].Destroy();
                        game.gameObjects.RemoveAt(i);
                    }
                }
            } catch(Exception ex)
            {
                //Unsubscribe(gameObject);
                Console.Clear();
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
