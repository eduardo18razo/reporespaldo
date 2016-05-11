using System;
using System.Collections.Generic;
using KiiniNet.Entities.Cat.Arbol.Nodos;
using KiiniNet.Entities.Cat.Arbol.Organizacion;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Cat.Usuario;
using KiiniNet.Entities.Helper;
using KiiniNet.Entities.Operacion;
using KinniNet.Business.Utils;
using KinniNet.Core.Cat;

namespace KiiniNet.Services.Cat
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceCatalogos" en el código y en el archivo de configuración a la vez.
    public class ServiceCatalogosUsuario : IServiceCatalogosUsuario
    {
        public List<TipoSubGrupo> ObtenerTipoSubGrupos(int idTipoGrupo, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosSistema negocio = new BusinessCatalogosSistema())
                {
                    return negocio.ObtenerTipoSubGrupos(idTipoGrupo, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GrupoUsuario> ObtenerGruposUsuario(int idTipoGrupo, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessGrupoUsuario negocio = new BusinessCatalogosUsuario.BusinessGrupoUsuario())
                {
                    return negocio.ObtenerGruposUsuario(idTipoGrupo, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<HelperSubGurpoUsuario> ObtenerSubGruposUsuario(int idGrupoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessSubGrupoUsuario negocio = new BusinessCatalogosUsuario.BusinessSubGrupoUsuario())
                {
                    return negocio.ObtenerSubGruposUsuario(idGrupoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pais> ObtenerPais(int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerPais(idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Campus> ObtenerCampus(int idTipoUsuario, int idPais, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerCampus(idTipoUsuario, idPais, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Torre> ObtenerTorres(int idTipoUsuario, int idCampus, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerTorres(idTipoUsuario, idCampus, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Piso> ObtenerPisos(int idTipoUsuario, int idTorre, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerPisos(idTipoUsuario, idTorre, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Zona> ObtenerZonas(int idTipoUsuario, int idPiso, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerZonas(idTipoUsuario, idPiso, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SubZona> ObtenerSubZonas(int idTipoUsuario, int idZona, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerSubZonas(idTipoUsuario, idZona, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SiteRack> ObtenerSiteRacks(int idTipoUsuario, int idSubZona, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    return negocio.ObtenerSiteRacks(idTipoUsuario, idSubZona, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Holding> ObtenerHoldings(int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerHoldings(idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Compania> ObtenerCompañias(int idTipoUsuario, int idHolding, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerCompañias(idTipoUsuario, idHolding, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Direccion> ObtenerDirecciones(int idTipoUsuario, int idCompañia, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerDirecciones(idTipoUsuario, idCompañia, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SubDireccion> ObtenerSubDirecciones(int idTipoUsuario, int idDireccoin, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerSubDirecciones(idTipoUsuario, idDireccoin, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Gerencia> ObtenerGerencias(int idTipoUsuario, int idSubdireccion, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerGerencias(idTipoUsuario, idSubdireccion, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SubGerencia> ObtenerSubGerencias(int idTipoUsuario, int idGerencia, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerSubGerencias(idTipoUsuario, idGerencia, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Jefatura> ObtenerJefaturas(int idTipoUsuario, int idSubGerencia, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    return negocio.ObtenerJefaturas(idTipoUsuario, idSubGerencia, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarUbicacion(Ubicacion ubicacion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessUbicacion negocio = new BusinessCatalogosUsuario.BusinessUbicacion())
                {
                    negocio.GuardarUbicacion(ubicacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarOrganizacion(Organizacion organizacion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarOrganizacion(organizacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarHolding(Holding entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarHolding(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarCompania(Compania entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarCompania(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarDireccion(Direccion entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarDireccion(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarSubDireccion(SubDireccion entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarSubDireccion(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarGerencia(Gerencia entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarGerencia(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarSubGerencia(SubGerencia entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarSubGerencia(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarJefatura(Jefatura entidad)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessOrganizacion negocio = new BusinessCatalogosUsuario.BusinessOrganizacion())
                {
                    negocio.GuardarJefatura(entidad);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarGrupoUsuario(GrupoUsuario grupoUsuario)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessGrupoUsuario negocio = new BusinessCatalogosUsuario.BusinessGrupoUsuario())
                {
                    negocio.GuardarGrupoUsuario(grupoUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GrupoUsuario ObtenerGrupoUsuarioById(int idGrupoUsuario)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessGrupoUsuario negocio = new BusinessCatalogosUsuario.BusinessGrupoUsuario())
                {
                    return negocio.ObtenerGrupoUsuario(idGrupoUsuario);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public SubGrupoUsuario ObtenerSubGrupoUsuario(int idGrupoUsuario, int idTipoSubGrupo)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessSubGrupoUsuario negocio = new BusinessCatalogosUsuario.BusinessSubGrupoUsuario())
                {
                    return negocio.ObtenerSubGrupoUsuario(idGrupoUsuario, idTipoSubGrupo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Nivel1> ObtenerNivel1(int idTipoArbol, int idTipoUsuario, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel1(idTipoArbol, idTipoUsuario, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel2> ObtenerNivel2(int idTipoArbol, int idTipoUsuario, int idNivel1, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel2(idTipoArbol, idTipoUsuario, idNivel1, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel3> ObtenerNivel3(int idTipoArbol, int idTipoUsuario, int idNivel2, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel3(idTipoArbol, idTipoUsuario, idNivel2, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel4> ObtenerNivel4(int idTipoArbol, int idTipoUsuario, int idNivel3, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel4(idTipoArbol, idTipoUsuario, idNivel3, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel5> ObtenerNivel5(int idTipoArbol, int idTipoUsuario, int idNivel4, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel5(idTipoArbol, idTipoUsuario, idNivel4, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel6> ObtenerNivel6(int idTipoArbol, int idTipoUsuario, int idNivel5, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel6(idTipoArbol, idTipoUsuario, idNivel5, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Nivel7> ObtenerNivel7(int idTipoArbol, int idTipoUsuario, int idNivel6, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.ObtenerNivel7(idTipoArbol, idTipoUsuario, idNivel6, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EsNodoTerminal(int idTipoUsuario, int idTipoArbol, int nivel1, int? nivel2, int? nivel3, int? nivel4, int? nivel5, int? nivel6, int? nivel7)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    return negocio.EsNodoTerminal(idTipoUsuario, idTipoArbol, nivel1,  nivel2,  nivel3,  nivel4,  nivel5,  nivel6,  nivel7);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarArbol(ArbolAcceso arbol)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessArbolAcceso negocio = new BusinessCatalogosUsuario.BusinessArbolAcceso())
                {
                    negocio.GuardarArbol(arbol);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<InformacionConsulta> ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta tipoinfoConsulta, bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessInformacionConsulta negocio = new BusinessCatalogosUsuario.BusinessInformacionConsulta())
                {
                    return negocio.ObtenerInformacionConsulta(tipoinfoConsulta, insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarInformacionConsulta(InformacionConsulta informacion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessInformacionConsulta negocio = new BusinessCatalogosUsuario.BusinessInformacionConsulta())
                {
                    negocio.GuardarInformacionConsulta(informacion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SLA> ObtenerSla(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessSla negocio = new BusinessCatalogosUsuario.BusinessSla())
                {
                    return negocio.ObtenerSla(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarSla(SLA sla)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessSla negocio = new BusinessCatalogosUsuario.BusinessSla())
                {
                    negocio.Guardar(sla);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Encuesta> ObtenerEncuestas(bool insertarSeleccion)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessEncuesta negocio = new BusinessCatalogosUsuario.BusinessEncuesta())
                {
                    return negocio.ObtenerEncuestas(insertarSeleccion);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GuardarEncuesta(Encuesta encuesta)
        {
            try
            {
                using (BusinessCatalogosUsuario.BusinessEncuesta negocio = new BusinessCatalogosUsuario.BusinessEncuesta())
                {
                    negocio.GuardarEncuesta(encuesta);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
