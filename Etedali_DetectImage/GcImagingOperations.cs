using GrapeCity.Documents.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Etedali_DetectImage
{
    public class GcImagingOperations
    {
        public static string GetConvertedImage(byte[] stream)
        {
            using (var bmp = new GcBitmap())
            {
                bmp.Load(stream);

                // Convert to grayscale
                bmp.ApplyEffect(GrayscaleEffect.Get(GrayscaleStandard.BT601));
                // Resize to thumbnail
                var resizedImage = bmp.Resize(256, 256, InterpolationMode.NearestNeighbor);
                return GetBase64(resizedImage);
            }
        }

        #region helper
        private static string GetBase64(GcBitmap bmp)
        {
            using (MemoryStream m = new MemoryStream())
            {
                bmp.SaveAsPng(m);
                return Convert.ToBase64String(m.ToArray());
            }
        }
        #endregion
    }
}