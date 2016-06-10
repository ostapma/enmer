using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace EnmerWeb.Controllers.Helpers
{
    public class ImageProcessor
    {
        public bool IsValid(Stream imageStream)
        {
            try
            {
                Image image = Image.FromStream(imageStream);
            }
            catch (ArgumentException)
            {

                return false;
            }
            return true;
        }

        public byte[] GetBytesArray(Stream imageStream)
        {
            byte[] result;
            using (var streamReader = new MemoryStream())
            {
                imageStream.Seek(0, SeekOrigin.Begin);
                imageStream.CopyTo(streamReader);
                result = streamReader.ToArray();
                return result;
            }
        }

        public Stream ProcessImage(Stream imageStream, int width,
            int height)
        {
            Image image = Image.FromStream(imageStream);

            MemoryStream resultStream = new MemoryStream();

            GetFixedSize(image, width, height, true).Save(resultStream, GetEncoderInfo("image/jpeg"), GetJpgConversionQuality(100));
            return resultStream;
        }

        private System.Drawing.Image GetFixedSize(Image image, int width, int height, bool stretch)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            double destX = 0;
            double destY = 0;

            double nScale = 0;
            double nScaleW = 0;
            double nScaleH = 0;

            nScaleW = ((double)width / (double)sourceWidth);
            nScaleH = ((double)height / (double)sourceHeight);
            if (!stretch)
            {
                nScale = Math.Min(nScaleH, nScaleW);
            }
            else
            {
                nScale = Math.Max(nScaleH, nScaleW);
                destY = (height - sourceHeight * nScale) / 2;
                destX = (width - sourceWidth * nScale) / 2;
            }

            if (nScale > 1)
                nScale = 1;

            int destWidth = (int)Math.Round(sourceWidth * nScale);
            int destHeight = (int)Math.Round(sourceHeight * nScale);

            System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
        

            using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
            {
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                grPhoto.SmoothingMode = SmoothingMode.HighQuality;

                Rectangle to = new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);

                grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);

                return bmPhoto;
            }
        }

        private EncoderParameters GetJpgConversionQuality(long quality)
        {
            Encoder qualityEncoder = Encoder.Quality;
            var ratio = new EncoderParameter(qualityEncoder, quality);
            var codecParams = new EncoderParameters(1);
            codecParams.Param[0] = ratio;
            return codecParams;
        }

        private static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }

    }
}