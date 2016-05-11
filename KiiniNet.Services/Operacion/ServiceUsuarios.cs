using KiiniNet.Entities.Operacion.Usuarios;
using KinniNet.Core.Operacion;

namespace KiiniNet.Services.Operacion
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceUsuarios" en el código y en el archivo de configuración a la vez.
    public class ServiceUsuarios : IServiceUsuarios
    {
        public void GuardarUsuario(Usuario usuario)
        {
            using (BusinessUsuarios negocio = new BusinessUsuarios())
            {
                negocio.GuardarUsuario(usuario);
            }
        }
    }
}
