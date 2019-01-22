using breakingBread.breakingBread.Game.util;
using GameEngine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace breakingBread.breakingBread.Game.gameObjects
{
    class pBitmap
    {
        Dimension dimensions;
        MainGameClass game = MainGameClass.Instance;
        System.Drawing.Bitmap bit;

        int ID;
        public pBitmap(int _id)
        {
            ID = _id;
            bit = new System.Drawing.Bitmap(game.assetPath + "textureSheet.png");
            setCoords(ID, bit);
        }

        public Bitmap getBitmap()
        {
            if (!Directory.Exists(game.assetPath + @"\temp"))
            {
                Directory.CreateDirectory(game.assetPath + @"\temp");
            }

            //+ (Directory.GetFiles(game.assetPath + @"\temp").Length + 1).ToString() + 
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(dimensions.w, dimensions.h);
            int fileCount = Directory.GetFiles(game.assetPath + @"\temp").Length;
            System.Drawing.Color filterColor = System.Drawing.Color.FromArgb(255, 0, 242);

            for (int x = 0; x < dimensions.w; x++)
            {
                for (int y = 0; y < dimensions.h; y++)
                {
                    //if (bit.GetPixel(bitmapDimensions.x + x, bitmapDimensions.y + y).R != filterColor.R && bit.GetPixel(bitmapDimensions.x + x, bitmapDimensions.y + y)).G != filterColor.G && bit.GetPixel(bitmapDimensions.x + x, bitmapDimensions.y + y).B != filterColor.B)
                    if(!sameColor(dimensions.x + x, dimensions.y + y, filterColor, bit))
                    {
                        System.Drawing.Color curColor = System.Drawing.Color.FromArgb(bit.GetPixel(dimensions.x + x, dimensions.y + y).R, bit.GetPixel(dimensions.x + x, dimensions.y + y).G, bit.GetPixel(dimensions.x + x, dimensions.y + y).B);

                        bitmap.SetPixel(x, y, curColor);
                    }
                }
            }

            bitmap.Save(game.assetPath + @"\temp\" + fileCount + ".png");

            return new Bitmap(@"\temp\" + fileCount + ".png");
        }

        public void setCoords(int id, System.Drawing.Bitmap bit)
        {
            System.Drawing.Color borderColor = System.Drawing.Color.FromArgb(123, 0, 255);
            int count = 0;
            int x, y;

            for(y = 0; y < bit.Height; y++)
            {
                for(x = 0; x < bit.Width; x++)
                {

                }
            }
            //for (y = 0; y < bit.Height; y++)
            //{

            //    if (pos.X != 0)
            //    {
            //        x = pos.X;
            //    }

            //    for (x = 0; x < bit.Width; x++)
            //    {
            //        if (x >= 0 && x < bit.Width && y >= 0 && y < bit.Height)
            //            //Get position
            //            if (pos.X == 0 && pos.Y == 0)
            //            {
            //                if (sameColor(x, y, borderColor, bit) && !sameColor(x + 1, y, borderColor, bit))
            //                {
            //                    if (count == id)
            //                    {
            //                        pos = new Vector2(x + 1, y);
            //                    }
            //                    else
            //                    {
            //                        count++;
            //                    }
            //                } else
            //                {
            //                    y++;
            //                    break;
            //                }
            //            }

            //        if (pos.X != 0 && pos.Y != 0)
            //        {
            //            //Get Width
            //            if ((x + 1) < bit.Width)
            //            {
            //                if (sameColor(x + 1, y, borderColor, bit) && !sameColor(x, y, borderColor, bit))
            //                {
            //                    if (count == id)
            //                    {
            //                        size = new Vector2(x - pos.X, size.Y);
            //                    }
            //                    else
            //                    {
            //                        count++;
            //                    }
            //                }
            //            }

            //            if (size.X != 0 && x > (pos.X + size.X))
            //            {
            //                break;
            //            }
            //            //Get Height
            //            if ((x + 1) < bit.Width && (y + 1) < bit.Height)
            //            {
            //                if (sameColor(x + 1, y, borderColor, bit) && sameColor(x, y + 1, borderColor, bit))
            //                {
            //                    if (count == id)
            //                    {
            //                        size = new Vector2(size.X, y - pos.Y);
            //                    }
            //                    else
            //                    {
            //                        count++;
            //                    }
            //                }
            //            }

            //        }
            //    }
            //    if (pos.X != 0 && pos.Y != 0 && size.X != 0 && size.Y != 0)
            //    {
            //        break;
            //    }
            //}
                    Console.Clear();
                    Console.WriteLine("X: {0} | y: {1} | w: {2} | h: {3}", dimensions.x, dimensions.y, dimensions.w, dimensions.h);
        }

        private bool sameColor(int x, int y, System.Drawing.Color color, System.Drawing.Bitmap bit)
        {
            return sameColor(new Vector2(x, y), color, bit);
        }

        private bool sameColor(Vector2 pixelPos, System.Drawing.Color color, System.Drawing.Bitmap bit)
        {
            if (bit.GetPixel(pixelPos.X, pixelPos.Y).R == color.R && bit.GetPixel(pixelPos.X, pixelPos.Y).G == color.G && bit.GetPixel(pixelPos.X, pixelPos.Y).B == color.B)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
