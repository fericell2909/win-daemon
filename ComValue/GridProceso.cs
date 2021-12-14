using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class GridProceso
    {
        public object id;
        public object description;
        public object nombre;
        public object ultimaejecucion;
        public object actualizadohasta;
        public object rangodesde;
        public object rangohasta;

        public void add(object p_id, object p_description, object p_nombre, object p_ultimaejecucion, object p_actualizadohasta, object p_rangodesde, object p_rangohasta) 
        {
            this.id = p_id;
            this.description = p_description;
            this.nombre = p_nombre;
            this.ultimaejecucion = p_ultimaejecucion;
            this.actualizadohasta = p_actualizadohasta;
            this.rangodesde = p_rangodesde;
            this.rangohasta = p_rangohasta;

        }
   
    }
}
