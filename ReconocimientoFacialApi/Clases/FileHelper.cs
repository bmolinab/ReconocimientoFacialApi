using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ReconocimientoFacialApi.Clases
{
    public class FileHelper

    {



        public static bool UploadFoto(MemoryStream stream, string folder, string name)
        {
            try
            {
                stream.Position = 0;
                var path = Path.Combine(Path.GetTempFileName(), name);

                File.WriteAllBytes(path, stream.ToArray());
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
