﻿using System;
using System.Collections.Generic;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones.Domicilio;
using KiiniNet.Entities.Cat.Mascaras;
using KiiniNet.Entities.Cat.Sistema;
using KinniNet.Core.Cat;

namespace KiiniNet.Services.Cat
{
    public class ServiceCatalogosSistema : IServiceCatalogosSistema
    {
        public List<TipoUsuario> ObtenerTiposUsuario(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposUsuario(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoTelefono> ObtenerTiposTelefono(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposTelefono(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Colonia> ObtenerColoniasCp(int cp, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerColoniasCp(cp, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Rol> ObtenerRoles(int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerRoles(idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoGrupo> ObtenerTiposGruposByRol(int idrol, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposGruposByRol(idrol, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoGrupo> ObtenerTiposGrupo(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposGrupo(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoCampoMascara> ObtenerTipoCampoMascara(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTipoCampoMascara(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoCampoMascara TipoCampoMascaraId(int idTipoCampo)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.TipoCampoMascaraId(idTipoCampo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Catalogos> ObtenerCatalogosMascaraCaptura(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerCatalogosMascaraCaptura(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoArbolAcceso> ObtenerTiposArbolAcceso(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposArbolAcceso(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoInfConsulta> ObtenerTipoInformacionConsulta(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTipoInformacionConsulta(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoDocumento> ObtenerTipoDocumentos(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTipoDocumentos(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoDocumento ObtenerTiposDocumentoId(int idTipoDocumento)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposDocumentoId(idTipoDocumento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TipoEncuesta> ObtenerTiposEncuesta(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTiposEncuesta(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TipoEncuesta TipoEncuestaId(int idTipoEncuesta)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.TipoEncuestaId(idTipoEncuesta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
