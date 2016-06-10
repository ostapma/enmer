using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using EnmerCore.BL;
using EnmerWeb.Controllers.Helpers;
using EnmerWeb.Models;
using Microsoft.Owin.Security.DataHandler.Encoder;

namespace EnmerWeb.Controllers.Api
{
    public class ImageController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            var result = Request.CreateResponse(HttpStatusCode.OK);
            var picture = new PictureManager().GetPicture(id);
            if (picture!=null)
            {
                result.Content = new ByteArrayContent(picture.Data);
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                return result;
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            var file = provider.Contents[0];

            using (var stream = await file.ReadAsStreamAsync())
            {
                var imageProcessor  = new ImageProcessor();
                if (imageProcessor.IsValid(stream))
                {
                    int userPicSize= Int32.Parse(ConfigurationManager.AppSettings["UserpicSize"]);
                    string pictureID;
                    using (var convertedImageStream = imageProcessor.ProcessImage(stream, userPicSize, userPicSize))
                    {
                        pictureID = new PictureManager().AddPicture(imageProcessor.GetBytesArray(convertedImageStream));
                    }
                    return this.Ok(pictureID);
                }
            }
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

    }
}
