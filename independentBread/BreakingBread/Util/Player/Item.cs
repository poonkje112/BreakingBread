using GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.BreakingBread.Util
{
    class Item : GameObject
    {

        #region Singleton
        private static readonly Item instance = new Item();

        static Item() { }
        private Item() { }

        public static Item Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        variables vars = variables.Instance;
        Button btn;

        private string name, file;

        public Item(string itemName, string fileName)
        {
            name = itemName;
            file = fileName;
        }

        public override void Update()
        {
            
        }

        public override void Paint()
        {

        }


    }
}
