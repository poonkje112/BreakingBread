using breakingBread.breakingBread.Game;

namespace breakingBread.breakingBread
{
    public class pGameObject
    {

        MainGameClass game = MainGameClass.Instance;
        public int ID = -1;
        public int layer = 0;
        public int x, y, w, h;

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
        public void Unsubscribe(int _ID)
        {
            foreach(pGameObject gb in game.gameObjects)
            {
                if(gb.ID == _ID)
                {
                    gb.Destroy();
                }
            }
        }
    }
}
