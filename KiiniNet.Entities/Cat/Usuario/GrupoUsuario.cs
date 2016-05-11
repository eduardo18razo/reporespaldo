using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Operacion;
using KiiniNet.Entities.Cat.Sistema;
using KiiniNet.Entities.Operacion.Usuarios;

namespace KiiniNet.Entities.Cat.Usuario
{
    [DataContract(IsReference = true)]
    public class GrupoUsuario
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoGrupo { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public bool Habilitado { get; set; }
        
        [DataMember]
        public virtual TipoSubGrupo TipoGrupo { get; set; }
        [DataMember]
        public virtual List<SubGrupoUsuario> SubGrupoUsuario { get; set; }

        [DataMember]
        public virtual List<UsuarioGrupo> UsuarioGrupo { get; set; }

        [DataMember]
        public virtual List<InventarioArbolAcceso> InventarioArbolAccesoResponsable { get; set; }
        [DataMember]
        public virtual List<InventarioArbolAcceso> InventarioArbolAccesoAtendedor { get; set; }
        [DataMember]
        public virtual List<InventarioArbolAcceso> InventarioArbolAccesoEspecialConsulta { get; set; }


    }
}
