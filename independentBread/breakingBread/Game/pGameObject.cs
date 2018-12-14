using breakingBread.breakingBread.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread
{
    public class pGameObject
    {

        MainGameClass game = MainGameClass.Instance;
        public int ID = -1;
        public int layer = 0;

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
            gameObject.ID = game.gameObjects.Count;
            game.gameObjects.Add(gameObject);
        }

        /// <summary>
        /// Unsubscribe the gameObject from the MainGameLoop
        /// </summary>
        /// <param name="gameObjectIndex">The index of the gameObject you want to remove</param>
        public void Unsubscribe(int ID)
        {
            for(int i = 0; i < game.gameObjects.Count; i++)
            {
                if(game.gameObjects[i].ID == ID)
                {
                    game.gameObjects[i].Destroy();
                    game.gameObjects.RemoveAt(i);
                }
            }
        }

    }
}
