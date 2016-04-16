using _02_BugApiServer.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace _02_BugApiServer.Foramtters
{
    public class ImageFormatter : MediaTypeFormatter
    {
        public ImageFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("image/png"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }
        public override bool CanWriteType(Type type)
        {
            return type == typeof(Bug);
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream
        writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(() => WriteToStream(type, value,
            writeStream, content));
        }

public void WriteToStream(Type type, object value, Stream stream,
HttpContent content)
        {
            Bug bug = (Bug)value;
            var imagePath = HostingEnvironment.MapPath(@"~/Photos/image-" + bug.Id + ".png");
            var exists = File.Exists(imagePath);
            Image image = Image.FromFile(imagePath);
            image.Save(stream, ImageFormat.Png);
            image.Dispose();
        }
    }

   
}