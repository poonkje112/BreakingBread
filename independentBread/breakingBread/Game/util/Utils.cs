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


        //public string calculateBounds(string iFileName, int R, int G, int B, MainGameClass game)
        //{
        //    System.Drawing.Bitmap bit;
        //    System.Drawing.Bitmap highlightBmp;
        //    List<Vector2f> boundPoints = new List<Vector2f>();

        //    //Initializing our main bitmap
        //    bit = new System.Drawing.Bitmap(game.assetPath + iFileName);

        //    //Initializing our highlight bitmap
        //    highlightBmp = new System.Drawing.Bitmap(bit.Width + 10, bit.Height + 10);

        //    for (int _x = 0; _x < bit.Width; _x++)
        //    {
        //        for (int _y = 0; _y < bit.Height; _y++)
        //        {
        //            if (bit.GetPixel(_x, _y).A == 0)
        //            {
        //                if (_x + 1 < bit.Width && bit.GetPixel(_x + 1, _y).A == 255)
        //                {
        //                    Vector2f currentpos = new Vector2f(_x, _y);
        //                    boundPoints.Add(currentpos);
        //                }

        //                if (_x - 1 != -1 && bit.GetPixel(_x - 1, _y).A == 255)
        //                {
        //                    Vector2f currentpos = new Vector2f(_x, _y);
        //                    boundPoints.Add(currentpos);
        //                }

        //                if ((_y - 1) != -1 && bit.GetPixel(_x, _y - 1).A == 255)
        //                {
        //                    Vector2f currentpos = new Vector2f(_x, _y);
        //                    boundPoints.Add(currentpos);
        //                }
        //                if ((_y + 1) < bit.Height && bit.GetPixel(_x, _y + 1).A == 255)
        //                {
        //                    Vector2f currentpos = new Vector2f(_x, _y);
        //                    boundPoints.Add(currentpos);
        //                }

        //            }
        //        }

        //    }

        //    for (int i = 0; i < boundPoints.Count; i++)
        //    {
        //        for (int x = 0; x < 6; x++)
        //        {
        //            for (int y = 0; y < 5; y++)
        //            {
        //                highlightBmp.SetPixel((int)boundPoints[i].X + x, (int)boundPoints[i].Y + y, System.Drawing.Color.FromArgb(255, R, G, B));
        //            }
        //        }
        //    }
        //    try
        //    {
        //        highlightBmp.Save(game.assetPath + "Hover_" + iFileName);
        //    }
        //    catch (Exception ex) { }

        //    highlightBmp.Dispose();
        //    bit.Dispose();
        //    GC.Collect();
        //    return "Hover_" + iFileName;

        //}

    }
}
