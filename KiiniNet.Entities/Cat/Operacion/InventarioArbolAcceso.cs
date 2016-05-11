using System.Collections.Generic;
using System.Runtime.Serialization;
using KiiniNet.Entities.Cat.Mascaras;
using KiiniNet.Entities.Cat.Usuario;
using KiiniNet.Entities.Operacion;

namespace KiiniNet.Entities.Cat.Operacion
{
    [DataContract(IsReference = true)]
    public class InventarioArbolAcceso
    {
        public int Id { get; set; }

        [DataMember]
        public int IdArbolAcceso { get; set; }
        [DataMember]
        public int? IdMascara { get; set; }
        [DataMember]
        public int? IdSLA { get; set; }
        [DataMember]
        public int? IdGrupoResponsable { get; set; }
        [DataMember]
        public int? IdGrupoAtendedor { get; set; }
        [DataMember]
        public int? IdGrupoEspConsulta { get; set; }
        [DataMember]
        public int? IdEncuesta { get; set; }
        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public virtual ArbolAcceso ArbolAcceso { get; set; }
        [DataMember]
        public virtual Mascara Mascara { get; set; }
        [DataMember]
        public virtual SLA SLA { get; set; }
        [DataMember]
        public virtual GrupoUsuario GrupoResponsable { get; set; }
        [DataMember]
        public virtual GrupoUsuario GrupoAtendedor { get; set; }
        [DataMember]
        public virtual GrupoUsuario GrupoEspecialConsulta { get; set; }
        [DataMember]
        public virtual Encuesta Encuesta { get; set; }
        [DataMember]
        public virtual List<InventarioInfConsulta> InventarioInfConsulta { get; set; } 
    }
}

