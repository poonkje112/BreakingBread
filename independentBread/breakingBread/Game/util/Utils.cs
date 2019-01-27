using GameEngine;
using System;
using System.Collections.Generic;

namespace breakingBread.breakingBread.Game.util
{

    struct Dimension
    {
        private int X;
        private int Y;
        private int W;
        private int H;
        public Dimension(int _x, int _y, int _w, int _h)
        {
            X = _x;
            Y = _y;
            W = _w;
            H = _h;
        }

        public int x
        {
            get { return X; }
            set { X = value; }
        }

        public int y
        {
            get { return Y; }
            set { Y = value; }
        }

        public int w
        {
            get { return W - X; }
            set { W = value; }
        }

        public int h
        {
            get { return H - Y; }
            set { H = value; }
        }

    }
    class Utils
    {
        MainGameClass game = MainGameClass.Instance;
        public List<Dimension> dimensions = new List<Dimension>();
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

#if DEBUG
        public string assetPath = "../../Assets/";
        //System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("../../Assets/textureMap.png");
#else
                public string assetPath = "./Assets/";
        //System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("./Assets/textureMap.png");
#endif


        //public Bitmap LoadTextureMap(string name)
        //{
        //    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(assetPath + name);
        //    System.Drawing.Bitmap file = new System.Drawing.Bitmap(bitmap.Width, bitmap.Height);
        //    Color filter = new Color(255, 0, 204);
        //    Color border = new Color(156, 0, 130);
        //    for(int x = 0; x < bitmap.Width; x++)
        //    {
        //        for(int y = 0; y < bitmap.Height; y++)
        //        {
        //            if(!CompareColor(x, y, filter, bitmap) && !CompareColor(x, y, border, bitmap))
        //            {
        //                file.SetPixel(x, y, bitmap.GetPixel(x, y));
        //            }
        //        }
        //    }
        //    file.Save(assetPath + "out_" + name);
        //    return new Bitmap("out_" + name);

        //}

        //public void LoadTextureMap()
        //{
        //    Console.WriteLine("Call");
        //    int xPos = -1, yPos = -1, w = -1, h = -1;
        //    Color border = new Color(156, 0, 130);
        //    Color filter = new Color(255, 0, 204);
        //    int lastX = 0, lastY = 0;
        //    for (lastY = 0; lastY < bitmap.Height; lastY++)
        //    {
        //        for (lastX = 0; lastX < bitmap.Width; lastX++)
        //        {
        //            if (CompareColor(lastX, lastY, border))
        //            {
        //                if ((lastX + 1) < bitmap.Width && CompareColor(lastX + 1, lastY, filter))
        //                {
        //                    xPos = lastX + 1;
        //                    yPos = lastY;
        //                }
        //                else break;
        //            }
        //            else if ((lastX + 1) < bitmap.Width && CompareColor(lastX + 1, lastY, border))
        //            {
        //                if (xPos != -1 && yPos != -1)
        //                {
        //                    w = lastX;
        //                    for (int height = 0; height < bitmap.Height; height++)
        //                    {
        //                        if ((height + 1) < bitmap.Height && CompareColor(lastX, height + 1, border))
        //                        {
        //                            h = height;
        //                            break;
        //                        }
        //                    }
        //                }
        //                else { break; }
        //            }

        //            if (xPos != -1 && yPos != -1 && w != -1 && h != -1)
        //            {
        //                bool none = true;
        //                foreach (Dimension d in dimensions)
        //                {
        //                    if (xPos >= d.x && w <= d.w && yPos >= d.y && h <= d.h)
        //                    {
        //                        none = false;
        //                    }
        //                }

        //                if ((w + 2) < bitmap.Width)
        //                {
        //                    lastY = 0;
        //                    lastX += (w + 2);
        //                }
        //                else if((h+1) < bitmap.Height)
        //                {
        //                    lastX = 0;
        //                    lastY += h + 1;
        //                }

        //                if (none)
        //                {
        //                    dimensions.Add(new Dimension(xPos, yPos, w, h));
        //                    xPos = -1;
        //                    yPos = -1;
        //                    w = -1;
        //                    break;
        //                }
        //                else
        //                {
        //                    xPos = -1;
        //                    h = -1;
        //                    yPos = -1;
        //                    w = -1;
        //                    h = -1;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    CreateTextures();
        //}
        //private void CreateTextures()
        //{
        //    //Create the actual textures
        //    bitmap.Dispose();
        //}
        public bool CompareColor(int x, int y, Color compare, System.Drawing.Bitmap bitmap)
        {
            if (bitmap.GetPixel(x, y).R == compare.R && bitmap.GetPixel(x, y).G == compare.G && bitmap.GetPixel(x, y).B == compare.B)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void unLoadTextureMap()
        {

        }

        public void unsubscribeAll(MainGameClass g)
        {
            for(int i = 0; i < g.gameObjects.Count; i++)
            {
                g.gameObjects[i].Destroy();
            }
        }

        public void Log(object text, params object[] arg0)
        {
#if DEBUG
            Console.WriteLine(text.ToString(), arg0);
#endif
        }

    }

    public struct Dimension
    {
        private int X, Y, W, H;

        public int x { get { return X; } set { X = value; } }
        public int y { get { return Y; } set { Y = value; } }
        public int w { get { return W; } set { W = value; } }
        public int h { get { return H; } set { H = value; } }
    }

}
