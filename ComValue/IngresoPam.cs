using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class IngresoPam
    {

        public object id_ingreso;
        public object rut_prof;
        public object cod_prestacion;
        public object pam_numero;
        public object rol_prof;
        public object cod_isapre;
        public object cant_ate;
        public object fecha_ingreso_pam;
        public object fecha_visacion;
        public object resp_visacion;
        public object prestacion_total;
        public object id_consumo;
        public object recargo_urgencia_habil;
        public object recargo_urgencia_inhabil;
        public object cobertura_isapre;
        public object seguro_escolar;
        public object ley_urgencia;
        public object fecha_consumo;
        public object cobro_paquete;
        public object codigo_paquete;

        public void Agregar(object p_id_ingreso, object p_rut_prof, object p_cod_prestacion, object p_pam_numero, object p_rol_prof, object p_cod_isapre, object p_cant_ate, object p_fecha_ingreso_pam, object p_fecha_visacion, object p_resp_visacion, object p_prestacion_total, object p_id_consumo, object p_recargo_urgencia_habil, object p_recargo_urgencia_inhabil, object p_cobertura_isapre, object p_seguro_escolar, object p_ley_urgencia, object p_fecha_consumo, object p_cobro_paquete, object p_codigo_paquete)
        {

            this.id_ingreso = p_id_ingreso;
            this.rut_prof = p_rut_prof;
            this.cod_prestacion = p_cod_prestacion;
            this.pam_numero = p_pam_numero;
            this.rol_prof = p_rol_prof;
            this.cod_isapre = p_cod_isapre;
            this.cant_ate = p_cant_ate;
            this.fecha_ingreso_pam = p_fecha_ingreso_pam;
            this.fecha_visacion = p_fecha_visacion;
            this.resp_visacion = p_resp_visacion;
            this.prestacion_total = p_prestacion_total;
            this.id_consumo = p_id_consumo;
            this.recargo_urgencia_habil = p_recargo_urgencia_habil;
            this.recargo_urgencia_inhabil = p_recargo_urgencia_inhabil;
            this.cobertura_isapre = p_cobertura_isapre;
            this.seguro_escolar = p_seguro_escolar;
            this.ley_urgencia = p_ley_urgencia;
            this.fecha_consumo = p_fecha_consumo;
            this.cobro_paquete = p_cobro_paquete;
            this.codigo_paquete = p_codigo_paquete;
        }
    }
}
