using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComDao
{
    class QueryMedysin
    {


        public string Get_ingreso_pam(IEnumerable desde, IEnumerable hasta)
        {

            var fechas = ( now: "" , desde : "" , hasta: "" );

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

            query = query + $"{fechas.desde}" + " and " + $"{fechas.hasta}" + @" or TO_CHAR(x.FECHA_INGRESO_PAM, 'YYYY-MM-DD') BETWEEN ";
            query = query + $"{fechas.desde}" + " and " + $"{fechas.hasta}" + @" or (x.estado = 'ANU' And to_char(x.FECHA_ACCESO, 'YYYY-MM-DD') between ";

            query = query + $"{fechas.desde}" + " and " + $"{fechas.hasta}" + @" or to_char(x.FECHA_REG_CONSUMO, 'YYYY-MM-DD') between ";
            query = query + $"{fechas.desde}" + " and " + $"{fechas.hasta}" + @" ) ) order by 1,5 ";



            return query;

        }
    }
}
