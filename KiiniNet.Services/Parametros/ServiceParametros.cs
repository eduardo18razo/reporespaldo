﻿using System;
using System.Collections.Generic;
using KiiniNet.Entities.Operacion.Usuarios;
using KiiniNet.Entities.Parametros;
using KinniNet.Core.Parametros;

namespace KiiniNet.Services.Parametros
{
    public class ServiceParametros : IServiceParametros
    {
        public List<ParametrosTelefonos> TelefonosObligatorios(int idTipoUsuario)
        {
            try
            {
                using (BusinessParametros negocio = new BusinessParametros())
                {
                    return negocio.TelefonosObligatorios(idTipoUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TelefonoUsuario> ObtenerTelefonosParametrosIdTipoUsuario(int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessParametros negocio = new BusinessParametros())
                {
                    return negocio.ObtenerTelefonosParametrosIdTipoUsuario(idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CorreoUsuario> ObtenerCorreosParametrosIdTipoUsuario(int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessParametros negocio = new BusinessParametros())
                {
                    return negocio.ObtenerCorreosParametrosIdTipoUsuario(idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
