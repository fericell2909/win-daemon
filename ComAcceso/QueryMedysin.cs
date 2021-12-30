using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComAcceso
{
    class QueryMedysin
    {


        public string ingreso_pam(string desde, string hasta )
        {

            string f_desde = desde;
            string f_hasta = hasta;

            string query;

            query = @"select   ccp.id_ingreso,
                                gp.rut_prof,
                                ccp.cod_prestacion,
                                ccp.pam_numero,
                                ccp.rol_prof,
                                ai.cod_isapre,
                                ccp.cant_ate,
                                TO_CHAR(ccp.FECHA_INGRESO_PAM, 'YYYY/MM/DD') AS FECHA_INGRESO_PAM,
                                 TO_CHAR(pv.FECHA_VISACION, 'YYYY/MM/DD') AS FECHA_VISACION,
                                  pv.RESP_VISACION,
                                ccp.valor_total* ccp.cant_ate AS prestacion_total,
                                ccp.id_consumo,
                                nvl(ccp.RECARGO_URGENCIA_HABIL, 'N') RECARGO_URGENCIA_HABIL,
                                nvl(ccp.RECARGO_URGENCIA_INHABIL, 'N') RECARGO_URGENCIA_INHABIL,
                                nvl(ccp.COBERTURA_ISAPRE, 'N') COBERTURA_ISAPRE,
                                case seg.SISTEMA
                                when 'ADM'
                                THEN 'S'
                                else  'N'
                                END AS SEGURO_ESCOLAR,
                                nvl(ai.IND_LEY_URGENCIA, 'N') AS LEY_URGENCIA,
                                 TO_CHAR(FECHA_CONSUMO, 'YYYY-MM-DD') AS FECHA_CONSUMO,
                                  ai.ind_cobro_paquete AS COBRO_PAQUETE,
                                ai.cod_paquete AS CODIGO_PAQUETE
                        from cta_consumos_prestacion ccp,
                            gen_profesional gp,
                            adm_ingresos ai,
                            CTA_PAM_Visados pv,
                            pab_tablas pab,
                            CEU_ATENCION_SINIESTRO seg
                            where ccp.cod_empresa = 2
                            and ccp.estado = 'ATE'
                            and ccp.tipo_consumo = 'HMQ'
                            and gp.cod_empresa = ccp.cod_empresa
                            and gp.cod_prof = ccp.cod_prof
                            and ai.cod_empresa = ccp.cod_empresa
                            and ai.id_ingreso = ccp.id_ingreso
                            And ccp.Id_Ingreso = pv.Id_Ingreso(+)
                            And ccp.Cod_Empresa = pv.Cod_empresa(+)
                            AND ccp.ROL_PROF = pab.COD_ITEM
                            AND pab.COD_GRUPO = 5
                            and ccp.pam_numero = pv.pam_numero(+)
                            and ccp.Id_Ingreso = seg.Id_Ingreso(+)
                            AND ccp.rol_prof NOT IN(3, 6, 8, 23, 31, 32)
                            AND ccp.cod_prestacion NOT LIKE '04%'
                            AND ccp.pam_numero IS NOT NULL
                            AND ccp.pam_numero > 0
                            AND EXISTS
                            (SELECT 1
                            FROM CTA_CONSUMOS_PRESTACION x, CTA_PAM_Visados pv2
                            Where x.cod_empresa = ccp.cod_Empresa
                            and x.id_ingreso = ccp.id_ingreso
                            and x.pam_numero = ccp.pam_numero
                            and x.tipo_consumo = ccp.tipo_consumo
                            And x.Id_Ingreso = pv2.Id_Ingreso(+)
                            And x.pam_numero = pv2.pam_numero(+)
                            And x.Cod_Empresa = pv2.Cod_empresa(+)
                            and(
                            TO_CHAR(pv2.FECHA_VISACION, 'YYYY-MM-DD') BETWEEN ";

            query = query + "'" + $"{f_desde}" + "'" + " and " + "'" + $"{f_hasta}" + "'" + @" or TO_CHAR(x.FECHA_INGRESO_PAM, 'YYYY-MM-DD') BETWEEN ";
            query = query + "'" + $"{f_desde}" + "'" + " and " + "'" + $"{f_hasta}" + "'" + @" or (x.estado = 'ANU' And to_char(x.FECHA_ACCESO, 'YYYY-MM-DD') between ";

            query = query + "'" + $"{f_desde}" + "'" + " and " + "'" + $"{f_hasta}" + "'" + @" or to_char(x.FECHA_REG_CONSUMO, 'YYYY-MM-DD') between ";
            query = query + "'" + $"{f_desde}" + "'" + " and " + "'" + $"{f_hasta}" + "'" + @" ) ) ) order by 1,5 ";


            return query;

        }
    
        public string recaudacion(string desde , string hasta)
        {
            string f_desde = desde;
            string f_hasta = hasta;

            string query;

            query = @"SELECT 
                cdt.id_ingreso Admision_Rol_Clinica,
                ccp2.PAM_NUMERO NUMERO_PAM,
                gp.rut_prof PROFESIONAL_RUT_PROFESIONAL,
                cdt.COD_PRESTACION PRESTACION,
                ccp2.ROL_PROF Accion_Intervencion,
                FORMA.COD_FORMAPAGO COD_FORMA_PAGO,
                PAG.COD_ISAPRE ISAPRE_CODIGO_ISAPRE,
                cdt.ID_TRANSACCION ID_TRANSACCION,
                cdt.ID_PROCESO ID_PROCESO,
                cdt.ID_DETALLE ID_DETALLE,
                PAG.ID_PAGO ID_PAGO,
                TO_CHAR(TRAN.FECHA_TRANSACCION, 'YYYY-MM-DD')    FECHA_RECAUDACION,
                ff.rut_cliente || '-' || ff.dv_cliente   RUT_CLIENTE,
                cpp.total_pres MONTO_RECAUDACION,
                CASE WHEN PAG.NUM_DOCUMENTO IS NOT NULL THEN CASE WHEN PAG.NUM_DOCUMENTO LIKE '%-%' THEN SUBSTR(REPLACE(PAG.NUM_DOCUMENTO, '-',''), 1, LENGTH(PAG.NUM_DOCUMENTO) - 1) ELSE PAG.NUM_DOCUMENTO END ELSE '0' END NUMERO_DOCUMENTO,
                ff.numero_factura NUMERO_FACTURA,
                TO_CHAR(ff.fecha_factura, 'YYYY-MM-DD')       FECHA_FACTURA,
                TRAN.ID_USUARIO USUARIO_CAJA,
                ff.ID_USUARIO USUARIO_FACTURA,
                ff.OBS_FACTURA OBSERVACION,
                '' EMPRESA_TRIBUTARIA
            FROM   fac_factura ff,
                fac_pagosfactura fpf,
                cja_det_transaccion cdt,
                cja_prestacion_pago cpp,
                gen_profesional gp,
                CJA_PAGOS PAG,
                CJA_TRANSACCION TRAN,
                CJA_FORMA_DE_PAGO FORMA,
                CTA_Consumos_Prestacion ccp2
            WHERE
              ff.cod_empresa = 2
              AND ff.cod_facempre IN(4, 9)
              And ff.tipodoc_factura Not In('C', 'D')
              AND ff.FECHA_FACTURA >= TO_DATE(" + "'" + $"{f_desde}" + "'" + @", 'YYYY-MM-DD')
              AND ff.FECHA_FACTURA <= TO_DATE(" + "'" + $"{f_hasta}" + "'" + @", 'YYYY-MM-DD')
              AND fpf.cod_empresa = ff.cod_empresa
              AND fpf.numero_factura = ff.numero_factura
              AND fpf.tipodoc_factura = ff.tipodoc_factura
              AND fpf.cod_facempre = ff.cod_facempre
              AND cdt.cod_empresa = fpf.cod_empresa
              AND cdt.id_proceso = fpf.correl_proceso
              AND cdt.id_transaccion = fpf.id_transaccion
              AND cdt.id_detalle = fpf.id_detalle
              AND gp.cod_empresa = cdt.cod_empresa
              AND gp.cod_prof = cdt.cod_prof
              AND cpp.cod_empresa = cdt.cod_empresa
              AND cpp.id_proceso = cdt.id_proceso
              AND cpp.id_transaccion = cdt.id_transaccion
              AND cpp.id_detalle = cdt.id_detalle
              AND cpp.ID_PAGO = fpf.ID_PAGO
              AND cpp.ID_PAGO = PAG.ID_PAGO
              AND PAG.COD_EMPRESA = TRAN.COD_EMPRESA
              AND PAG.COD_SUCURSAL = TRAN.COD_SUCURSAL
              AND PAG.ID_TRANSACCION = TRAN.ID_TRANSACCION
              AND PAG.ID_PROCESO = TRAN.ID_PROCESO
              AND TRAN.ESTADO <> 'ANU'
              AND FORMA.COD_EMPRESA = PAG.COD_EMPRESA
              AND FORMA.COD_FORMAPAGO = PAG.COD_FORMAPAGO
              AND ccp2.ID_CONSUMO = cdt.ID_CONSUMO

              AND ccp2.PAM_NUMERO IS NOT NULL
            Union all
            SELECT
            cdt.id_ingreso Admision_Rol_Clinica,
            ccp2.PAM_NUMERO NUMERO_PAM,
            gp.rut_prof PROFESIONAL_RUT_PROFESIONAL,
            cdt.COD_PRESTACION PRESTACION,
            ccp2.ROL_PROF Accion_Intervencion,
            FORMA.COD_FORMAPAGO COD_FORMA_PAGO,
            PAG.COD_ISAPRE ISAPRE_CODIGO_ISAPRE,
            cdt.ID_TRANSACCION ID_TRANSACCION,
            cdt.ID_PROCESO ID_PROCESO,
            cdt.ID_DETALLE ID_DETALLE,
            PAG.ID_PAGO ID_PAGO,
            TO_CHAR(TRAN.FECHA_TRANSACCION, 'YYYY-MM-DD')    FECHA_RECAUDACION,
            ''                  RUT_CLIENTE,
            cpp.total_pres MONTO_RECAUDACION,
            CASE WHEN PAG.NUM_DOCUMENTO IS NOT NULL THEN CASE WHEN PAG.NUM_DOCUMENTO LIKE '%-%' THEN SUBSTR(REPLACE(PAG.NUM_DOCUMENTO, '-',''), 1, LENGTH(PAG.NUM_DOCUMENTO) - 1) ELSE PAG.NUM_DOCUMENTO END ELSE '0' END NUMERO_DOCUMENTO,
            0                     NUMERO_FACTURA,
            TO_CHAR('', 'YYYY-MM-DD') FECHA_FACTURA,
            TRAN.ID_USUARIO USUARIO_CAJA,
            '' USUARIO_FACTURA,
            '' OBSERVACION,
            '' EMPRESA_TRIBUTARIA
            FROM
              cja_det_transaccion cdt,
              cja_prestacion_pago cpp,
              gen_profesional gp,
              CJA_PAGOS PAG,
              CJA_TRANSACCION TRAN,
              CJA_FORMA_DE_PAGO FORMA,
              CTA_Consumos_Prestacion ccp2
            WHERE
                TO_CHAR(TRAN.FECHA_TRANSACCION, 'YYYY-MM-DD') >= " + "'" + $"{f_desde}" + "'" +
                "And TO_CHAR(TRAN.FECHA_TRANSACCION,  'YYYY-MM-DD') <= " + "'" + $"{f_hasta}" + "'" +
                @"AND gp.cod_empresa = cdt.cod_empresa 
                AND gp.cod_prof = cdt.cod_prof
                AND cpp.cod_empresa = cdt.cod_empresa
                AND cpp.id_proceso = cdt.id_proceso
                AND cpp.id_transaccion = cdt.id_transaccion
                AND cpp.id_detalle = cdt.id_detalle
                AND cpp.ID_PAGO = PAG.ID_PAGO
                AND PAG.COD_EMPRESA = TRAN.COD_EMPRESA
                AND PAG.COD_SUCURSAL = TRAN.COD_SUCURSAL
                AND PAG.ID_TRANSACCION = TRAN.ID_TRANSACCION
                AND PAG.ID_PROCESO = TRAN.ID_PROCESO
                AND TRAN.ESTADO <> 'ANU'
                AND FORMA.COD_EMPRESA = PAG.COD_EMPRESA
                AND FORMA.COD_FORMAPAGO = PAG.COD_FORMAPAGO
                AND ccp2.ID_CONSUMO = cdt.ID_CONSUMO
                AND FORMA.COD_FORMAPAGO IN(12,13,144)
				AND ccp2.PAM_NUMERO IS NOT NULL";

            return query;
        }
    }
}
