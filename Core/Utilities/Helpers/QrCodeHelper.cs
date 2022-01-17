using Entities.Concrete;
using MessagingToolkit.QRCode.Codec;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class QrCodeHelper
    {
        public static QrCode CreateQrCode(QrCode qrCode)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeScale = 5;
            Bitmap qrCodeToCreate = qrCodeEncoder.Encode(qrCode.RouterLink + "/" + qrCode.TableId.ToString());
            MemoryStream memoryStream = new MemoryStream();
            qrCodeToCreate.Save(memoryStream, ImageFormat.Jpeg);
            qrCode.QrCodeImagePath = memoryStream.ToArray();
            return qrCode;
        }
    }
}
