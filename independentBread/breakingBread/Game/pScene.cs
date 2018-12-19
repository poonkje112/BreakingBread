using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game
{
    public class pScene
    {

        MainGameClass game = MainGameClass.Instance;

        public virtual void startScene() { }
        public virtual void unLoadScene() { GC.Collect(); }

        public virtual void updateScene() { }

        public virtual void drawScene() { }
    }
}
