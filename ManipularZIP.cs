using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace EstudiandoHilos
{
    internal class ManipularZIP
    {
        public void descomprimirZIP(string pRutadelZIP, string pRutaDondeSeVaDescomprimir)
        {
            try
            {
                ZipFile.ExtractToDirectory(pRutadelZIP, pRutaDondeSeVaDescomprimir);
                Console.WriteLine("Descompresión exitosa..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
