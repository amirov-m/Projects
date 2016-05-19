using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEffects.Effects
{
    class LuminancePreservingGrayscale
    {
        private Color MakeGreyscale(Color color)
        {
            double gamma = 0.2126*color.R + 0.7152*color.G + 0.0722*color.B;
            return Color.FromArgb((int) gamma, (int) gamma , (int) gamma);
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
