using QRCoder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.QRCode
{
    public static class QRCodeExtension
    {
        public static byte[] GenerateQrCode(this string textToEncode)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
            BitmapByteQRCode qrCode = new BitmapByteQRCode(qrCodeData);
            byte[] qrCodeAsBitmapByteArr = qrCode.GetGraphic(20);
            return qrCodeAsBitmapByteArr;
        }
    }
}
