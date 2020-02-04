using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace ConsultaRUCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string endpoint = "https://api.sunat.cloud/ruc/10409047594";

            HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/json";

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string json = reader.ReadToEnd();

            RUC ruc = JsonConvert.DeserializeObject<RUC>(json);

            Console.WriteLine($"Razon Social: {ruc.ruc}");
            Console.WriteLine($"RUC: {ruc.razon_social}");
            Console.WriteLine($"Nombre Comercial: {ruc.nombre_comercial}");

            //Console.WriteLine(json);
            Console.Read();
        }
    }
}
