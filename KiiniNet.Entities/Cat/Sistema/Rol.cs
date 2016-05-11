using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Operacion.Usuarios;

namespace KiiniNet.Entities.Cat.Sistema
{
    [DataContract(IsReference = true)]
    public class Rol
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool EsUnico { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }

        [DataMember]
        public virtual List<RolTipoUsuario> RolTipoUsuario { get; set; }
        [DataMember]
        public virtual List<RolTipoGrupo> RolTipoGrupo { get; set; }
        [DataMember]
        public virtual List<UsuarioRol> UsuarioRol { get; set; }
    }
}
