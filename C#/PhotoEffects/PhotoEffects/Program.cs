using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using PhotoEffects.Effects;

namespace PhotoEffects
{
    class Program
    {
        static void Main(string[] args)
        {
            var curPath = Directory.GetCurrentDirectory();
            Console.WriteLine(curPath);

            string effectName = "OtsuBinarization";
            string fileName = "adPaper.jpg";
            string imageDir = "../../Images/AdPaper/";
            string inputFilePath = imageDir + fileName;
            string outputFilePath = imageDir + effectName + "_" + fileName;

            Bitmap bitmap = new Bitmap(Image.FromFile(inputFilePath));
            var resultBitmap = new OtsuBinarization().Apply(bitmap);
            resultBitmap.Save(outputFilePath);
        }
    }
}
