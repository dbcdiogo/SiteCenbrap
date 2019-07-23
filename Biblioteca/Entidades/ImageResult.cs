using System.IO;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;

namespace Biblioteca.Entidades
{
    public class ImageResult : FileStreamResult
    {
        public ImageResult(Image input) : this(input, input.Width) { }
        public ImageResult(Image input, int tamanho) :
           base(
             GetMemoryStream(input, tamanho),
             "image/png")
        { }

        static MemoryStream GetMemoryStream(Image input, int tamanho)
        {
            int width = input.Width;
            int height = input.Height;
            // maintain aspect ratio 
            if (input.Width > input.Height)
            {
                width = tamanho;
                height = input.Height * tamanho / input.Width;
            }
            else
            {
                height = tamanho;
                width = input.Width * tamanho / input.Height;
            }

            var bmp = new Bitmap(input, width, height);
            var ms = new MemoryStream();
            bmp.Save(ms,input.RawFormat);
            ms.Position = 0;
            return ms;
        }
    }
}
