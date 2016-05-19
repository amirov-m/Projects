using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEffects.Effects
{
    class NegativeEffect
    {

        private Color MakeNegative(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        public Bitmap Apply(Bitmap inputBitmap)
        {
            Bitmap resultBitmap = new Bitmap(inputBitmap);
            for (int i = 0; i < inputBitmap.Height; i++)
            {
                for (int j = 0; j < inputBitmap.Width; j++)
                {
                    resultBitmap.SetPixel(j, i, MakeNegative(inputBitmap.GetPixel(j, i)));
                }
            }
            return resultBitmap;
        }
    }
}
