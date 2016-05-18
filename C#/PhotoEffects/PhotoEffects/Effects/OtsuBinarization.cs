using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoEffects.Effects
{
    class OtsuBinarization
    {
        public Bitmap Apply(Bitmap bitmap)
        {
            var luminance = new double[bitmap.Width, bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    luminance[i, j] = GetLuminance(bitmap.GetPixel(i, j));
                }
            }
            double otsuThreshold = ComputeThreshold(luminance);

            Bitmap resultBitmap = new Bitmap(bitmap);
            for (int i = 0; i < bitmap.Width; i++)
                for (int j = 0; j < bitmap.Height; j++)
                    resultBitmap.SetPixel(
                        i, j, 
                        luminance[i, j] > otsuThreshold
                        ? Color.FromArgb(255, 255, 255):
                        Color.FromArgb(0, 0, 0));
            return resultBitmap;
        }

        private double ComputeThreshold(double[,] luminance)
        {
            var intLuminance = new int[luminance.GetLength(0), luminance.GetLength(1)];
            for (int i = 0; i < luminance.GetLength(0); i++)
                for (int j = 0; j < luminance.GetLength(1); j++)
                    intLuminance[i, j] = (int) luminance[i, j];

            int min = intLuminance[0, 0];
            int max = intLuminance[0, 0];

            foreach (var luminanceValue in intLuminance)
            {
                min = Math.Min(min, luminanceValue);
                max = Math.Max(max, luminanceValue);
            }

            int histSize = max - min + 1;
            int[] hist = new int[histSize];

            foreach (var luminanceValue in intLuminance)
                hist[luminanceValue - min] ++;
            
            //sum of all bins multiplied by their middle position
            int m = 0;
            //sum of all bins height
            int n = 0;

            for (int t = 0; t <= max - min; t++)
            {
                m += t*hist[t];
                n += hist[t];
            }

            //max dispersion value between classes
            float maxSigma = -1;
            //threshold corresponded to maxSigma
            int thershold = 0;

            int alpha1 = 0;
            int beta1 = 0;

            for (int t = 0; t <= max - min; t++)
            {
                alpha1 += t*hist[t];
                beta1 += hist[t];

                //counting probability of first class
                float w1 = (float) beta1/n;

                float a = (float) alpha1/beta1 - (float) (m - alpha1)/(n - beta1);

                float sigma = w1*(1 - w1)*a*a;

                if (sigma > maxSigma)
                {
                    maxSigma = sigma;
                    thershold = t;
                }
            }

            thershold += min;
            return thershold;
        }

        private double GetLuminance(Color color)
        {
            return 0.2126*color.R + 0.7152*color.G + 0.0722*color.B;
        }
    }
}
