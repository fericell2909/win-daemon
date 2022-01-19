using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class EnvioIsapre
    {

        public object Id_Ingreso { get; set; }
        public object PAM_Numero { get; set; }

        public object FECHA_ENVIO_ISAPRE { get; set; }

        public void Agregar(object p_Id_Ingreso, object p_PAM_Numero, object p_FECHA_ENVIO_ISAPRE)
        {

            this.Id_Ingreso = p_Id_Ingreso;
            this.PAM_Numero = p_PAM_Numero;
            this.FECHA_ENVIO_ISAPRE = p_FECHA_ENVIO_ISAPRE;
        }

    }
}
