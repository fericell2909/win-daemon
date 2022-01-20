using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class MotivonoCobranza
    {
        public object admision_rol_clinica { get; set; }
        public object motivo_no_cobranza { get; set; }


        public void Agregar(object p_admision_rol_clinica, object p_motivo_no_cobranza)
        {

            this.admision_rol_clinica = p_admision_rol_clinica;
            this.motivo_no_cobranza = p_motivo_no_cobranza;

        }

    }
}
