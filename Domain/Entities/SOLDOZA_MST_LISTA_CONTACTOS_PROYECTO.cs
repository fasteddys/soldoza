using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SOLDOZA_MST_LISTA_CONTACTOS_PROYECTO
    {
        public int id { get; set; }
        public string abrev_tipo_contacto { get; set; }
        public string descripcion_tipo_contacto { get; set; }
        public string cod_contacto { get; set; }
        public string nombre_contacto { get; set; }
        public string apellidos_contacto { get; set; }
        public string email_contacto { get; set; }
        public string telefono_contacto { get; set; }
    }
}
