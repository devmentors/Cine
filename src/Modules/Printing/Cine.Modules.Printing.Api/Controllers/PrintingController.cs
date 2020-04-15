using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Cine.Modules.Printing.Api.Dto.External;
using Cine.Shared.Modules;
using IronBarCode;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QRCoder;

namespace Cine.Modules.Printing.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrintingController : ControllerBase
    {
        private readonly IModuleClient _client;

        public PrintingController(IModuleClient client)
            => _client = client;

        [HttpGet]
        public async Task<IActionResult> PrintReservation([FromQuery] Guid reservationId)
        {
            var reservation = await _client.GetAsync<ReservationDto>("modules/reservations/details",
                new {ReservationId = reservationId});

            var json = JsonConvert.SerializeObject(reservation);

            var data = new QRCodeGenerator().CreateQrCode(json, QRCodeGenerator.ECCLevel.M);
            var qrCode = new QRCode(data);
            var qrCodeImage = qrCode.GetGraphic(20);

            qrCodeImage = ResizeBitmap(qrCodeImage, 200, 200);

            var memoryStream = new MemoryStream();
            qrCodeImage.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream, "image/jpeg");
        }

        private static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            var result = new Bitmap(width, height);
            using var g = Graphics.FromImage(result);
            g.DrawImage(bmp, 0, 0, width, height);
            return result;
        }
    }
}
