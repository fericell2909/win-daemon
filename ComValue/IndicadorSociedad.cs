using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class IndicadorSociedad
    {
        public object rut_sociedad { get; set; }
        public object ind_retencion_exp { get; set; }

        public void Agregar(object p_rut_sociedad, object p_ind_retencion_exp)
        {

            this.rut_sociedad  = p_rut_sociedad;
            this.ind_retencion_exp = p_ind_retencion_exp;

        }
    }
}
