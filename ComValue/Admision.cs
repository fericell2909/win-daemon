using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class Admision
    {

        public object id_ingreso { get; set; }
        public object fecha_egreso { get; set; }

        public void Agregar(object p_id_ingreso, object p_fecha_egreso)
        {

            this.id_ingreso = p_id_ingreso;
            this.fecha_egreso = p_fecha_egreso;

        }

    }
}
