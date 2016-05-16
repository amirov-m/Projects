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

            string fileName = "dog.jpg";
            string imagePath = "../../" + fileName;
            Bitmap bitmap = new Bitmap(Image.FromFile(imagePath));

            var resultBitmap = new GreyscaleEffect().Apply(bitmap);

            resultBitmap.Save("../../greyscale_dog.jpg");
        }
    }
}
