﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    public class pScene
    {

        MainGameClass game = MainGameClass.Instance;

        public virtual void startScene() {
            game.scenes.Add(this);

        }
        public virtual void unLoadScene() { }

        public virtual void updateScene() { }

        public virtual void drawScene() { }
    }
}
