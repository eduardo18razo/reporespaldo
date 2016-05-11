using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Usuario;

namespace KiiniNet.Entities.Cat.Sistema
{
    [DataContract(IsReference = true)]
    public class TipoSubGrupo
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
        public virtual List<SubGrupoUsuario> SubGrupoUsuario { get; set; }
        [DataMember]
        public virtual List<TipoGrupo> TipoGrupo { get; set; }
    }
}
