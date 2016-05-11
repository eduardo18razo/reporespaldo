﻿using System.ServiceModel;
using KiiniNet.Entities.Operacion.Usuarios;

namespace KiiniNet.Services.Operacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceUsuarios" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceUsuarios
    {
        [OperationContract]
        void GuardarUsuario(Usuario usuario);
    }
}
