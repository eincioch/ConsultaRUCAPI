using System;
using System.Collections.Generic;
using System.Text;

namespace ConsultaRUCApp
{
    public class Representante<T>
    {
        public Detalle Detalle { get; set; }
    }

    public class Detalle { 
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string desde { get; set; }
    }

}
