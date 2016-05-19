using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEffects.Effects
{
    class SimpleGrayscale
    {
        private Color MakeGreyscale(Color color)
        {
            int sum = color.R + color.G + color.B;
            return Color.FromArgb(sum/3, sum/3, sum/3);
        }

        public Bitmap Apply(Bitmap inputBitmap)
        {
            Bitmap resultBitmap = new Bitmap(inputBitmap);
            for (int i = 0; i < inputBitmap.Height; i++)
            {
                for (int j = 0; j < inputBitmap.Width; j++)
                {
                    resultBitmap.SetPixel(j, i, MakeGreyscale(inputBitmap.GetPixel(j, i)));
                }
            }
            return resultBitmap;
        }
    }
}
