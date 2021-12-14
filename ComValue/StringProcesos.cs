using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComValue
{
    [Serializable()]
    public class StringProcesos
    {
        public string id { get; set; }
        public string nombre { get; set; }

        public string description { get; set; }

        public StringProcesos(string p_id, string p_nombre, string p_description)
        {
            this.id = p_id;
            this.description = p_description;
            this.nombre = p_nombre;
        }

    }
}
