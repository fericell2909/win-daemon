using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComValue
{
    public static class Enum
    {
        public const string producion = "PRODUCCION";
        public const string staging = "STAGING";

        public const string boton_ejecutar = "Ejecutar";
        public const string boton_generar_csv = "Generar CSV";

        public const string ingreso_pam = "ingreso_pam";
        public const string recaudacion = "recaudacion";
        public const string envio_isapre = "envio_isapre";


        public const string csv_ingreso_pam = "Generando CSV - Ingreso Flujo PAM . . .";
        public const string csv_recaudacion = "Generando CSV - Recaudacion . . .";
        public const string csv_envio_isapre = "Generando CSV - Envio Isapre . . .";

        public const string eject_ingreso_pam = "Ejecutando - Ingreso Flujo PAM . . .";
        public const string eject_recaudacion = "Ejecutando - Recaudacion . . .";
        public const string eject_envio_isapre = "Ejecutando - Envio Isapre . . .";

        public const string mensaje_csv_ok = "CSV Generado Correctamente.";
        public const string titulo_mensaje = "Atencion, Aviso Importante...";
        public const string mensaje_eject_ok = "Proceso Enviado a INTRANET Correctamente.";

        public const string format_hora = "hh:mm:ss tt";
        public const string format_fecha = "dd/MM/yyyy";
        public const string fomat_fecha_proceso = "yyyy-MM-dd";

        public const string format_fecha_hora_csv = "yyyyMMddHHmmss";

        public const string mensaje_cargando_grilla = "Cargando Listado - Procesos Automaticos. . .";

        public const string method_post = "POST";
        public const string method_type_multipar_data = "multipart/form-data";

        public const string contenttype_json = "application/json; charset=utf-8";

        public const string log_inicio_csv = "Inicio CSV --> ";
        public const string log_ruta_csv = "Ruta CSV --> ";
        public const string log_termino_csv = "Terminado CSV --> ";


        public const string log_inicio_eject = "Inicio EJECUTAR --> ";
        public const string log_termino_eject = "Terminado EJECUTAR --> ";


        public const string log_fecha_inicio = "Fecha Inicio : ";
        public const string log_fecha_termino = "Fecha Termino : ";

        public const string log_numero_records = "Numero de Registros Encontrados : ";

        public const int hora_proceso = 7;
        public const int hora_second_time_proceso = 15;


    }
}
