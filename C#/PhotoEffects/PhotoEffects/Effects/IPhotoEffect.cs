using System.Drawing;

namespace PhotoEffects.Effects
{
    public interface IPhotoEffect
    {
        Bitmap Apply(Bitmap inputBitmap);
    }
}