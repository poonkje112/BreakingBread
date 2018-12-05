using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.BreakingBread.Player
{
    class Inventory
    {

        #region Singleton
        private static readonly Inventory instance = new Inventory();

        static Inventory() { }
        private Inventory() { }

        public static Inventory Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        public void drawInventory()
        {

        }
    }
}
