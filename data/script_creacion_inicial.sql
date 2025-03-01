USE [GD2C2016]
GO
/****** Object:  Schema [MEDGOOD]    Script Date: 25/11/2016 17:13:19 ******/
CREATE SCHEMA [MEDGOOD]
GO
/****** Object:  StoredProcedure [MEDGOOD].[agregarFuncionalidad_ARol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[agregarFuncionalidad_ARol]
(@cod_rol numeric(18,0),
@cod_funcionalidad numeric(18,0))
as
begin
INSERT INTO MEDGOOD.FuncionalidadesRol 
(FUN_ROL_CODIGO,FUN_FUN_CODIGO) 
VALUES (@cod_rol,@cod_funcionalidad)
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[eliminar_funcionalidadDelRol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[eliminar_funcionalidadDelRol]
(@cod_rol numeric(18,0),
@cod_funcionalidad numeric(18,0))
as
begin
DELETE FROM MEDGOOD.FuncionalidadesRol 
WHERE FUN_ROL_CODIGO=@cod_rol 
and FUN_FUN_CODIGO=@cod_funcionalidad
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_busc_usuario]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [MEDGOOD].[sp_busc_usuario](@nombre varchar(255),@apellido varchar(255),@fechaNac datetime,@dni numeric(18,0))
 AS
 BEGIN
    declare @query nvarchar(512)
    set @query = 'SELECT * FROM MEDGOOD.Usuarios u, MEDGOOD.Afiliados WHERE usu_inhabilitado=0 AND afi_codigo_username=usu_codigo'
  
    if(LEN(@nombre) > 0) SET @query += ' AND usu_nombre LIKE '+QUOTENAME(@nombre,'''') +' ';
    if(LEN(@apellido) > 0) SET @query += ' AND usu_apellido LIKE '+QUOTENAME(@apellido,'''')+' ';
    if(LEN(@fechaNac) > 0) SET @query += ' AND CAST(usu_fechanacimiento as date) = '+QUOTENAME(@fechaNac,'''')+' ';
    if(@dni > 0) SET @query += ' AND usu_nrodocumento = '+QUOTENAME(@dni,'''')+' ';
          
    print @query
    execute sp_executesql @query
 END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_buscar_bonosDisponibles]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_buscar_bonosDisponibles]
(@codAfi numeric(18,0))
as
begin
select B.bon_codigo,B.bon_codigoafiliado,B.bon_codigocompra,B.bon_codigoplan,
       B.bon_fechaimpresion,B.bon_fue_usado,B.bon_nroconsultabono
from MEDGOOD.Bono B, MEDGOOD.CompraBono CP, MEDGOOD.Afiliados A
 where B.bon_fue_usado=0 and B.bon_codigocompra=CP.com_codigo
 AND A.afi_numeroafiliado=CP.com_codigoafiliado
and (A.afi_numeroafiliado=@codAfi OR A.afi_afiliadoprincipal=@codAfi)
AND B.bon_codigoplan=A.afi_planmedico
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_buscar_consultas_pendientes_profesional]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_buscar_consultas_pendientes_profesional]
(@codUser numeric(18,0),
@fechaDeHoy Datetime)
as
begin
      select c.con_codigo,c.con_bonocodigo,c.con_tur_numero,c.con_fechallegada_afiliado
      from MEDGOOD.Consulta C, MEDGOOD.Turno T, MEDGOOD.Profesionales P
      where C.con_tur_numero=T.tur_codigo and T.tur_profesionalcodigo=P.pro_numero
      and year(tur_fecha)=year(@fechaDeHoy)
      and month(tur_fecha)=month(@fechaDeHoy)
      and day(tur_fecha)=day(@fechaDeHoy)
       and P.pro_codigo_usuario=@codUser 
      and T.tur_estado=(select EC.est_codigo
                        from MEDGOOD.EstadoConsulta EC
                        WHERE EC.est_descripcion='Registrada')
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[SP_buscar_prof_con_esp]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[SP_buscar_prof_con_esp](@esp varchar(255))
AS
BEGIN
    SELECT *
    FROM Profesionales p, ProfporEspecialidad pe, Usuarios u, Especialidad e
    WHERE e.esp_descripcion=@esp AND pe.esp_codigo=e.esp_codigo AND pe.pro_numero=p.pro_numero AND p.pro_codigo_usuario=u.Usu_codigo
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_cambiarNombre_rol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE procedure [MEDGOOD].[sp_cambiarNombre_rol]
(@nombre_rol varchar(250),
 @cod_rol numeric(18,0))
 as
 begin
       UPDATE MEDGOOD.ROL 
       SET ROL_DESCRIPCION=@nombre_rol 
       WHERE ROL_CODIGO=@cod_rol
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_CancelarTurno]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_CancelarTurno] 
(
@CodigoUser numeric(18,0),
@idturno numeric(18,0),
@idMotivo numeric(18,0),
@Comentarios varchar(255))
  
AS
BEGIN
    DECLARE @idBono numeric (18,0)
   
BEGIN
  
set @idBono = (select con_bonocodigo from MEDGOOD.Consulta where con_tur_numero=@idturno )
        
            UPDATE MEDGOOD.Turno
            SET tur_cancelador = @CodigoUser,
            tur_estado=(select est_codigo from MEDGOOD.EstadoConsulta where est_descripcion='Cancelada'),
            tur_comentarios= @Comentarios,
            tur_motivo_cancelacion=@idMotivo
            where  tur_codigo= @idturno          
        
            UPDATE MEDGOOD.Bono
            SET bon_fue_usado = '0'
            where  bon_codigo= @idBono   
       
 END
  
END
 

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_cantidadConsultasBono_Afiliado]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_cantidadConsultasBono_Afiliado]
(@codAfiliado numeric(18,0))
as
begin
      select C.con_codigo from Consulta C,Turno T
      where C.con_tur_numero=T.tur_codigo
      AND T.tur_codigoafiliado=@codAfiliado
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_cargaAfiliado_porCodUser]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE Procedure [MEDGOOD].[sp_cargaAfiliado_porCodUser]
(@codUser numeric(18,0))
as
begin
   select afi_codigoafiliado,afi_numeroafiliado,
   pla_codigo,pla_descripcion,pla_bono_consulta 
   from MEDGOOD.Afiliados,MEDGOOD.Planes 
   where afi_codigo_username=@codUser
   and pla_codigo=afi_planmedico
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_cargarAfiliado_porCodAfiliado]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_cargarAfiliado_porCodAfiliado]
(@codAfiliado numeric(18,0))
as
begin
     select afi_codigoafiliado,afi_numeroafiliado,
     pla_codigo,pla_descripcion,pla_bono_consulta 
     from MEDGOOD.Afiliados,MEDGOOD.Planes 
     where afi_codigoafiliado=@codAfiliado and  pla_codigo=afi_planmedico
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_crear_afiliado]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
--Afiliados
 
CREATE PROCEDURE [MEDGOOD].[sp_crear_afiliado](@estadoCivil numeric(18,0),@cantHijos numeric(18,0),@plan numeric(18,0),@codUser decimal(18,0),@afiliadoPrincipal decimal(18,0))
 AS
 BEGIN
 IF (@afiliadoPrincipal = 0)
 BEGIN
 INSERT INTO MEDGOOD.Afiliados(afi_estadocivil,afi_cantidadhijos,afi_planmedico,afi_codigo_username)
 VALUES (@estadoCivil,@cantHijos,@plan,@codUser)
 UPDATE Afiliados
 SET afi_codigoafiliado = (afi_numeroafiliado*100)+1, afi_afiliadoprincipal=afi_numeroafiliado
 WHERE afi_codigo_username=@codUser
 END
 ELSE
 BEGIN
 DECLARE @cod numeric(18,0)
 DECLARE @nuevoCod numeric(18,0)
 SET @cod = (SELECT afi_numeroafiliado FROM MEDGOOD.Afiliados WHERE afi_codigoafiliado=@afiliadoPrincipal)
 SET @nuevoCod = (SELECT MAX(afi_codigoafiliado) FROM MEDGOOD.Afiliados WHERE afi_afiliadoprincipal=@cod)
 INSERT INTO MEDGOOD.Afiliados(afi_estadocivil,afi_cantidadhijos,afi_planmedico,afi_codigo_username,afi_codigoafiliado,afi_afiliadoprincipal)
 VALUES (@estadoCivil,@cantHijos,@plan,@codUser,@nuevoCod+1,@cod)
 END
 END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_crear_rol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_crear_rol]
(@cod_funcionalidad numeric (18,0),
 @nombre_rol varchar(250))
 as
 begin
 declare @id_nuevo_rol numeric (18,0)
 insert into MEDGOOD.Rol (rol_descripcion,rol_Estado,Rol_Es_Administrador)
 values (@nombre_rol,0,0);
 set @id_nuevo_rol=scope_identity();
 insert into MEDGOOD.FuncionalidadesRol(fun_fun_codigo,fun_rol_codigo)
 values (@cod_funcionalidad,@id_nuevo_rol);
 end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_crear_usuario]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
--PROCEDIMIENTOS--
 -- ABM Usuarios AFILIADOS
 --Usuarios
  
CREATE PROCEDURE [MEDGOOD].[sp_crear_usuario](@user varchar(255),@pass varchar(255),@pregSecre varchar(255),@resSecre varchar(255),@nombre varchar(255),@apellido varchar(255),@nroDoc numeric(18,0), @tipoDoc numeric(18,0), @direc varchar(255), @tel numeric(18,0), @mail varchar(255),@fechaNac datetime, @sexo bit, @fechaCrea datetime)
 AS
 BEGIN
 INSERT INTO MEDGOOD.Usuarios (Usu_username,Usu_password,Usu_fechacreacion,Usu_fecha_ultima_modificacion,Usu_pregunta_secreta,Usu_respuesta_secreta, Usu_intentos_fallidos,Usu_inhabilitado,Usu_nombre,Usu_apellido,Usu_nrodocumento,Usu_tipodocumento,Usu_direccion,Usu_telefono,Usu_mail,Usu_fechanacimiento,Usu_sexo)
 VALUES (@user,@pass,@fechaCrea,@fechaCrea,@pregSecre,@resSecre,0,0,@nombre,@apellido,@nroDoc,@tipoDoc,@direc,@tel,@mail,@fechaNac,@sexo)
 INSERT INTO RolesUsuario (rol_rol_codigo,rol_usu_codigo)
 VALUES (2,SCOPE_IDENTITY())
 END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_especialidades]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 CREATE PROCEDURE [MEDGOOD].[sp_especialidades]
as
begin
     select * 
     from MEDGOOD.Especialidad
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_especialidades_de_usuario]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE PROCEDURE [MEDGOOD].[sp_especialidades_de_usuario](@user numeric(18,0))
AS
BEGIN
     SELECT e.esp_codigo,e.esp_descripcion,e.esp_tipo_codigo
     FROM MEDGOOD.Especialidad e, MEDGOOD.Profesionales p, MEDGOOD.ProfporEspecialidad pe
     WHERE p.pro_codigo_usuario=@user AND p.pro_numero=pe.pro_numero AND pe.esp_codigo=e.esp_codigo
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_funcionalidadesDe]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_funcionalidadesDe] (@cod_rol numeric(18, 0))
AS
BEGIN
    SELECT rf.fun_rol_codigo, f.fun_Codigo, f.fun_Descripcion
      FROM MEDGOOD.FuncionalidadesRol rf 
      inner join MEDGOOD.Funcionalidad f
      on f.fun_Codigo = rf.fun_fun_codigo
      and rf.fun_rol_codigo = @cod_rol
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_habilitar_rol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_habilitar_rol]
(@cod_rol numeric(18,0))
 as
 begin
      UPDATE MEDGOOD.ROL SET ROL_estado=0 WHERE ROL_CODIGO=@cod_rol
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[SP_horas_prof]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[SP_horas_prof](@user numeric(18,0),@dia datetime)
AS
BEGIN
    SELECT ISNULL(SUM(DATEDIFF(MINUTE,age_horainicio,age_horafin)*(DATEDIFF(day,age_fechainicio,age_fechafin)+1)),0) as minutos
    FROM MEDGOOD.Profesionales , MEDGOOD.Agenda
    WHERE pro_codigo_usuario=@user AND age_profesional=pro_numero AND DATEPART(week,age_fechainicio)=DATEPART(week,@dia)
END
 

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_incrementar_intentos_fallidos]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_incrementar_intentos_fallidos]
(@us_intentos numeric(18,0),
@user varchar(255),
@codigo numeric(18,0))
as
begin
      UPDATE MEDGOOD.USUARIOS
      SET USUARIOS.USU_INTENTOS_FALLIDOS=@us_intentos 
      WHERE USUARIOS.USU_USERNAME=@user
      and USUARIOS.USU_CODIGO=@codigo
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_inhabilitar_rol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
 
CREATE procedure [MEDGOOD].[sp_inhabilitar_rol]
(@cod_rol numeric(18,0))
as
begin
     update MEDGOOD.Rol set rol_Estado=1
     where rol_codigo=@cod_rol;
 
     delete from MEDGOOD.RolesUsuario
     where rol_rol_codigo=@cod_rol;
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_modif_afiliado]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_modif_afiliado](@user varchar(255), @mail varchar(255), @tel numeric(18,0), @dom varchar(255), @estadoCivil numeric(18,0),@cantHijos numeric(18,0),@plan numeric(18,0),@fecha datetime)
 AS
 BEGIN
 DECLARE @planViejo numeric(18,0)
 SET @planViejo = (SELECT afi_planmedico FROM MEDGOOD.Afiliados, MEDGOOD.Usuarios WHERE afi_codigo_username=Usu_codigo AND Usu_username=@user)
IF (@planViejo!=@plan)
BEGIN
INSERT INTO Historial (his_codigoplan_nuevo,his_codigoplan_viejo,his_numeroafiliado,his_obs)
VALUES (@plan,@planViejo,(SELECT afi_numeroafiliado FROM MEDGOOD.Afiliados, MEDGOOD.Usuarios WHERE afi_codigo_username=Usu_codigo AND Usu_username=@user),'CAMBIO DE PLAN')
END
 UPDATE MEDGOOD.Usuarios
 SET Usu_mail=@mail,Usu_telefono=@tel,Usu_direccion=@dom, Usu_fecha_ultima_modificacion=@fecha
 WHERE Usu_username=@user
 UPDATE MEDGOOD.Afiliados
 SET afi_estadocivil=@estadoCivil,afi_cantidadhijos=@cantHijos,afi_planmedico=@plan
 FROM MEDGOOD.Afiliados, MEDGOOD.Usuarios
 WHERE afi_codigo_username=Usu_codigo AND Usu_username=@user
 END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_obtener_afiliados]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_obtener_afiliados]
as
begin
      select U.Usu_codigo,A.afi_numeroafiliado,A.afi_codigoafiliado,
             U.Usu_nombre,U.Usu_apellido,U.Usu_nrodocumento,P.pla_codigo,
             p.pla_descripcion,p.pla_bono_consulta
                
      from
      MEDGOOD.Afiliados A,
      MEDGOOD.Usuarios U,
      MEDGOOD.Planes p
      where A.afi_codigo_username=u.Usu_codigo
      and p.pla_codigo=a.afi_planmedico
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_obtener_horario]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_obtener_horario](@pro numeric(18,0),@fecha datetime)
    AS
    BEGIN
        SELECT age_horainicio, age_horafin
        FROM Agenda
        WHERE (@fecha BETWEEN age_fechainicio AND age_fechafin) AND age_profesional=@pro
    END

GO
/****** Object:  StoredProcedure [MEDGOOD].[Sp_ObtenerEstadisticas]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[Sp_ObtenerEstadisticas] 
(    @Anio INT
    ,@Semestre INT
    ,@TipoListado INT
    ,@TipoUsuario INT
    --1 para afiliado, 2 para profesional, 3 para todos
    ,@TipoPlan INT
    ,@Especialidad INT)
    --555555,555556,555557,555558,555559
AS
BEGIN
    DECLARE @MesInicio INT
        ,   @MesFin INT
 
    IF (@Semestre = 1)
    BEGIN
        SET @MesInicio = 1
        SET @MesFin = 6
    END
    IF (@Semestre = 2)
    BEGIN
        SET @MesInicio = 7
        SET @MesFin = 12
    END
 
IF (@TipoListado = 1)
    BEGIN
    IF (@TipoUsuario=1)
        BEGIN
            SELECT TOP 5 (SELECT esp_descripcion FROM MEDGOOD.Especialidad WHERE esp_codigo=tur_especialidad) as especialidad
            ,COUNT(*) as cantidad
            FROM MEDGOOD.Turno T
            WHERE tur_estado=3 AND
            tur_cancelador IN (SELECT afi_codigo_username FROM MEDGOOD.Afiliados) AND
            (YEAR(T.tur_fecha) = @Anio) AND
            (month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
            GROUP BY tur_especialidad
            ORDER BY COUNT(*) DESC
    END
    IF (@TipoUsuario=2)
        BEGIN
            SELECT TOP 5 (SELECT esp_descripcion FROM MEDGOOD.Especialidad WHERE esp_codigo=tur_especialidad) as especialidad
            ,COUNT(*) as cantidad
            FROM MEDGOOD.Turno T
            WHERE tur_estado=3 AND
            tur_cancelador IN (SELECT pro_codigo_usuario FROM MEDGOOD.Profesionales) AND
            (YEAR(T.tur_fecha) = @Anio) AND
            (month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
            GROUP BY tur_especialidad
            ORDER BY COUNT(*) DESC
    END
    IF (@TipoUsuario=3)
        BEGIN
            SELECT TOP 5 (SELECT esp_descripcion FROM MEDGOOD.Especialidad WHERE esp_codigo=tur_especialidad) as especialidad
            ,COUNT(*) as cantidad
            FROM MEDGOOD.Turno T
            WHERE tur_estado=3 AND
            (YEAR(T.tur_fecha) = @Anio) AND
            (month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
            GROUP BY tur_especialidad
            ORDER BY COUNT(*) DESC
    END
END
  
 IF (@TipoListado = 2)
    BEGIN
    SELECT TOP 5 (SELECT (Usu_nombre + ' ' + Usu_apellido) FROM MEDGOOD.Usuarios WHERE Usu_codigo=
    (SELECT pro_codigo_usuario FROM MEDGOOD.Profesionales WHERE pro_numero=tur_profesionalcodigo)) as profesional,
    (SELECT pla_descripcion FROM MEDGOOD.Planes WHERE pla_codigo=bon_codigoplan) as "plan",
    (SELECT esp_descripcion FROM MEDGOOD.Especialidad WHERE esp_codigo=tur_especialidad) as especialidad,
    COUNT(*) as cantidad FROM MEDGOOD.Consulta
    INNER JOIN MEDGOOD.Bono ON bon_codigo=con_bonocodigo
    INNER JOIN MEDGOOD.Turno T ON tur_codigo=con_tur_numero
    WHERE bon_codigoplan=@TipoPlan AND
    (YEAR(T.tur_fecha) = @Anio) AND
    (month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
    GROUP BY tur_profesionalcodigo,bon_codigoplan,tur_especialidad
    ORDER BY COUNT(*) DESC;
END
 
IF (@TipoListado = 3)
    BEGIN
 
Select
 
(Select  U.Usu_nombre from MEDGOOD.Usuarios U where U.Usu_codigo= K.pro_codigo_usuario) As 'Médico Nombre'
,(Select  U.Usu_apellido from MEDGOOD.Usuarios U where U.Usu_codigo= K.pro_codigo_usuario) As 'Médico Apellido'
,(select E.esp_descripcion from MEDGOOD.Especialidad E where E.esp_codigo= K.tur_especialidad) As 'Especialidad'
, K.Cantidad/2 As 'Cantidad horas'
 
 
From
(
Select TOP 5
 
P.pro_codigo_usuario,T.tur_especialidad, Count (*) As 'Cantidad'
 
 from MEDGOOD.Turno T, 
 MEDGOOD.EstadoConsulta E, MEDGOOD.Profesionales P
 
Where
T.tur_estado = E.est_codigo
AND
E.est_descripcion='atendida'
AND
P.pro_numero= T.tur_profesionalcodigo
AND
T.tur_especialidad=@Especialidad
AND
(YEAR(T.tur_fecha) = @Anio)
AND
(month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
 
Group by P.pro_codigo_usuario,T.tur_especialidad
 
Order by Cantidad DESC ) K
 
 
     
END
 
IF (@TipoListado = 4)
    BEGIN
 
 Select
 U.Usu_nombre As ' Nombre'
,U.Usu_apellido AS ' Apellido'
,K.Bonos  AS 'CantidadBonos'
,(CASE WHEN A.afi_afiliadoprincipal is null then 'NO' Else 'SI' END) AS 'Grupo flia'
 
From
MEDGOOD.Usuarios U, MEDGOOD.Afiliados A,
(Select
TOP 5
 C.com_codigoafiliado
,SUM (C.com_cantidad) As 'Bonos'
 
From
MEDGOOD.CompraBono C
WHERE
(YEAR(C.com_fechacompra) = @Anio)
AND
(month(C.com_fechacompra) BETWEEN @MesInicio AND @MesFin)
 
 
Group BY C.com_codigoafiliado
 
Order By 2 DESC ) K
 
Where A.afi_codigo_username= U.Usu_codigo
AND
K.com_codigoafiliado= A.afi_numeroafiliado
 END
 
    IF (@TipoListado = 5)
    BEGIN
 
Select TOP 5
E.esp_descripcion AS 'Especialidad',
Count (*) AS 'Cantidad' 
 
from
MEDGOOD.Turno T, MEDGOOD.Especialidad E, MEDGOOD.Consulta C, MEDGOOD.Bono B
 
Where
T.tur_especialidad = E.esp_codigo
AND
T.tur_codigo= C.con_tur_numero
AND
C.con_bonocodigo= B.bon_codigo
AND
bon_fue_usado = '1'
AND
(YEAR(T.tur_fecha) = @Anio)
AND
(month(T.tur_fecha) BETWEEN @MesInicio AND @MesFin)
 
 
GROUP BY  E.esp_descripcion
 
ORDeR BY Cantidad DESC
 
 
END
 
END
 



GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_pagar_atencion_medica]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE  procedure [MEDGOOD].[sp_pagar_atencion_medica]
(@codBono numeric(18,0),
 @afiUsadorBono numeric(18,0),
 @fechaUsoBono Datetime,
 @numeroConsulta numeric(18,0)
 )
 as
 begin
        update MEDGOOD.Bono
        set bon_fue_usado=1,
        bon_codigoafiliado=@afiUsadorBono,
        bon_fechaimpresion=@fechaUsoBono,
        bon_nroconsultabono=@numeroConsulta
        where bon_codigo=@codBono
         
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registrar_agenda]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_registrar_agenda](@user numeric(18,0), @fechaInic datetime, @fechaFin datetime, @horInic datetime,@horFin datetime,@esp decimal(18,0))
AS
BEGIN
    INSERT INTO MEDGOOD.Agenda(age_profesional,age_fechainicio,age_fechafin,age_especialidad_codigo,age_horainicio,age_horafin)
    VALUES ((SELECT p.pro_numero FROM Profesionales p WHERE p.pro_codigo_usuario=@user),CONVERT(date, @fechaInic),CONVERT(date,@fechaFin),@esp,CONVERT(time, @horInic),CONVERT(time, @horFin))
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registrar_compra]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_registrar_compra]
(@codigo_afiliado numeric(18,0),
@com_cantidad numeric(18,0),
@com_monto_unidad numeric(18,2),
@com_fecha datetime,
@com_monto_total numeric(18,2))
as
begin
    declare @id_compra numeric(18,0)
    declare @plan_afiliado numeric(18,0)
    declare @contador numeric(18,0)
    declare @bon_codigo numeric(18,0)
    set @contador=0;
    select @plan_afiliado=afi_planmedico from MEDGOOD.Afiliados where afi_numeroafiliado=@codigo_afiliado;
    select @bon_codigo=max(bon_codigo)+1 from MEDGOOD.Bono;
    insert into MEDGOOD.CompraBono (com_codigoafiliado,com_cantidad,com_monto,com_fechacompra,com_monto_total)
    values (@codigo_afiliado,@com_cantidad,@com_monto_unidad,@com_fecha,@com_monto_total);
    set @id_compra=scope_identity();
    while(@contador < @com_cantidad)
    begin
        insert into MEDGOOD.Bono (bon_codigo,bon_codigocompra,bon_fue_usado,bon_codigoplan,bon_nroconsultabono) values
        (@bon_codigo,@id_compra,0,@plan_afiliado,0);
        set @contador=@contador+1;
        set @bon_codigo=@bon_codigo+1;
    end
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registrar_turno]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_registrar_turno](@prof numeric(18,0),@afi varchar(255),@esp varchar(255),@fecha datetime)
AS
BEGIN
DECLARE @cod numeric(18,0)
DECLARE @esp_cod numeric(18,0)
 
SET @cod = (SELECT MAX(tur_codigo) FROM Turno) + 1
SET  @esp_cod =(SELECT esp_codigo FROM MEDGOOD.Especialidad WHERE esp_descripcion=@esp)
INSERT INTO MEDGOOD.Turno 
(tur_codigo
,tur_codigoafiliado
,tur_especialidad
,tur_fecha
,tur_nro_agenda
,tur_profesionalcodigo)
VALUES
(@cod
,(SELECT afi_numeroafiliado FROM MEDGOOD.Afiliados, MEDGOOD.Usuarios WHERE afi_codigo_username=usu_codigo AND usu_username=@afi)
,@esp_cod
,@fecha
,(SELECT age_codigo FROM MEDGOOD.Agenda WHERE age_profesional=@prof AND @esp_cod=age_especialidad_codigo AND (@fecha BETWEEN age_fechainicio AND age_fechafin))
,@prof)
 
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registrarLlegada_turno]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_registrarLlegada_turno]
(@codTurno numeric(18,0))
as
begin
      UPDATE MEDGOOD.Turno
      SET tur_estado=(select est_codigo 
                      from MEDGOOD.EstadoConsulta 
                      where est_descripcion='Registrada')
    where tur_codigo=@codTurno
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registro_atencionMedica]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_registro_atencionMedica]
(@codTurno numeric(18,0))
as
begin
      update MEDGOOD.Turno
      set tur_estado=
      (select est_codigo from MEDGOOD.EstadoConsulta where est_descripcion='Atendida')
      where tur_codigo=@codTurno
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registroLlegada_Afiliado]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
  CREATE procedure [MEDGOOD].[sp_registroLlegada_Afiliado]
  (@turno numeric(18,0),
  @bono numeric(18,0),
  @fechaLlegadaAfiliado Datetime)
  as
  begin
        insert into MEDGOOD.Consulta
        (con_tur_numero,con_bonocodigo,con_fechallegada_afiliado)
        values
        (@turno,@bono,@fechaLlegadaAfiliado)
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_registroResultados_consulta]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure  [MEDGOOD].[sp_registroResultados_consulta]
 (@codConsulta numeric(18,0),
 @diagnostico varchar(255),
 @enfermedad varchar(255),
@sintomas varchar(255),
@fechaAtencion Datetime,
@comentarios varchar(255))
as
begin
      UPDATE MEDGOOD.Consulta
       set con_diagnostico=@diagnostico
      ,con_enfermedad=@enfermedad
      ,con_comentarios=@comentarios
      ,con_sintomas=@sintomas
      ,con_fechalatencio_medica=@fechaAtencion
  where con_codigo=@codConsulta
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_reiniciar_fallidos]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_reiniciar_fallidos]
(@username varchar(255),
@codigo numeric(18,0))
as
begin
      UPDATE MEDGOOD.USUARIOS  
      SET USUARIOS.USU_INTENTOS_FALLIDOS=0 
      WHERE USUARIOS.USU_USERNAME=@username
      AND USUARIOS.USU_CODIGO=@codigo
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_rolesDe]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_rolesDe] (@userId numeric(18, 0))
AS
BEGIN
    SELECT ru.rol_usu_codigo, r.rol_codigo, r.rol_descripcion, r.rol_Estado
      FROM MEDGOOD.RolesUsuario ru 
      inner join MEDGOOD.Rol r
      on r.rol_codigo = ru.rol_rol_codigo
      and r.rol_Estado = 0 
      and ru.rol_usu_codigo = @userId
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_tieneFuncionalidadElRol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_tieneFuncionalidadElRol]
(@codigoRol numeric(18,0),
@codigoFuncionalidad numeric(18,0))
as
begin
SELECT * FROM MEDGOOD.FUNCIONALIDADESROL 
WHERE FUN_ROL_CODIGO=@codigoRol 
AND FUN_FUN_CODIGO=@codigoFuncionalidad
end

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_turnos_del_afi]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_turnos_del_afi](@user varchar(255),@fechaActual datetime)
AS
BEGIN
 
Select 
K.tur_codigo AS 'Codigo'
,K.tur_codigoafiliado As 'Afiliado'
,K.tur_fecha AS 'Fecha'
,(Select U.Usu_nombre from MEDGOOD.Profesionales P, MEDGOOD.Usuarios U where U.Usu_codigo= P.pro_codigo_usuario AND K.tur_profesionalcodigo=P.pro_numero ) AS 'Nombre Medico'
,(Select U.Usu_apellido from MEDGOOD.Profesionales P, MEDGOOD.Usuarios U where U.Usu_codigo= P.pro_codigo_usuario AND K.tur_profesionalcodigo=P.pro_numero ) AS 'Apellido Medico'
From
 
(SELECT
DISTINCT tur_codigo,tur_codigoafiliado,tur_fecha,tur_profesionalcodigo 
FROM Turno, Afiliados,Profesionales,Usuarios 
WHERE
tur_codigoafiliado=afi_numeroafiliado 
AND afi_codigo_username=usu_codigo 
AND usu_username=@user
AND tur_estado IS NULL
AND tur_fecha > @fechaActual
) K
 
END

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_turnos_del_pro]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [MEDGOOD].[sp_turnos_del_pro](@user varchar(255),@fechaActual datetime)
AS
BEGIN
Select
K.tur_codigo AS 'Turno'
,(select U.Usu_nombre from MEDGOOD.Afiliados A, MEDGOOD.Usuarios U where U.Usu_codigo= A.afi_codigo_username AND A.afi_numeroafiliado=K.tur_codigoafiliado) AS 'Nombre Afiliado'
,(select U.Usu_apellido from MEDGOOD.Afiliados A, MEDGOOD.Usuarios U where U.Usu_codigo= A.afi_codigo_username AND A.afi_numeroafiliado=K.tur_codigoafiliado) AS 'Apellido Afiliado'
,K.tur_fecha AS 'Fecha'
,K.tur_profesionalcodigo As 'Profesional'
 
FROM
 
 
(
SELECT
DISTINCT tur_codigo,tur_codigoafiliado,tur_fecha,tur_profesionalcodigo 
FROM Turno, Profesionales,Usuarios 
WHERE tur_profesionalcodigo=pro_numero 
AND pro_codigo_usuario=usu_codigo 
AND usu_username=@user
AND tur_estado IS NULL
AND tur_fecha > @fechaActual
) K
END
 

GO
/****** Object:  StoredProcedure [MEDGOOD].[sp_validarUsuario_Turno]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE procedure [MEDGOOD].[sp_validarUsuario_Turno]
(@codTurno numeric(18,0),
@codAfiliado numeric(18,0))
as
begin
     select T.tur_codigo,T.tur_codigoafiliado
     from MEDGOOD.Turno T,MEDGOOD.Afiliados A
     where A.afi_codigoafiliado=@codAfiliado
     and A.afi_numeroafiliado=T.tur_codigoafiliado
     and T.tur_codigo=@codTurno
end

GO

GO
/****** Object:  StoredProcedure [MEDGOOD].[Sp_cargar]    Script Date: 04/11/2016 17:56:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [MEDGOOD].[Sp_cargar] 

AS 
BEGIN
--Variables para obtencion de datos en el cursor
DECLARE @Afiliado Numeric(18,0), @codigoAfiliado Numeric(18,0),@boncodigo Numeric(18,2),@aux INT;
--Declaración del cursor

DECLARE Cursor1 CURSOR DYNAMIC FOR SELECT DISTINCT BE.bon_codigoafiliado
FROM MEDGOOD.Bono BE

OPEN Cursor1
FETCH Cursor1 INTO @Afiliado
WHILE (@@FETCH_STATUS = 0 )
BEGIN

DECLARE cursor_emp CURSOR DYNAMIC FOR 
SELECT B.bon_codigo, B.bon_codigoafiliado
FROM MEDGOOD.Bono B where B.bon_codigoafiliado=@Afiliado  order by B.bon_fechaimpresion DESC

Set @aux =1

--Apertura del cursor
OPEN cursor_emp
--Primer resultado del FETCH
FETCH cursor_emp INTO @boncodigo,@codigoAfiliado
--Bucle de lectura
WHILE (@@FETCH_STATUS = 0 )
BEGIN

UPDATE
MEDGOOD.bono 
Set bon_nroconsultabono=@aux
Where (bon_codigo=@boncodigo
AND
bon_codigoafiliado=@codigoAfiliado)

SET @aux=@aux +1
--enesima iteración sobre el cursor
FETCH cursor_emp INTO @boncodigo,@codigoAfiliado
END
CLOSE cursor_emp
DEALLOCATE cursor_emp

FETCH Cursor1 INTO @Afiliado

END
--Cierre del cursor
CLOSE Cursor1
DEALLOCATE Cursor1

print 'Finalizo SP'

END

GO

GO
/****** Object:  UserDefinedFunction [MEDGOOD].[ObtenerUserName]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [MEDGOOD].[ObtenerUserName]
(
	@Nombre VARCHAR(255)
	,@Apellido VARCHAR(255)
	,@FechaNacimiento DATETIME
	,@DNI VARCHAR(255)
)
RETURNS VARCHAR(255)
AS
BEGIN

	DECLARE @Username varchar(255)
	SET @Username = (SELECT SUBSTRING(@Nombre,1,2) +SUBSTRING(@Apellido,2,4) + CONVERT(varchar(4), YEAR(@FechaNacimiento)) + SUBSTRING(@DNI,1,2) )

  RETURN  REPLACE(REPLACE(REPLACE(REPLACE (REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(@Username, 'á', 'a'), 'é','e'), 'í', 'i'), 'ó', 'o'), 'ú','u'), 'Á', 'A'),'Í','I'), 'É','E'),'Ó','O')
 
END










GO
/****** Object:  Table [MEDGOOD].[Afiliados]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Afiliados](
	[afi_numeroafiliado] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[afi_codigoafiliado] [numeric](18, 0) NULL,
	[afi_estadocivil] [numeric](18, 0) NULL,
	[afi_cantidadhijos] [numeric](18, 0) NULL,
	[afi_planmedico] [numeric](18, 0) NULL,
	[afi_codigo_username] [numeric](18, 0) NULL,
	[afi_afiliadoprincipal] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Afiliados] PRIMARY KEY CLUSTERED 
(
	[afi_numeroafiliado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[afi_codigoafiliado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Agenda]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Agenda](
	[age_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[age_profesional] [numeric](18, 0) NULL,
	[age_especialidad_codigo] [numeric](18, 0) NULL,
	[age_fechainicio] [date] NULL,
	[age_horainicio] [time](0) NULL,
	[age_fechafin] [date] NULL,
	[age_horafin] [time](0) NULL,
 CONSTRAINT [PK_Agenda] PRIMARY KEY CLUSTERED 
(
	[age_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Bono]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Bono](
	[bon_codigo] [numeric](18, 0) NOT NULL,
	[bon_codigocompra] [numeric](18, 0) NULL,
	[bon_fue_usado] [bit] NULL,
	[bon_codigoafiliado] [numeric](18, 0) NULL,
	[bon_codigoplan] [numeric](18, 0) NULL,
	[bon_fechaimpresion] [datetime] NULL,
	[bon_nroconsultabono] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Bono] PRIMARY KEY CLUSTERED 
(
	[bon_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[CancelacionTipo]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[CancelacionTipo](
	[can_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[can_descripcion] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[CompraBono]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[CompraBono](
	[com_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[com_codigoafiliado] [numeric](18, 0) NULL,
	[com_cantidad] [numeric](18, 0) NULL,
	[com_monto] [numeric](18, 2) NULL,
	[com_fechacompra] [datetime] NULL,
	[com_monto_total] [numeric](18, 2) NULL,
 CONSTRAINT [PK_CompraBono] PRIMARY KEY CLUSTERED 
(
	[com_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Consulta]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Consulta](
	[con_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[con_tur_numero] [numeric](18, 0) NULL,
	[con_bonocodigo] [numeric](18, 0) NULL,
	[con_fechallegada_afiliado] [datetime] NULL,
	[con_fechalatencio_medica] [datetime] NULL,
	[con_diagnostico] [varchar](255) NULL,
	[con_enfermedad] [varchar](255) NULL,
	[con_sintomas] [varchar](255) NULL,
	[con_comentarios] [nvarchar](255) NULL,
 CONSTRAINT [PK_Consulta] PRIMARY KEY CLUSTERED 
(
	[con_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[Especialidad]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Especialidad](
	[esp_codigo] [numeric](18, 0) NOT NULL,
	[esp_descripcion] [varchar](255) NOT NULL,
	[esp_tipo_codigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Especialidad] PRIMARY KEY CLUSTERED 
(
	[esp_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[EspecialidadTipo]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[EspecialidadTipo](
	[esp_tipo_codigo] [numeric](18, 0) NOT NULL,
	[esp_tipo_descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_EspecialidadTipo] PRIMARY KEY CLUSTERED 
(
	[esp_tipo_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[EstadoCivil]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[EstadoCivil](
	[est_civil_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[est_civil_descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_EstadoCivil] PRIMARY KEY CLUSTERED 
(
	[est_civil_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[EstadoConsulta]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[EstadoConsulta](
	[est_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[est_descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_EstadoConsulta] PRIMARY KEY CLUSTERED 
(
	[est_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[Funcionalidad]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Funcionalidad](
	[fun_Codigo] [numeric](18, 0) NOT NULL,
	[fun_Descripcion] [varchar](250) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[fun_Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[FuncionalidadesRol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[FuncionalidadesRol](
	[fun_rol_codigo] [numeric](18, 0) NOT NULL,
	[fun_fun_codigo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [pk_FuncionaliadesRol] PRIMARY KEY CLUSTERED 
(
	[fun_rol_codigo] ASC,
	[fun_fun_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Historial]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Historial](
	[his_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[his_numeroafiliado] [numeric](18, 0) NULL,
	[his_codigoplan_viejo] [numeric](18, 0) NULL,
	[his_codigoplan_nuevo] [numeric](18, 0) NULL,
	[his_obs] [nvarchar](255) NULL,
 CONSTRAINT [PK_Historial] PRIMARY KEY CLUSTERED 
(
	[his_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Planes]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Planes](
	[pla_codigo] [numeric](18, 0) NOT NULL,
	[pla_descripcion] [nvarchar](255) NULL,
	[pla_bono_consulta] [numeric](18, 0) NULL,
	[pla_bono_farmacia] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Planp] PRIMARY KEY CLUSTERED 
(
	[pla_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Profesionales]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[Profesionales](
	[pro_numero] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[pro_matricula] [numeric](18, 0) NULL,
	[pro_observaciones] [nvarchar](255) NULL,
	[pro_codigo_usuario] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Profesionales] PRIMARY KEY CLUSTERED 
(
	[pro_numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[ProfporEspecialidad]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[ProfporEspecialidad](
	[pro_numero] [numeric](18, 0) NOT NULL,
	[esp_codigo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [pk_profporespecialidad] PRIMARY KEY CLUSTERED 
(
	[pro_numero] ASC,
	[esp_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[Rol]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Rol](
	[rol_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[rol_descripcion] [varchar](250) NULL,
	[rol_Estado] [bit] NULL,
	[Rol_Es_Administrador] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[rol_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[RolesUsuario]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [MEDGOOD].[RolesUsuario](
	[rol_usu_codigo] [numeric](18, 0) NOT NULL,
	[rol_rol_codigo] [numeric](18, 0) NOT NULL,
 CONSTRAINT [pk_RolesUsuario] PRIMARY KEY CLUSTERED 
(
	[rol_usu_codigo] ASC,
	[rol_rol_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [MEDGOOD].[TipoDocumento]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[TipoDocumento](
	[tip_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[tip_descripcion] [varchar](255) NULL,
 CONSTRAINT [PK_TipoDocumento] PRIMARY KEY CLUSTERED 
(
	[tip_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[Turno]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Turno](
	[tur_codigo] [numeric](18, 0) NOT NULL,
	[tur_codigoafiliado] [numeric](18, 0) NULL,
	[tur_fecha] [datetime] NULL,
	[tur_profesionalcodigo] [numeric](18, 0) NULL,
	[tur_especialidad] [numeric](18, 0) NULL,
	[tur_nro_agenda] [numeric](18, 0) NULL,
	[tur_estado] [numeric](18, 0) NULL,
	[tur_cancelador] [numeric](18, 0) NULL,
	[tur_motivo_cancelacion] [numeric](18, 0) NULL,
	[tur_comentarios] [varchar](255) NULL,
 CONSTRAINT [PK_Turno] PRIMARY KEY CLUSTERED 
(
	[tur_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [MEDGOOD].[Usuarios]    Script Date: 25/11/2016 17:13:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [MEDGOOD].[Usuarios](
	[Usu_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Usu_username] [varchar](255) NOT NULL,
	[Usu_password] [varchar](255) NULL,
	[Usu_fechacreacion] [datetime] NULL,
	[Usu_fecha_ultima_modificacion] [datetime] NULL,
	[Usu_pregunta_secreta] [varchar](255) NULL,
	[Usu_respuesta_secreta] [varchar](255) NULL,
	[Usu_intentos_fallidos] [numeric](18, 0) NULL,
	[Usu_inhabilitado] [bit] NULL,
	[Usu_nombre] [varchar](255) NULL,
	[Usu_apellido] [varchar](255) NULL,
	[Usu_nrodocumento] [numeric](18, 0) NULL,
	[Usu_direccion] [varchar](255) NULL,
	[Usu_telefono] [numeric](18, 0) NULL,
	[Usu_mail] [varchar](255) NULL,
	[Usu_fechanacimiento] [datetime] NULL,
	[Usu_sexo] [bit] NULL,
	[Usu_tipodocumento] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[Usu_codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UQ_Usuario_username] UNIQUE NONCLUSTERED 
(
	[Usu_username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [MEDGOOD].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_afi_estadocivil] FOREIGN KEY([afi_estadocivil])
REFERENCES [MEDGOOD].[EstadoCivil] ([est_civil_codigo])
GO
ALTER TABLE [MEDGOOD].[Afiliados] CHECK CONSTRAINT [FK_afi_estadocivil]
GO
ALTER TABLE [MEDGOOD].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_afi_planmedico] FOREIGN KEY([afi_planmedico])
REFERENCES [MEDGOOD].[Planes] ([pla_codigo])
GO
ALTER TABLE [MEDGOOD].[Afiliados] CHECK CONSTRAINT [FK_afi_planmedico]
GO
ALTER TABLE [MEDGOOD].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_principal] FOREIGN KEY([afi_afiliadoprincipal])
REFERENCES [MEDGOOD].[Afiliados] ([afi_numeroafiliado])
GO
ALTER TABLE [MEDGOOD].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_principal]
GO
ALTER TABLE [MEDGOOD].[Afiliados]  WITH CHECK ADD  CONSTRAINT [FK_Afiliados_user] FOREIGN KEY([afi_codigo_username])
REFERENCES [MEDGOOD].[Usuarios] ([Usu_codigo])
GO
ALTER TABLE [MEDGOOD].[Afiliados] CHECK CONSTRAINT [FK_Afiliados_user]
GO
ALTER TABLE [MEDGOOD].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_especialidad] FOREIGN KEY([age_especialidad_codigo])
REFERENCES [MEDGOOD].[Especialidad] ([esp_codigo])
GO
ALTER TABLE [MEDGOOD].[Agenda] CHECK CONSTRAINT [FK_Agenda_especialidad]
GO
ALTER TABLE [MEDGOOD].[Agenda]  WITH CHECK ADD  CONSTRAINT [FK_Agenda_profesional] FOREIGN KEY([age_profesional])
REFERENCES [MEDGOOD].[Profesionales] ([pro_numero])
GO
ALTER TABLE [MEDGOOD].[Agenda] CHECK CONSTRAINT [FK_Agenda_profesional]
GO
ALTER TABLE [MEDGOOD].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_afi] FOREIGN KEY([bon_codigoafiliado])
REFERENCES [MEDGOOD].[Afiliados] ([afi_numeroafiliado])
GO
ALTER TABLE [MEDGOOD].[Bono] CHECK CONSTRAINT [FK_Bono_afi]
GO
ALTER TABLE [MEDGOOD].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_compra] FOREIGN KEY([bon_codigocompra])
REFERENCES [MEDGOOD].[CompraBono] ([com_codigo])
GO
ALTER TABLE [MEDGOOD].[Bono] CHECK CONSTRAINT [FK_Bono_compra]
GO
ALTER TABLE [MEDGOOD].[Bono]  WITH CHECK ADD  CONSTRAINT [FK_Bono_plan] FOREIGN KEY([bon_codigoplan])
REFERENCES [MEDGOOD].[Planes] ([pla_codigo])
GO
ALTER TABLE [MEDGOOD].[Bono] CHECK CONSTRAINT [FK_Bono_plan]
GO
ALTER TABLE [MEDGOOD].[CompraBono]  WITH CHECK ADD  CONSTRAINT [FK_CompraBono_afiliado] FOREIGN KEY([com_codigoafiliado])
REFERENCES [MEDGOOD].[Afiliados] ([afi_numeroafiliado])
GO
ALTER TABLE [MEDGOOD].[CompraBono] CHECK CONSTRAINT [FK_CompraBono_afiliado]
GO
ALTER TABLE [MEDGOOD].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_bonoco] FOREIGN KEY([con_bonocodigo])
REFERENCES [MEDGOOD].[Bono] ([bon_codigo])
GO
ALTER TABLE [MEDGOOD].[Consulta] CHECK CONSTRAINT [FK_Consulta_bonoco]
GO
ALTER TABLE [MEDGOOD].[Consulta]  WITH CHECK ADD  CONSTRAINT [FK_Consulta_t] FOREIGN KEY([con_tur_numero])
REFERENCES [MEDGOOD].[Turno] ([tur_codigo])
GO
ALTER TABLE [MEDGOOD].[Consulta] CHECK CONSTRAINT [FK_Consulta_t]
GO
ALTER TABLE [MEDGOOD].[Especialidad]  WITH CHECK ADD  CONSTRAINT [FK_Especialidad_tipo] FOREIGN KEY([esp_tipo_codigo])
REFERENCES [MEDGOOD].[EspecialidadTipo] ([esp_tipo_codigo])
GO
ALTER TABLE [MEDGOOD].[Especialidad] CHECK CONSTRAINT [FK_Especialidad_tipo]
GO
ALTER TABLE [MEDGOOD].[FuncionalidadesRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesRol_Funcio] FOREIGN KEY([fun_fun_codigo])
REFERENCES [MEDGOOD].[Funcionalidad] ([fun_Codigo])
GO
ALTER TABLE [MEDGOOD].[FuncionalidadesRol] CHECK CONSTRAINT [FK_FuncionalidadesRol_Funcio]
GO
ALTER TABLE [MEDGOOD].[FuncionalidadesRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadesRol_profe] FOREIGN KEY([fun_rol_codigo])
REFERENCES [MEDGOOD].[Rol] ([rol_codigo])
GO
ALTER TABLE [MEDGOOD].[FuncionalidadesRol] CHECK CONSTRAINT [FK_FuncionalidadesRol_profe]
GO
ALTER TABLE [MEDGOOD].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_afi] FOREIGN KEY([his_numeroafiliado])
REFERENCES [MEDGOOD].[Afiliados] ([afi_numeroafiliado])
GO
ALTER TABLE [MEDGOOD].[Historial] CHECK CONSTRAINT [FK_Historial_afi]
GO
ALTER TABLE [MEDGOOD].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_plan1] FOREIGN KEY([his_codigoplan_nuevo])
REFERENCES [MEDGOOD].[Planes] ([pla_codigo])
GO
ALTER TABLE [MEDGOOD].[Historial] CHECK CONSTRAINT [FK_Historial_plan1]
GO
ALTER TABLE [MEDGOOD].[Historial]  WITH CHECK ADD  CONSTRAINT [FK_Historial_plan2] FOREIGN KEY([his_codigoplan_viejo])
REFERENCES [MEDGOOD].[Planes] ([pla_codigo])
GO
ALTER TABLE [MEDGOOD].[Historial] CHECK CONSTRAINT [FK_Historial_plan2]
GO
ALTER TABLE [MEDGOOD].[Profesionales]  WITH CHECK ADD  CONSTRAINT [FK_Profesionales_usuario] FOREIGN KEY([pro_codigo_usuario])
REFERENCES [MEDGOOD].[Usuarios] ([Usu_codigo])
GO
ALTER TABLE [MEDGOOD].[Profesionales] CHECK CONSTRAINT [FK_Profesionales_usuario]
GO
ALTER TABLE [MEDGOOD].[ProfporEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfporEspecialidad_Espec] FOREIGN KEY([esp_codigo])
REFERENCES [MEDGOOD].[Especialidad] ([esp_codigo])
GO
ALTER TABLE [MEDGOOD].[ProfporEspecialidad] CHECK CONSTRAINT [FK_ProfporEspecialidad_Espec]
GO
ALTER TABLE [MEDGOOD].[ProfporEspecialidad]  WITH CHECK ADD  CONSTRAINT [FK_ProfporEspecialidad_Prof] FOREIGN KEY([pro_numero])
REFERENCES [MEDGOOD].[Profesionales] ([pro_numero])
GO
ALTER TABLE [MEDGOOD].[ProfporEspecialidad] CHECK CONSTRAINT [FK_ProfporEspecialidad_Prof]
GO
ALTER TABLE [MEDGOOD].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuario_Role] FOREIGN KEY([rol_rol_codigo])
REFERENCES [MEDGOOD].[Rol] ([rol_codigo])
GO
ALTER TABLE [MEDGOOD].[RolesUsuario] CHECK CONSTRAINT [FK_RolesUsuario_Role]
GO
ALTER TABLE [MEDGOOD].[RolesUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolesUsuario_RolesU] FOREIGN KEY([rol_usu_codigo])
REFERENCES [MEDGOOD].[Usuarios] ([Usu_codigo])
GO
ALTER TABLE [MEDGOOD].[RolesUsuario] CHECK CONSTRAINT [FK_RolesUsuario_RolesU]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_afi] FOREIGN KEY([tur_codigoafiliado])
REFERENCES [MEDGOOD].[Afiliados] ([afi_numeroafiliado])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_afi]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_agenda] FOREIGN KEY([tur_nro_agenda])
REFERENCES [MEDGOOD].[Agenda] ([age_codigo])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_agenda]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_cancelador] FOREIGN KEY([tur_cancelador])
REFERENCES [MEDGOOD].[Usuarios] ([Usu_codigo])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_cancelador]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_espe] FOREIGN KEY([tur_especialidad])
REFERENCES [MEDGOOD].[Especialidad] ([esp_codigo])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_espe]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_estado] FOREIGN KEY([tur_estado])
REFERENCES [MEDGOOD].[EstadoConsulta] ([est_codigo])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_estado]
GO
ALTER TABLE [MEDGOOD].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_prof] FOREIGN KEY([tur_profesionalcodigo])
REFERENCES [MEDGOOD].[Profesionales] ([pro_numero])
GO
ALTER TABLE [MEDGOOD].[Turno] CHECK CONSTRAINT [FK_Turno_prof]
GO
ALTER TABLE [MEDGOOD].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_tiop] FOREIGN KEY([Usu_tipodocumento])
REFERENCES [MEDGOOD].[TipoDocumento] ([tip_codigo])
GO
ALTER TABLE [MEDGOOD].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_tiop]
GO
GO



print 'Creación de tablas y constraints'


GO

INSERT [MEDGOOD].[TipoDocumento] 
(tip_descripcion)

Select 'DNI'
GO

INSERT [MEDGOOD].[TipoDocumento] 
(tip_descripcion)

Select 'Passporte'

GO

print 'Migro TipoDocumento'

GO


DECLARE @fecha DATETIME

SET @fecha = GETDATE()

INSERT MEDGOOD.Usuarios
SELECT DISTINCT MEDGOOD.ObtenerUserName(M.Paciente_Nombre, M.Paciente_Apellido, M.Paciente_Fecha_Nac, M.Paciente_Dni)
  ,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'
  ,@fecha
  ,NULL
  ,''
  ,''
  ,0
  ,0
  ,M.Paciente_Nombre
  ,M.Paciente_Apellido
  ,M.Paciente_Dni
  ,M.Paciente_Direccion
  ,M.Paciente_Telefono
  ,M.Paciente_Mail
  ,M.Paciente_Fecha_Nac
  ,NULL
  ,(select T.tip_codigo from MEDGOOD.Tipodocumento T where T.tip_descripcion='DNI')

FROM GD2C2016.gd_esquema.Maestra M
Where M.Paciente_Nombre is not null
GO

GO

DECLARE @fecha DATETIME

SET @fecha = GETDATE()

INSERT MEDGOOD.Usuarios
SELECT DISTINCT MEDGOOD.ObtenerUserName(M.Medico_Nombre,M.Medico_Apellido, M.Medico_Fecha_Nac, M.Medico_Dni)
  ,'03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4'
  ,@fecha
  ,NULL
  ,''
  ,''
  ,0
  ,0
  ,M.Medico_Nombre
  ,M.Medico_Apellido
  ,M.Medico_Dni
  ,M.Medico_Direccion
  ,M.Medico_Telefono
  ,M.Medico_Mail
  ,M.Medico_Fecha_Nac
  ,NULL
  ,(select T.tip_codigo from MEDGOOD.Tipodocumento T where T.tip_descripcion='DNI')
FROM GD2C2016.gd_esquema.Maestra M
Where M.Medico_Dni is not null


GO


DECLARE @fecha DATETIME

SET @fecha = GETDATE()

INSERT MEDGOOD.Usuarios
    SELECT 'Admin'
  ,'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7'
  ,@fecha
  ,NULL
  ,''
  ,''
  ,0
  ,0
  ,'admin'
  ,'admin'
  ,'999999999'
  ,'NA'
  ,'999999999'
  ,'admin@admin.com'
  ,@fecha
  ,NULL
  ,(select T.tip_codigo from MEDGOOD.Tipodocumento T where T.tip_descripcion='DNI')

GO

GO

INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(1 AS NUMERIC(18, 0))
  ,N'ABM de Roles'
  )
GO

INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(2 AS NUMERIC(18, 0))
  ,N'ABM de Afiliados'
  )
GO

INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(3 AS NUMERIC(18, 0))
  ,N'ABM de Profesionales'
  )
GO

INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(4 AS NUMERIC(18, 0))
  ,N'ABM Especialidades Medicas'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(5 AS NUMERIC(18, 0))
  ,N'ABM Planes'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(6 AS NUMERIC(18, 0))
  ,N'Registrar Agenda'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(7 AS NUMERIC(18, 0))
  ,N'Comprar Bonos'
  )
GO

INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(8 AS NUMERIC(18, 0))
  ,N'Pedir Turno'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(9 AS NUMERIC(18, 0))
  ,N'Registro de llegada atencion medica'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(10 AS NUMERIC(18, 0))
  ,N'Registro Resultado atencion medica'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(11 AS NUMERIC(18, 0))
  ,N'Cancelar atencion medica'
  )
GO
INSERT [MEDGOOD].[Funcionalidad] (
  [fun_Codigo]
  ,[fun_Descripcion]
  )
VALUES (
  CAST(12 AS NUMERIC(18, 0))
  ,N'Listado Estadistico'
  )
GO


GO
INSERT [MEDGOOD].[Rol] 
SELECT 
   'Administrador General'
  ,0
  ,1
  
GO

INSERT [MEDGOOD].[Rol] 
  SELECT
   'Afiliado'
  ,0
  ,0
  
GO

INSERT [MEDGOOD].[Rol] 
  SELECT
   'Profesional'
  ,0
  ,0
  
GO

GO

INSERT [MEDGOOD].Planes
     (pla_codigo
     ,pla_descripcion
   ,pla_bono_consulta
   ,pla_bono_farmacia )
  
SELECT 
DISTINCT Plan_Med_Codigo, 
Plan_Med_Descripcion, 
Plan_Med_Precio_Bono_Consulta, 
Plan_Med_Precio_Bono_Farmacia 
from  gd_esquema.Maestra
ORDER BY Plan_Med_Codigo ASC

GO


GO

INSERT [MEDGOOD].[EstadoCivil] 
SELECT 
   'Soltero/a'  
GO
INSERT [MEDGOOD].[EstadoCivil] 
SELECT 
   'Casado/a' 
GO
INSERT [MEDGOOD].[EstadoCivil] 
SELECT 
   'Viudo/a'  
GO
INSERT [MEDGOOD].[EstadoCivil] 
SELECT 
   'Concubinado'  
GO
INSERT [MEDGOOD].[EstadoCivil] 
SELECT 
   'Divorciado' 
GO



GO



INSERT [MEDGOOD].EspecialidadTipo
     (esp_tipo_codigo
     ,esp_tipo_descripcion)
  
SELECT 
DISTINCT M.Tipo_Especialidad_Codigo, 
M.Tipo_Especialidad_Descripcion
FROM
gd_esquema.Maestra M
WHERE  M.Tipo_Especialidad_Codigo is not null
ORDER BY M.Tipo_Especialidad_Codigo ASC


GO

INSERT [MEDGOOD].Especialidad
     (esp_codigo
     ,esp_descripcion
    ,esp_tipo_codigo)
  
SELECT 
DISTINCT M.Especialidad_Codigo, 
M.Especialidad_Descripcion,
M.Tipo_Especialidad_Codigo
FROM
gd_esquema.Maestra M
WHERE M.Especialidad_Codigo is not null
ORDER BY M.Especialidad_Codigo ASC

GO


GO

INSERT [MEDGOOD].[EstadoConsulta] 
SELECT 
   'Registrada' 
GO
GO
INSERT [MEDGOOD].[Estadoconsulta] 
SELECT 
   'Atendida' 
GO
INSERT [MEDGOOD].[Estadoconsulta] 
SELECT 
   'Cancelada'  
GO


GO


INSERT INTO MEDGOOD.Profesionales
   SELECT 
   0
  ,NULL
  ,U.Usu_codigo
   
 From (select DISTINCT U.Usu_codigo  from  MEDGOOD.Usuarios U, gd_esquema.Maestra M
 Where U.Usu_nrodocumento= M.Medico_Dni) U
GO



INSERT MEDGOOD.FuncionalidadesRol
SELECT 1
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo BETWEEN 1 AND 5

GO


INSERT MEDGOOD.FuncionalidadesRol
SELECT 1
    ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo = 7 

GO

GO


INSERT MEDGOOD.FuncionalidadesRol
SELECT 1
    ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo = 9

GO


INSERT MEDGOOD.FuncionalidadesRol
SELECT 1
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo = 12

GO

INSERT MEDGOOD.FuncionalidadesRol
SELECT 2
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo BETWEEN 7 AND 8
GO
INSERT MEDGOOD.FuncionalidadesRol
SELECT 2
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo =11


GO
INSERT MEDGOOD.FuncionalidadesRol
SELECT 3
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo =6

GO

INSERT MEDGOOD.FuncionalidadesRol
SELECT 3
  ,fun_codigo
FROM MEDGOOD.Funcionalidad
WHERE fun_codigo BETWEEN 10 AND 11


GO

INSERT MEDGOOD.ProfporEspecialidad

SELECT 
DISTINCT P.pro_numero,
M.Especialidad_Codigo
from 
MEDGOOD.Profesionales P, 
gd_esquema.Maestra M, 
MEDGOOD.Usuarios U
Where P.pro_codigo_usuario= U.Usu_codigo
AND
U.Usu_nrodocumento= M.Medico_Dni
AND
M.Medico_Dni Is not null
AND
M.Especialidad_Codigo is not null
ORDER BY P.pro_numero ASC


GO


INSERT MEDGOOD.Afiliados
    SELECT
  ( (P.Usu_codigo*100) +1 ) 
  ,NULL
  ,0
  ,P.Plan_Med_Codigo
  ,P.Usu_codigo
  ,NULL
  
From 
(select DISTINCT  M.Plan_Med_Codigo, U.Usu_codigo from  gd_esquema.Maestra M, MEDGOOD.Usuarios U
where
U.Usu_nrodocumento= M.Paciente_Dni
AND
M.Paciente_Dni is not null
 ) P

 order by 1 ASC




GO


 GO

 INSERT [MEDGOOD].Turno
     (tur_codigo
     ,tur_codigoafiliado
    ,tur_fecha
    ,tur_profesionalcodigo
    ,tur_especialidad
    ,tur_estado
    ,tur_motivo_cancelacion
    ,tur_comentarios)
  
SELECT 
DISTINCT M.Turno_Numero
, (select A.afi_numeroafiliado from MEDGOOD.Afiliados A, MEDGOOD.Usuarios U where U.Usu_nrodocumento= M.Paciente_Dni AND U.Usu_codigo= A.afi_codigo_username)
,M.Turno_Fecha
, (select P.pro_numero from MEDGOOD.Profesionales P, MEDGOOD.Usuarios U where U.Usu_nrodocumento= M.Medico_Dni AND U.Usu_codigo= P.pro_codigo_usuario)
, M.Especialidad_Codigo
,(select C.est_codigo from MEDGOOD.EstadoConsulta C where C.est_descripcion='Atendida')
,NULL
,NULL
FROM
gd_esquema.Maestra M

where 

M.Turno_Numero is not null

GO


INSERT MEDGOOD.CompraBono
SELECT 
   X.Afiliado AS 'Afiliado'
  ,COUNT(*) AS 'Cantidad'
  ,X.Plan_Med_Precio_Bono_Consulta
  ,X.Compra_Bono_Fecha
  ,(X.Plan_Med_Precio_Bono_Consulta* Count(*))
 From
  (Select 
 DISTINCT (M.Bono_Consulta_Numero)
 ,M.Compra_Bono_Fecha
 ,M.Plan_Med_Precio_Bono_Consulta
 ,(Select A.afi_numeroafiliado from MEDGOOD.Usuarios U, MEDGOOD.Afiliados A where U.Usu_nrodocumento= M.Paciente_Dni AND U.Usu_codigo= A.afi_codigo_username) AS 'Afiliado'
 
  from  gd_esquema.Maestra M

 where M.Compra_Bono_Fecha is not null) X

 GROUP BY X.Afiliado,X.Plan_Med_Precio_Bono_Consulta,  X.Compra_Bono_Fecha

GO


 
INSERT MEDGOOD.Bono
 select 
 X.nroBono
 ,X.nroCompra
 ,1
 ,X.Comprador
 ,X.Planmedico
 ,X.Fecha
 ,0
from 

(select  
M.Bono_Consulta_Numero AS 'nroBono'
,C.com_codigo AS 'nroCompra'
, C.com_codigoafiliado AS 'Comprador'
, M.Plan_Med_Codigo AS 'Planmedico'
,M.Bono_Consulta_Fecha_Impresion AS 'Fecha' from gd_esquema.Maestra M, MEDGOOD.Afiliados A, MEDGOOD.CompraBono C, MEDGOOD.Usuarios U
 where
  U.Usu_nrodocumento=M.Paciente_Dni 
  AND 
  U.Usu_codigo= A.afi_codigo_username
  AND
  M.Compra_Bono_Fecha= C.com_fechacompra
  AND
  C.com_codigoafiliado=A.afi_numeroafiliado) X

  Order BY X.nroBono ASC

GO


INSERT MEDGOOD.RolesUsuario
SELECT U.Usu_codigo,
1

FROM MEDGOOD.Usuarios U
where U.Usu_username ='Admin'

GO
INSERT MEDGOOD.RolesUsuario
SELECT U.Usu_codigo
  ,2
FROM MEDGOOD.Usuarios U, MEDGOOD.Afiliados A
WHERE 
A.afi_codigo_username= U.Usu_codigo
AND
U.Usu_username <> 'Admin'
 GO

INSERT MEDGOOD.RolesUsuario
SELECT U.Usu_codigo
  ,3
FROM MEDGOOD.Usuarios U, MEDGOOD.Profesionales P
WHERE 
P.pro_codigo_usuario= U.Usu_codigo
AND
U.Usu_username <> 'Admin'

GO

INSERT MEDGOOD.Consulta

select 
 M.Turno_Numero
,M.Bono_Consulta_Numero
,M.Bono_Consulta_Fecha_Impresion
,M.Bono_Consulta_Fecha_Impresion
,NULL
,M.Consulta_Enfermedades
,M.Consulta_Sintomas
,NULL

from gd_esquema.Maestra M

where M.Turno_Numero is not null
AND
M.Bono_Consulta_Numero is not null

order by M.Turno_Numero ASC

Go


  INSERT [MEDGOOD].[CancelacionTipo] 
SELECT 
   'Viaje'  
GO
GO
INSERT [MEDGOOD].[CancelacionTipo] 
SELECT 
   'Fallecimiento'  
GO
INSERT [MEDGOOD].[CancelacionTipo] 
SELECT 
   'Consulta Innecesaria' 
GO

EXEC MEDGOOD.Sp_cargar
GO

DROP PROCEDURE [MEDGOOD].[Sp_cargar]
GO

GO

INSERT MEDGOOD.Agenda
    (age_profesional
     , age_especialidad_codigo
     ,age_fechainicio
     ,age_horainicio
     ,age_fechafin
     ,age_horafin)
 


Select 
K.[codigo medico]
, K.Especialidad
, CONVERT(date, MIN(K.[Fecha Inicio]) ,  110)  AS 'Fecha Inicio'
, CONVERT(char(5), MIN(K.[Fecha Inicio]) ,  108)  AS 'Hora Inicio'
, CONVERT(date, MAX(K.[Fecha Inicio]) ,  110)  AS 'Fecha Final'
, CONVERT(char(5), MAX(K.[Fecha Inicio]) ,  108)  AS 'Hora Final'

FROM
(
select 
 P.pro_numero AS 'codigo medico'
,M.Especialidad_Codigo AS 'Especialidad'
, M.Turno_Fecha AS 'Fecha Inicio'
,M.Turno_Fecha AS 'Fecha Fin'
,CONVERT(char(5), ( M.Turno_Fecha + '00:30') , 108)  AS 'Hora Fin' 

from gd_esquema.Maestra M, MEDGOOD.Profesionales P, MEDGOOD.Usuarios U

Where 
M.Medico_Dni is not null 
AND M.Turno_Fecha Is not null  
AND M.Medico_Dni= U.Usu_nrodocumento 
AND U.Usu_codigo=P.pro_codigo_usuario


GROUP BY 
M.Turno_Fecha
--, M.Turno_Numero
, M.Especialidad_Codigo, P.pro_numero

--order by P.pro_numero ASC  
) K


GROUP BY K.[codigo medico], K.Especialidad
ORDER BY K.[codigo medico]



GO


 UPDATE MEDGOOD.Turno 
  SET tur_nro_agenda = (select A.age_codigo From  MEDGOOD.Agenda A
  WHERE tur_profesionalcodigo= A.age_profesional
  AND tur_especialidad= A.age_especialidad_codigo)


GO
print 'FIN DE LA MIGRACION'
