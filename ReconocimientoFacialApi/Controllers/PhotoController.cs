using Microsoft.AspNetCore.Mvc;
using Microsoft.ProjectOxford.Face;
using Microsoft.ProjectOxford.Face.Contract;
using Newtonsoft.Json.Linq;
using ReconocimientoFacialApi.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ReconocimientoFacialApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Photo")]
    public class PhotoController : Controller
    {

        const string subscriptionKey = "e5431df6d3724726af6c979200f4295b";
        const string uriBase = "https://eastus.api.cognitive.microsoft.com/face/v1.0/detect";

        // public static bool UploadFoto(MemoryStream stream, string folder, string name)

        Face[] faces;                   // The list of detected faces.
        String[] faceDescriptions;      // The list of descriptions for the detected faces.

        private readonly IFaceServiceClient faceServiceClient =
        new FaceServiceClient(subscriptionKey, "https://eastus.api.cognitive.microsoft.com/face/v1.0");

        [HttpPost]
        [Route("SetFoto")]
        public async Task<Respuesta> SetFoto([FromBody]FotoRequest value)

        // public async Task<IHttpActionResult>

        {

            if (value == null)

            {

                return new Respuesta
                {
                    mensaje = "Error no se obtuvo datos",
                    validacion = false
                };

            };
            IEnumerable<FaceAttributeType> faceAttributes =
            new FaceAttributeType[] { FaceAttributeType.Gender,
                FaceAttributeType.Age, FaceAttributeType.Smile,
                FaceAttributeType.Emotion, FaceAttributeType.Glasses,
                FaceAttributeType.Hair };
            // Call the Face API.
            using (Stream imageFileStream = new MemoryStream(value.Array))
            {
                faces = await faceServiceClient.DetectAsync(imageFileStream, returnFaceId: true, returnFaceLandmarks: false, returnFaceAttributes: faceAttributes);
            }
            return new Respuesta
            {
                mensaje = faces[0].FaceAttributes.Age.ToString(),
                validacion = true
            };
        }









        // GET: api/Photo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Photo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Photo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Photo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
