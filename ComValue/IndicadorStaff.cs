using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class IndicadorStaff
    {

        public object rut_profesional { get; set; }
        public object IND_STAFF { get; set; }
        public object categoria { get; set; }
        public object comision { get; set; }
        public object vigencia { get; set; }

        public void Agregar(object p_rut_profesional, object p_IND_STAFF, object p_categoria, object p_comision, object p_vigencia)
        {

            this.rut_profesional = p_rut_profesional;
            this.IND_STAFF = p_IND_STAFF;
            this.categoria = p_categoria;
            this.comision = p_comision;
            this.vigencia = p_vigencia;


        }
    }
}
