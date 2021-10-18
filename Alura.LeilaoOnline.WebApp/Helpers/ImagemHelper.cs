using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Helpers
{
    public static class ImagemHelper
    {
        /// <summary>
        /// Salva a imagem na pasta informada
        /// </summary>
        /// <param name="folderPath">Caminho da pasta de destino</param>
        /// <param name="upload">Conteúdo do Arquivo</param>
        /// <returns>Path da imagem salva</returns>
        public static string SalvarNaPasta(string folderPath, IFormFile upload)
        {
            if (upload != null)
            {
                var pathArquivo = Path.Combine(folderPath, upload.FileName);

                using (var stream = new FileStream(pathArquivo, FileMode.OpenOrCreate))
                {
                    upload.CopyTo(stream);
                }
            }

            return $"/images/{upload.FileName}";
        }
    }
}
