using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class AnulacionPam
    {

        public object id_ingreso { get; set; }
        public object pam_numero { get; set; }
        public object programa_mod { get; set; }
        public object resp_acceso { get; set; }
        public object usuario { get; set; }
        public object fecha_acceso { get; set; }


        public void Agregar(object p_id_ingreso , object p_pam_numero , object p_programa_mod , object p_resp_acceso , object p_usuario , object p_fecha_acceso)
        {

            this.id_ingreso = p_id_ingreso;
            this.pam_numero = p_pam_numero;
            this.programa_mod = p_programa_mod;
            this.resp_acceso = p_resp_acceso;
            this.usuario = p_usuario;
            this.fecha_acceso = p_fecha_acceso;


    }
    }
}
