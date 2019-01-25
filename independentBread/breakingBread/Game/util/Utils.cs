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
            get { return W; }
            set { W = value; }
        }

        public int h
        {
            get { return H; }
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
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("../../Assets/textureMap.png");
#else
                public string assetPath = "./Assets/";
        System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap("./Assets/textureMap.png");
#endif


        public void LoadTextureMap()
        {
            Console.WriteLine("Call");
            int xPos = -1, yPos = -1, w = -1, h = -1;
            Color border = new Color(156, 0, 130);
            Color filter = new Color(255, 0, 204);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    if (CompareColor(x, y, border))
                    {
                        if ((x + 1) < bitmap.Width && CompareColor(x + 1, y, filter))
                        {
                            xPos = x + 1;
                            yPos = y;
                        }
                        else break;
                    }
                    else if ((x + 1) < bitmap.Width && CompareColor(x + 1, y, border))
                    {
                        if (xPos != -1 && yPos != -1)
                        {
                            w = x;
                            for (int height = 0; height < bitmap.Height; height++)
                            {
                                if ((height + 1) < bitmap.Height && CompareColor(x, height + 1, border))
                                {
                                    h = height;
                                    break;
                                }
                            }
                        }
                        else { break; }
                    }

                    if (xPos != -1 && yPos != -1 && w != -1 && h != -1)
                    {
                        bool none = true;
                        foreach (Dimension d in dimensions)
                        {
                            if (xPos >= d.x && xPos <= d.w && yPos >= d.y && yPos <= d.h)
                            {
                                none = false;
                            }
                        }
                        if (none)
                        {
                            dimensions.Add(new Dimension(xPos, yPos, w, h));
                            xPos = -1;
                            yPos = -1;
                            w = -1;
                            break;
                        }
                        else
                        {
                            xPos = -1;
                            h = -1; 
                            yPos = -1;
                            w = -1;
                            h = -1;
                            break;
                        }
                    }
                }
            }

            CreateTextures();
        }
        private void CreateTextures()
        {
            //Create the actual textures
            bitmap.Dispose();
        }
        public bool CompareColor(int x, int y, Color compare)
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

        public void Log(object text, params object[] arg0)
        {
#if DEBUG
            Console.WriteLine(text.ToString(), arg0);
#endif
        }

    }
}
