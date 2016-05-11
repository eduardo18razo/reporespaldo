using System.Collections.Generic;
using System.ServiceModel;
using KiiniNet.Entities.Operacion.Usuarios;
using KiiniNet.Entities.Parametros;

namespace KiiniNet.Services.Parametros
{
    [ServiceContract]
    public interface IServiceParametros
    {
        [OperationContract]
        List<ParametrosTelefonos> TelefonosObligatorios(int idTipoUsuario);

        [OperationContract]
        List<TelefonoUsuario> ObtenerTelefonosParametrosIdTipoUsuario(int idTipoUsuario, bool insertarSeleccion);

        [OperationContract]
        List<CorreoUsuario> ObtenerCorreosParametrosIdTipoUsuario(int idTipoUsuario, bool insertarSeleccion);

    }
}
