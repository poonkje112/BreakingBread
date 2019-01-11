using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game.util
{
    class Utils
    {
        public List<pGameObject> bubbleSort(List<pGameObject> inputList, MainGameClass game)
        {
            pGameObject temp;
            for (int write = 0; write < inputList.Count; write++)
            {
                for (int sort = 0; sort < inputList.Count - 1; sort++)
                {
                    if (inputList[sort].layer > inputList[sort + 1].layer)
                    {
                        temp = inputList[sort + 1];
                        inputList[sort + 1] = inputList[sort];
                        inputList[sort] = temp;
                    }
                }
            }
            game.goUpdating = false;
            return inputList;
        }

        public void Log(object text, params object[] arg0)
        {
#if DEBUG
            Console.WriteLine(text.ToString(), arg0);
#endif
        }

    }
}
