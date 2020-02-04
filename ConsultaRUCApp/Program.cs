using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ConsultaRUCApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string endpoint = "https://api.sunat.cloud/ruc/20164113532";

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
                Console.WriteLine($"Estado: {ruc.contribuyente_estado}");
                //...

                if (ruc.representante_legal.Count > 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("----- Representante(s) Legal(es)---");
                    Console.WriteLine("-----------------------------------");

                    foreach (var item in ruc.representante_legal)
                    {
                        Console.WriteLine($"-> {item.Key.ToString()}");

                        Console.WriteLine($"Nombre: {item.Value.nombre}");
                        Console.WriteLine($"Cargo: {item.Value.cargo}");
                        Console.WriteLine($"Desde: {item.Value.desde}");

                        Console.WriteLine("-----------------------------------");
                    }

                    Console.WriteLine("");
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("------- Nro(s) Empleado(s) --------");
                    Console.WriteLine("-----------------------------------");

                    foreach (var item in ruc.empleados)
                    {
                        Console.WriteLine($"Año-mes: {item.Key.ToString()}");

                        Console.WriteLine($"Trabajadores: {item.Value.trabajadores}");
                        Console.WriteLine($"Pensionistas: {item.Value.pensionistas}");
                        Console.WriteLine($"Prestadores Servicio: {item.Value.prestadores_servicio}");

                        Console.WriteLine("-----------------------------------");
                    }
                }


                //Console.WriteLine(json);
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex}" );
                Console.Read();
                //throw;
            }
        }
    }
}
