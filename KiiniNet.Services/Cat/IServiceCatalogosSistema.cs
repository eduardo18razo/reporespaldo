using System.Collections.Generic;
using System.ServiceModel;
using KiiniNet.Entities.Cat.Arbol.Ubicaciones.Domicilio;
using KiiniNet.Entities.Cat.Mascaras;
using KiiniNet.Entities.Cat.Sistema;

namespace KiiniNet.Services.Cat
{
    [ServiceContract]
    public interface IServiceCatalogosSistema
    {
        [OperationContract]
        List<TipoUsuario> ObtenerTiposUsuario(bool insertarSeleccion);

        [OperationContract]
        List<TipoTelefono> ObtenerTiposTelefono(bool insertarSeleccion);

        [OperationContract]
        List<Colonia> ObtenerColoniasCp(int cp, bool insertarSeleccion);

        [OperationContract]
        List<Rol> ObtenerRoles(int idTipoUsuario, bool insertarSeleccion);

        [OperationContract]
        List<TipoGrupo> ObtenerTiposGruposByRol(int idrol, bool insertarSeleccion);

        [OperationContract]
        List<TipoGrupo> ObtenerTiposGrupo(bool insertarSeleccion);

        [OperationContract]
        List<TipoCampoMascara> ObtenerTipoCampoMascara(bool insertarSeleccion);

        [OperationContract]
        TipoCampoMascara TipoCampoMascaraId(int idTipoCampo);

        [OperationContract]
        List<Catalogos> ObtenerCatalogosMascaraCaptura(bool insertarSeleccion);

        [OperationContract]
        List<TipoArbolAcceso> ObtenerTiposArbolAcceso(bool insertarSeleccion);

        [OperationContract]
        List<TipoInfConsulta> ObtenerTipoInformacionConsulta(bool insertarSeleccion);

        [OperationContract]
        List<TipoDocumento> ObtenerTipoDocumentos(bool insertarSeleccion);

        [OperationContract]
        TipoDocumento ObtenerTiposDocumentoId(int idTipoDocumento);

        [OperationContract]
        List<TipoEncuesta> ObtenerTiposEncuesta(bool insertarSeleccion);

        [OperationContract]
        TipoEncuesta TipoEncuestaId(int idTipoEncuesta);
    }
}
