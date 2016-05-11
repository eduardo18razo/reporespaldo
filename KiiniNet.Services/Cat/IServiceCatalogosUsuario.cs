using System.Collections.Generic;
using System.ServiceModel;
using KiiniNet.Entities.Cat.Arbol.Nodos;
using KiiniNet.Entities.Cat.Arbol.Organizacion;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Cat.Usuario;
using KiiniNet.Entities.Helper;
using KiiniNet.Entities.Operacion;
using KinniNet.Business.Utils;

namespace KiiniNet.Services.Cat
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceCatalogos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceCatalogosUsuario
    {
        [OperationContract]
        List<TipoSubGrupo> ObtenerTipoSubGrupos(int idTipoGrupo, bool insertarSeleccion);

        [OperationContract]
        List<GrupoUsuario> ObtenerGruposUsuario(int idTipoGrupo, bool insertarSeleccion);

        [OperationContract]
        List<HelperSubGurpoUsuario> ObtenerSubGruposUsuario(int idGrupoUsuario, bool insertarSeleccion);
        
        [OperationContract]
        List<Pais> ObtenerPais(int idTipoUsuario, bool insertarSeleccion);

        [OperationContract]
        List<Campus> ObtenerCampus(int idTipoUsuario, int idPais, bool insertarSeleccion);

        [OperationContract]
        List<Torre> ObtenerTorres(int idTipoUsuario, int idCampus, bool insertarSeleccion);

        [OperationContract]
        List<Piso> ObtenerPisos(int idTipoUsuario, int idTorre, bool insertarSeleccion);

        [OperationContract]
        List<Zona> ObtenerZonas(int idTipoUsuario, int idPiso, bool insertarSeleccion);

        [OperationContract]
        List<SubZona> ObtenerSubZonas(int idTipoUsuario, int idZona, bool insertarSeleccion);

        [OperationContract]
        List<SiteRack> ObtenerSiteRacks(int idTipoUsuario, int idSubZona, bool insertarSeleccion);
        [OperationContract]
        List<Holding> ObtenerHoldings(int idTipoUsuario, bool insertarSeleccion);

        [OperationContract]
        List<Compania> ObtenerCompañias(int idTipoUsuario, int idHolding, bool insertarSeleccion);

        [OperationContract]
        List<Direccion> ObtenerDirecciones(int idTipoUsuario, int idCompañia, bool insertarSeleccion);

        [OperationContract]
        List<SubDireccion> ObtenerSubDirecciones(int idTipoUsuario, int idDireccoin, bool insertarSeleccion);

        [OperationContract]
        List<Gerencia> ObtenerGerencias(int idTipoUsuario, int idSubdireccion, bool insertarSeleccion);

        [OperationContract]
        List<SubGerencia> ObtenerSubGerencias(int idTipoUsuario, int idGerencia, bool insertarSeleccion);

        [OperationContract]
        List<Jefatura> ObtenerJefaturas(int idTipoUsuario, int idSubGerencia, bool insertarSeleccion);
        
        

        [OperationContract]
        void GuardarUbicacion(Ubicacion ubicacion);

        [OperationContract]
        void GuardarOrganizacion(Organizacion organizacion);

        [OperationContract]
        void GuardarHolding(Holding entidad);

        [OperationContract]
        void GuardarCompania(Compania entidad);

        [OperationContract]
        void GuardarDireccion(Direccion entidad);

        [OperationContract]
        void GuardarSubDireccion(SubDireccion entidad);

        [OperationContract]
        void GuardarGerencia(Gerencia entidad);

        [OperationContract]
        void GuardarSubGerencia(SubGerencia entidad);

        [OperationContract]
        void GuardarJefatura(Jefatura entidad);

        [OperationContract]
        void GuardarGrupoUsuario(GrupoUsuario grupoUsuario);

        [OperationContract]
        GrupoUsuario ObtenerGrupoUsuarioById(int idGrupoUsuario);

        [OperationContract]
        SubGrupoUsuario ObtenerSubGrupoUsuario(int idGrupoUsuario, int idTipoSubGrupo);

        #region ArbolAcceso

        [OperationContract]
        List<Nivel1> ObtenerNivel1(int idTipoArbol, int idTipoUsuario,  bool insertarSeleccion);
        [OperationContract]
        List<Nivel2> ObtenerNivel2(int idTipoArbol, int idTipoUsuario,  int idNivel1, bool insertarSeleccion);
        [OperationContract]
        List<Nivel3> ObtenerNivel3(int idTipoArbol, int idTipoUsuario,  int idNivel2, bool insertarSeleccion);
        [OperationContract]
        List<Nivel4> ObtenerNivel4(int idTipoArbol, int idTipoUsuario,  int idNivel3, bool insertarSeleccion);
        [OperationContract]
        List<Nivel5> ObtenerNivel5(int idTipoArbol, int idTipoUsuario,  int idNivel4, bool insertarSeleccion);
        [OperationContract]
        List<Nivel6> ObtenerNivel6(int idTipoArbol, int idTipoUsuario,  int idNivel5, bool insertarSeleccion);
        [OperationContract]
        List<Nivel7> ObtenerNivel7(int idTipoArbol, int idTipoUsuario,  int idNivel6, bool insertarSeleccion);
        [OperationContract]
        bool EsNodoTerminal(int idTipoUsuario, int idTipoArbol, int nivel1, int? nivel2, int? nivel3, int? nivel4,int? nivel5, int? nivel6, int? nivel7);
        
        [OperationContract]
        void GuardarArbol(ArbolAcceso arbol);

        #endregion ArbolAcceso

        #region InformacionConculta

        [OperationContract]
        List<InformacionConsulta> ObtenerInformacionConsulta(BusinessVariables.EnumTiposInformacionConsulta tipoinfoConsulta, bool insertarSeleccion);
        #region Save

        [OperationContract]
        void GuardarInformacionConsulta(InformacionConsulta informacion);

        #endregion Save

        #endregion InformacionConculta

        [OperationContract]
        List<SLA> ObtenerSla(bool insertarSeleccion);

        [OperationContract]
        void GuardarSla(SLA sla);

        [OperationContract]
        List<Encuesta> ObtenerEncuestas(bool insertarSeleccion);
        [OperationContract]
        void GuardarEncuesta(Encuesta encuesta);
    }
}
