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


        public const string csv_ingreso_pam = "Generando CSV - Ingreso Flujo PAM . . .";
        public const string csv_recaudacion = "Generando CSV - Recaudacion . . .";

        public const string eject_ingreso_pam = "Ejecutando - Ingreso Flujo PAM . . .";
        public const string eject_recaudacion = "Ejecutando - Recaudacion . . .";


        public const string mensaje_csv_ok = "CSV Generado Correctamente.";
        public const string titulo_mensaje = "Atencion, Aviso Importante...";

        public const string format_hora = "hh:mm:ss tt";
        public const string format_fecha = "dd/MM/yyyy";

        public const string format_fecha_hora_csv = "yyyyMMddHHmmss";

    }
}
