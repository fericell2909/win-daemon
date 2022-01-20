# Proyecto

Procesos Automaticos

## Descripcion

Aplicacion de windows realizada en C# que consume data de medisyn y la envia a un servicio de amsm satelite.
Tiene un timer que se ejecuta en ciertas horas y dias de la semana.

## Pasos

### Dependencies

* Newtonsoft.json
* RestSharp
* Visual Community version 2022

### Instalacion

```
    git clone git@github.com:mundobox/amsm-win-medisyn.git

```

### Ejecutar Programa

* AppConfig.config variables de configuracion tener en cuenta
* variable production = 0 indica url a staging.
* credenciales de bd para medisyn
```
        <add key="servidor" value="" />
		<add key="puerto" value="" />
		<add key="nombreservicio" value="" />
		<add key="user" value="" />
		<add key="password" value="" />
			
		<add key="production" value="0" />
		<add key="url_intranet_production" value="https://intranet.amsm.cl/" />
		<add key="url_intranet_staging" value="http://staging.amsm.cl/" />
		
		<add key="url_update_date" value="update_proc" />
		<add key="url_ingreso_pam" value="actualizar_pam_post" />
		<add key="url_recaudacion" value="ingreso_recaudaciones_post" />
		<add key="url_envio_isapre" value="actualizar_estado_pam_post" />
		<add key="url_anulacion_pam" value="anulados_medisyn_post" />
		<add key="url_indicador_staff" value="actualizar_staff_post" />
		<add key="url_indicador_sociedad" value="actualizar_sociedad_post" />
		<add key="url_motivo_no_cobranza" value="motivo_no_cobranza_post" />
		<add key="url_admision" value="actualizar_admision_post" />
		<add key="url_last_proc" value="last_proc" />

		<add key="ruta_csv" value="F:\csv\" />
		<add key="ruta_log" value="F:\log\" />
```

## Autores

    Equipo de Desarrolladores de gux

## Version History

* 1.0.0
    * Listado de procesos automaticos

## Imagenes
Inicio
<img src="/imagesrepo/screen.JPG" alt="Interfaz de PRocesos Automaticos"/>
