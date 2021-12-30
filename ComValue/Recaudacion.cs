using System;
using System.Reflection;

namespace ComValue
{
    [Serializable()]
    public class Recaudacion
    {

        public object admision_rol_clinica { get; set; }
        public object numero_pam { get; set; }
        public object profesional_rut_profesional { get; set; }
        public object prestacion { get; set; }
        public object accion_intervencion { get; set; }
        public object cod_forma_pago { get; set; }
        public object isapre_codigo_isapre { get; set; }
        public object id_transaccion { get; set; }
        public object id_proceso { get; set; }
        public object id_detalle { get; set; }
        public object id_pago { get; set; }
        public object fecha_recaudacion { get; set; }
        public object rut_cliente { get; set; }
        public object monto_recaudacion { get; set; }
        public object numero_documento { get; set; }
        public object numero_factura { get; set; }
        public object fecha_factura { get; set; }
        public object usuario_caja { get; set; }
        public object usuario_factura { get; set; }
        public object observacion { get; set; }
        public object empresa_tributaria { get; set; }


        public void Agregar(object p_admision_rol_clinica, object p_numero_pam, object p_profesional_rut_profesional, object p_prestacion, object p_accion_intervencion,object p_cod_forma_pago,object p_isapre_codigo_isapre,object p_id_transaccion,object p_id_proceso,object p_id_detalle,object p_id_pago ,object p_fecha_recaudacion ,object p_rut_cliente ,object p_monto_recaudacion ,object p_numero_documento ,object p_numero_factura ,object p_fecha_factura ,object p_usuario_caja ,object p_usuario_factura ,object p_observacion ,object p_empresa_tributaria )
        {

            this.admision_rol_clinica = p_admision_rol_clinica;
            this.numero_pam = p_numero_pam;
            this.profesional_rut_profesional = p_profesional_rut_profesional;
            this.prestacion = p_prestacion;
            this.accion_intervencion = p_accion_intervencion;
            this.cod_forma_pago = p_cod_forma_pago;
            this.isapre_codigo_isapre = p_isapre_codigo_isapre;
            this.id_transaccion = p_id_transaccion;
            this.id_proceso = p_id_proceso;
            this.id_detalle = p_id_detalle;
            this.id_pago = p_id_pago;
            this.fecha_recaudacion = p_fecha_recaudacion;
            this.rut_cliente = p_rut_cliente;
            this.monto_recaudacion = p_monto_recaudacion;
            this.numero_documento = p_numero_documento;
            this.numero_factura = p_numero_factura;
            this.fecha_factura = p_fecha_factura;
            this.usuario_caja = p_usuario_caja;
            this.usuario_factura = p_usuario_factura;
            this.observacion = p_observacion;
            this.empresa_tributaria = p_empresa_tributaria;
        }

    }
}
