using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.IO.FileSystem.AccessControl;
using SkiaSharp.QrCode;

/*


    FAIR WARNING, THIS PROGRAM IS ENTIRELY UNTESTED,
    THERE IS NO CERTAINTY THAT IT WILL WORK, LET ALONE
    EVEN RUN IN YOUR C SHARP COMPILER! YOU HAVE BEEN 
    WARNED!


*/

namespace QR
{
    public class QrCode
    {

        public static void Main(String[] args)
        {
            Generation();
        }

        public static void Generation()
        {
            var hold = "https://github.com/ilypaarg";
            using var generator = new QRCodeGenerator();

            var lvl = ECCLevel.H;
            var code = generator.CreateQrCode(hold, lvl);

            var inf = new SKImageInfo(512, 512);
            using var s = SKSurface.Create(inf);

            var canvas = s.Canvas;
            canvas.Render(code, 512, 512, SKColors.White);

            using var img = s.Snapshot();
            using var data = img.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = File.OpenWrite(@$"qr-{lvl}.png");
            data.SaveTo(stream);
        }
    }
}
